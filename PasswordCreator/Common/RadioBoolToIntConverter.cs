using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PasswordCreator
{
    /// <summary>
    /// ラジオボタンのValue値とViewModelのバインド変数(int)を対応させるコンバータクラス
    /// </summary>
    public class RadioBoolToIntConverter : IValueConverter
    {
        /// <summary>
        /// バインド変数の変更時、ラジオボタンを連動させるために呼び出されるコンバータ
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int integer = (int)value;
            if (integer==int.Parse(parameter.ToString())){
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// ラジオボタンの変更時、バインド変数を連動させるために呼び出されるコンバータ
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }
}
