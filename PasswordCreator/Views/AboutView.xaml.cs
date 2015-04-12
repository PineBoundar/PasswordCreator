using System;
using System.Windows;
using PasswordCreator.ViewModels;

namespace PasswordCreator
{
    /// <summary>
    /// AboutView.xaml の相互作用ロジック
    /// </summary>
    public partial class AboutView : Window
    {
        public AboutView()
        {
            DataContextChanged += (s, e) =>
            {
                AboutViewModel x = DataContext as AboutViewModel;
                if (x == null) throw new InvalidCastException();
                x.ShowDialogBox = () => ShowDialog();
            };
            InitializeComponent();
        }
    }
}
