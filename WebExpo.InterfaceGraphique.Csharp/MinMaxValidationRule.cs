using System.Globalization;

namespace WebExpo.InterfaceGraphique
{
    public class MinMaxValidationRule : System.Windows.Controls.ValidationRule
    {
        private DoubleRangeChecker validRange;

        public DoubleRangeChecker ValidRange
        {
            get { return validRange; }
            set { validRange = value; }
        }

        private bool isOptional = false;
        public bool Optional
        {
            get { return isOptional; }
            set { isOptional = value; }
        }

        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double res = double.MinValue;
            string text = value.ToString();
            bool isDouble = true;
            bool isValidRange = true;
            if (validRange == null )
            {
                isValidRange = true;
            }
            else if ( text.Length > 0 )
            {
                isDouble = double.TryParse(text, NumberStyles.Number, cultureInfo, out res);
                if (isDouble)
                {
                    isValidRange = (res >= validRange.Minimum & res <= validRange.Maximum);
                }
            }
            string errorString = !isDouble ? Properties.Resources.InvalidValue + " !" : (!isValidRange ? string.Format(cultureInfo, Properties.Resources.ValidRange + " : [{0} - {1}]", this.ValidRange.Minimum, this.ValidRange.Maximum) : (string.Empty));
            bool validationResult = (isOptional && text.Length == 0) || (isDouble && isValidRange);
            return new System.Windows.Controls.ValidationResult(validationResult, errorString);

        }
    }
}
