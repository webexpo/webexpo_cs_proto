using System.Windows.Controls;
using Zygotine.WebExpo;

namespace WebExpo.InterfaceGraphique
{
    public class MeasureListValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            MeasureList ml = new MeasureList(value as string);
            return new ValidationResult(true, null);
        }
    }
}