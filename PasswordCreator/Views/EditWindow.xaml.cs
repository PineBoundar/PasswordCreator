using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using PasswordCreator.ViewModels;

namespace PasswordCreator
{
    public partial class EditWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EditWindow()
        {
            DataContextChanged += (s, e) =>
            {
                EditViewModel vm = DataContext as EditViewModel;
                if (vm == null) throw new InvalidCastException();
                vm.ShowDialogBox = () => ShowDialog() ?? false;
                vm.CloseDialogBox = p => DialogResult = p;
                vm.ShowYesNoDialogBox = PasswordCreator.Views.CommonDialog.ExecuteShowYesNoDialogBox;
            };
            InitializeComponent();
        }
        
        /// <summary>
        /// Escキーが押された時にダイアログを閉じる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
