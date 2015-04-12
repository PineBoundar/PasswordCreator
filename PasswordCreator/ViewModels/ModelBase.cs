using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TeamFoundation.MVVM;

namespace PasswordCreator
{
    class ModelBase : ViewModelBase, IDataErrorInfo
    {
        // エラーを格納する変数
        private readonly Dictionary<string, string> errors_ = new Dictionary<string, string>();

        /// <summary>
        /// これまでに格納されたエラーの個数を返す。
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return errors_.Count != 0;
            }
        }
        /// <summary>
        /// GUIに表示するエラーの文字列を返す。
        /// </summary>
        public virtual string Error
        {
            get
            {
                return HasErrors ? string.Format(Properties.Resources.Error_Invalid_Value, errors_.Count) : "";
            }
        }

        /// <summary>
        /// 引数で指定された部品が持つエラー文字列を返す。
        /// </summary>
        /// <param name="propertyName">部品の指定</param>
        /// <returns>エラーの文字列(無ければ空文字)</returns>
        public string this[string propertyName]
        {
            get
            {
                return errors_.ContainsKey(propertyName) ? errors_[propertyName] : "";
            }
        }

        /// <summary>
        /// 引数で指定された部品のエラー文字列を設定する。
        /// </summary>
        /// <param name="propertyName">部品の指定</param>
        /// <param name="errorMessage">エラーの文字列</param>
        protected void UpdateErrors(string propertyName, string errorMessage)
        {
            if(string.IsNullOrEmpty(errorMessage))
            {
                errors_.Remove(propertyName);
            }
            else
            {
                errors_[propertyName] = errorMessage;
            }
        }
    }
}
