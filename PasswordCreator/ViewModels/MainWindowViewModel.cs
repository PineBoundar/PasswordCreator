using System;
using System.Collections.ObjectModel;
using PasswordCreator.Models;

namespace PasswordCreator.ViewModels
{
    partial class MainWindowViewModel : ModelBase
    {
        // データグリッドで選択した1行のデータ
        private PasswordItem item_;
        public PasswordItem RowItem
        {
            get
            {
                return item_;
            }
            set
            {
                item_ = value;
                RaisePropertyChanged("RowItem");
            }
        }
        // データグリッドに表示するデータ全体
        private PasswordModel models_;
        public ObservableCollection<PasswordItem> Items {
            get
            {
                RaisePropertyChanged("ResultsNum");
                return models_.PasswordItems;
            }
        }
        // 検索キーワード
        private string keyword_;
        public string Keyword
        {
            get
            {
                return keyword_;
            }
            set
            {
                keyword_ = value;
                ExecuteSearchCommand();
                RaisePropertyChanged("Keyword");
            }
        }

        // 検索結果件数
        public string ResultsNum {
            get {
                return string.Format("検索結果：{0} 件", models_.PasswordItems.Count);
            }
        }

        // ダイアログボックスのデリゲート
        public Action<string>     ShowInfoDialog        { get; set; }
        public Func<string, bool> ShowYesNoDialogBox    { get; set; }
        public Func<string>       ShowOpenFileDialog    { get; set; }
        public Func<string>       ShowSaveFileDialog    { get; set; }
        public Action<string>     ShowErrorDialog       { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            models_ = new PasswordModel();
        }

        /// <summary>
        /// 新規登録画面の表示と新規データ登録処理
        /// </summary>
        private void ExecuteAppendCommand()
        {
            PasswordItem password = models_.NewSitePassword(RowItem);
            if (! EditViewModel.ShowDialog(password)) return;

            PasswordItem exists = models_.PickUp(password.SiteName, password.UserId);
            if (exists != null) {
                if (!ShowYesNoDialogBox(Properties.Resources.Contents_Question_Overwrite)) return;
                Delete(exists);
            }
            models_.Add(password);
            try
            {
                models_.SaveChanges();
                RowItem = password;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                models_.Remove(password);
                ShowErrorDialog(ex.InnerException.InnerException.Message);
            }
            RaisePropertyChanged("ResultsNum");
        }

        /// <summary>
        /// データ操作の可否チェック
        /// </summary>
        /// <returns>選択行の有無(true:有り / false:無し)</returns>
        private bool CanEditDataCommand(object x)
        {
            return RowItem != null;
        }

        /// <summary>
        /// 編集ボタンの押下処理
        /// </summary>
        private void ExecuteUpdateCommand(object x)
        {
            OpenUpdateWindow();
        }
        /// <summary>
        /// 編集画面の表示と編集データ登録処理
        /// </summary>
        public void OpenUpdateWindow()
        {
            PasswordItem password = models_.NewSitePassword(RowItem);
            if (!EditViewModel.ShowDialog(password)) return;
            password.Date = DateTime.Now;
            RowItem.SetProperties(password);
            try
            {
                models_.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                ShowErrorDialog(ex.InnerException.InnerException.Message);
            }
        }

        /// <summary>
        /// 削除ボタン押下処理
        /// </summary>
        private void ExecuteDeleteCommand(object x)
        {
            if (!ShowYesNoDialogBox(Properties.Resources.Contents_Question_Delete)) return;
            Delete(RowItem);
        }
        /// <summary>
        /// 選択された行のデータ削除
        /// </summary>
        /// <param name="model"></param>
        private void Delete(PasswordItem model){
            RowItem = null;
            models_.Remove(model);
            models_.SaveChanges();
            RaisePropertyChanged("ResultsNum");
        }

        /// <summary>
        /// キーワードを使った検索処理
        /// </summary>
        private void ExecuteSearchCommand()
        {
            RowItem = null;
            models_.Renew(Keyword);
            RaisePropertyChanged("Items");
        }

        /// <summary>
        /// CSVファイルのインポート処理
        /// </summary>
        private void ExecuteImportCommand()
        {
            string filename = ShowOpenFileDialog();
            if (string.IsNullOrEmpty(filename)) return;
            try
            {
                models_.Import(filename);
                ShowInfoDialog(Properties.Resources.Contents_Information_Import);
                models_.Renew(null);
            }
            catch (ImportDataException ex)
            {
                string message = string.Format("{0}\n[ 詳細 ]\n問題の行:\t{1}\n原因:\t{2}\n", ex.Message, ex.InnerException.Data["Caused"], ex.InnerException.Message);
                ShowErrorDialog(message);
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        /// <summary>
        /// CSVファイルのエクスポート処理
        /// </summary>
        private void ExecuteExportCommand()
        {
            string filename = ShowSaveFileDialog();
            if (string.IsNullOrEmpty(filename)) return;
            try
            {
                models_.Export(filename);
                ShowInfoDialog(Properties.Resources.Contents_Information_Export);
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        /// <summary>
        /// Aboutポップアップの表示処理
        /// </summary>
        private void ExecuteAboutCommand()
        {
            AboutViewModel.ShowDialog();
        }

        /// <summary>
        /// ヘルプファイルの表示処理
        /// </summary>
        private void ExecuteHelpCommand()
        {
            try
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.HelpUri);
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        /// <summary>
        /// 検索キーワード消去処理
        /// </summary>
        private void ExecuteClearCommand()
        {
            Keyword = "";
        }
    }
}
