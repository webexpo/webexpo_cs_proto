using System;
using System.Windows.Controls;

namespace WebExpo.InterfaceGraphique
{
    public class RangeValidationRule : ValidationRule
    {
        public Double Minimum { get; set; } = Double.MinValue;
        public Double Maximum { get; set; } = Double.MaxValue;
        public bool Optional { get; set; } = false;

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string valStr = value as string;
            if (valStr.Length > 0)
            {
                Double val;
                bool ok = Double.TryParse(valStr, System.Globalization.NumberStyles.Number, cultureInfo, out val);
                if (ok) {
                    if (val < Minimum || val > Maximum)
                    {
                        return new ValidationResult(false, String.Format(cultureInfo, "Bornes : [{0}, {1}]", Minimum, Maximum));
                    }
                } else
                {
                    return new ValidationResult(false, "Valeur invalide !");
                }
            }
            else if (!Optional)
            {
                return new ValidationResult(false, "Veuillez saisir une valeur");
            }
            return new ValidationResult(true, null);

        }
    }
}
