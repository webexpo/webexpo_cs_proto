using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Controls;

namespace WebExpo.InterfaceGraphique
{
    public class CheckBoxConverter : IValueConverter
    {
        public CheckBoxConverter() : base()
        {
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool ret = (bool) (value as CheckBox).IsChecked;
            return ret;
        }
    }
}
