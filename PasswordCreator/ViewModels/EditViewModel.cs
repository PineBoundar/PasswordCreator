using System;
using System.Text;
using PasswordCreator.Models;
using System.Collections.Generic;

namespace PasswordCreator.ViewModels
{
    partial class EditViewModel : ModelBase
    {
        // 編集対象の行データ
        private PasswordItem model_;

        // パスワードの文字数
        private int passwordLength_ = 8;
        public int PasswordLength {
            get {
                return passwordLength_;
            }
            set {
                passwordLength_ = value; 
                RaisePropertyChanged("PasswordLength");
            }
        }

        private List<string> items_source_;
        public List<string> ItemsSource
        {
            get
            {
                if (items_source_ == null) items_source_ = CreateItems();
                return items_source_;
            }
        }

        private List<string> CreateItems()
        {
            char[] separator = { '|' };
            string text = Properties.Resources.Category;
            string[] records = text.Split(separator);

            List<string> items = new List<string>();
            items.AddRange(records);
            return items;
        }

        // パスワード中の記号の有無
        public bool HasSign { set; get; }

        // 編集モード
        public bool EditMode { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="password">編集対象となる行データ</param>
        public EditViewModel(PasswordItem password)
        {
            model_    = password;
            SiteName  = password.SiteName;
            Url       = password.Url;
            UserId    = password.UserId;
            Password  = password.Password;
            Category  = password.Category;
            Note      = password.Note;
            EditMode  = !String.IsNullOrEmpty(password.SiteName);
        }
        /// <summary>
        /// デリゲート(View側で処理を登録)
        /// </summary>
        public Action<bool> CloseDialogBox { get; set; }
        public Func<bool>   ShowDialogBox  { get; set; }
        public Func<string, bool> ShowYesNoDialogBox { get; set; }

        /// <summary>
        /// 登録ボタンの押下チェック
        /// (エラー発生時は押下不可)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>押下可否(true:可)</returns>
        private bool CanExecuteOkCommand(object obj)
        {
            return !base.HasErrors;
        }
        /// <summary>
        /// 登録ボタンの押下処理
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteOkCommand(object obj)
        {
            if (String.IsNullOrEmpty(Password))
            {
                if (!this.ShowYesNoDialogBox(Properties.Resources.Contents_Question_NothingPassword))
                {
                    return;
                }
            }
            this.CloseDialogBox(true);
        }

        /// <summary>
        /// キャンセルボタンの押下処理
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteCancelCommand(object obj)
        {
            this.CloseDialogBox(false);
        }

        /// <summary>
        /// 自動生成ボタンの押下処理
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteGenerateCommand(object obj)
        {
            if (HasSign)
            {
                Password = System.Web.Security.Membership.GeneratePassword(PasswordLength, 3);
            }
            else
            {
                StringBuilder sb = new StringBuilder(PasswordLength);
                Random r = new Random();

                for (int i = 0; i < PasswordLength; i++)
                {
                    //文字の位置をランダムに選択
                    int pos = r.Next(Properties.Resources.PasswordChar.Length);
                    //選択された位置の文字を取得
                    char c = Properties.Resources.PasswordChar[pos];
                    //パスワードに追加
                    sb.Append(c);
                }
                Password = sb.ToString();
            }
        }

        /// <summary>
        /// 編集ウィンドウを開く処理
        /// </summary>
        /// <param name="password">編集対象となる行データ</param>
        /// <returns></returns>
        static public bool ShowDialog(PasswordItem password)
        {
            EditViewModel vm = new EditViewModel(password);
            EditWindow v = new EditWindow();
            v.DataContext = vm;
            return vm.ShowDialogBox();
        }
    }
}
