using System.Windows;

namespace PasswordCreator.Views
{
    static class CommonDialog
    {
        /// <summary>
        /// YES/NOを問うダイアログボックス
        /// </summary>
        /// <param name="message">ダイアログに表示するメッセージ</param>
        /// <returns>YESボタンがクリックされたかどうか(true=クリックされた)</returns>
        static public bool ExecuteShowYesNoDialogBox(string message)
        {
            MessageBoxResult r = MessageBox.Show(message, Properties.Resources.Title_Question, MessageBoxButton.OKCancel, MessageBoxImage.Question);
            return r == MessageBoxResult.OK;
        }

        /// <summary>
        /// 情報メッセージを表示するダイアログ
        /// </summary>
        /// <param name="message">表示するメッセージ</param>
        static public void ExecuteShowInfoDialog(string message)
        {
            MessageBox.Show(message, "PasswordCreator", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// エラーを表示するダイアログボックス
        /// </summary>
        /// <param name="message">表示するエラーメッセージ</param>
        static public void ExecuteShowErrorDialog(string message)
        {
            MessageBox.Show(message, Properties.Resources.Title_Error, MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
