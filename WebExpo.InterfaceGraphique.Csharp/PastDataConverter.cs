using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WebExpo.InterfaceGraphique
{
    public class PastDataConverter : IValueConverter
    {
        private bool firstConversion = true;

        private bool handleInt = false;
        public bool HandleInt
        {
            get { return handleInt; }
            set {
                handleInt = value;  }
        }

        public PastDataConverter() : base()
        {
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = "";
            if (value is double)
            {
                double d = (double)value;
                if (!double.IsNaN(d))
                {
                    text = d.ToString("N2", culture);
                } else
                {
                    text = "";
                }
            } else
            {
                if (firstConversion)
                {
                    if ((int) value == 0)
                    {
                        text = "";
                    }
                    firstConversion = false;
                }
                else
                {
                    text = value.ToString();
                }
            }
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = value.ToString();
            double d = 0;

            if ( handleInt )
            {
                int i = 0;
                if ( text.Length > 0 )
                {
                    int.TryParse(text, out i);
                }
                return i;
            }
            switch (text)
            {
                case "":
                    d = double.NaN;
                    break;
                default:
                    double.TryParse(text, System.Globalization.NumberStyles.Number, culture, out d);
                    break;
            }
            return d;
        }
    }
}
