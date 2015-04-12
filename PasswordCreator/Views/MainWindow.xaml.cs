using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using PasswordCreator.Models;
using PasswordCreator.ViewModels;

namespace PasswordCreator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// コンストラクタ
        /// ダイアログの定義とViewModelの設定を行なう。
        /// </summary>
        public MainWindow()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            DataContextChanged += (s, e) =>
            {
                MainWindowViewModel vm = DataContext as MainWindowViewModel;
                if (vm == null) throw new InvalidCastException();
                vm.ShowInfoDialog　　 = PasswordCreator.Views.CommonDialog.ExecuteShowInfoDialog;
                vm.ShowYesNoDialogBox = PasswordCreator.Views.CommonDialog.ExecuteShowYesNoDialogBox;
                vm.ShowOpenFileDialog = ExecuteOpenFileDialog;
                vm.ShowSaveFileDialog = ExecuteSaveFileDialog;
                vm.ShowErrorDialog    = PasswordCreator.Views.CommonDialog.ExecuteShowErrorDialog;
            };
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// ファイルを開くダイアログを表示
        /// </summary>
        /// <returns>ダイアログで選択されたファイル名</returns>
        private string ExecuteOpenFileDialog()
        {
            return FileDialog(new OpenFileDialog(), Properties.Resources.Title_Import);
        }
        /// <summary>
        /// ファイルを保存するダイアログを表示
        /// </summary>
        /// <returns>ダイアログで選択されたファイル名</returns>
        private string ExecuteSaveFileDialog()
        {
            return FileDialog(new SaveFileDialog(), Properties.Resources.Title_Export);
        }
        /// <summary>
        /// ファイルに関するダイアログの共通処理
        /// </summary>
        /// <param name="dialog">ダイアログのインスタンス</param>
        /// <param name="title">ダイアログに表示するタイトル</param>
        /// <returns>ダイアログで選択されたファイル名</returns>
        private string FileDialog(FileDialog dialog, string title)
        {
            dialog.Filter = Properties.Resources.Csv_Filter;
            dialog.Title = title;
            dialog.CheckPathExists = true;

            if (dialog is OpenFileDialog)
            {
                dialog.CheckFileExists = true;
            }

            bool r = dialog.ShowDialog(this) ?? false;
            return r ? dialog.FileName : null;
        }

        /// <summary>
        /// ウィンドウを閉じる処理
        /// </summary>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 編集画面への遷移処理
        /// </summary>
        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindowViewModel vm = DataContext as MainWindowViewModel;
            if (vm == null) throw new InvalidCastException();
            vm.OpenUpdateWindow();
        }

        /// <summary>
        /// 選択セルで右クリック時、クリップボードへのコピーを実施
        /// </summary>
        /// <param name="sender">DataGridオブジェクト</param>
        private void DataGrid_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridCellInfo cell = ((DataGrid)sender).CurrentCell;
            if(cell.Column == null)return;
            string column_name = cell.Column.SortMemberPath;
            string cell_value = ((PasswordItem)cell.Item).GetColumnValue(column_name).ToString();
            Clipboard.SetText(cell_value);
        }

        /// <summary>
        /// URLクリック時、デフォルトのブラウザでWebサイトを表示
        /// </summary>
        /// <param name="e">イベント引数のオブジェクト</param>
        private void OnHyperlinkClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var destination = ((System.Windows.Documents.Hyperlink)e.OriginalSource).NavigateUri;
            System.Diagnostics.Process.Start(destination.ToString());
        }

        private void DataGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((sender as DataGrid).SelectedItem != null)
            {
                (sender as DataGrid).SelectedItem = null;
            }
        }
    }
}