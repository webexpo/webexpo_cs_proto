using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Zygotine.WebExpo;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Media;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WebExpo.InterfaceGraphique
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private SEGInformedVarModelParameters modelParams = SEGInformedVarModelParameters.GetDefaults(logNormalDstrn: true);
        public SEGInformedVarModelParameters ModelParams
        {
            get
            {
                return modelParams;
            }
            set
            {
                modelParams = value;
                OnPropertyChanged();
            }
        }

        private BWModelParameters bwModelParams = BWModelParameters.GetDefaults(true);
        public BWModelParameters BwModelParams
        {
            get
            {
                return bwModelParams;
            }
            set
            {
                bwModelParams = value;
                OnPropertyChanged();
            }
        }

        private BWModelParameters_UniformPriorOnSDs bwuModelParams = BWModelParameters_UniformPriorOnSDs.GetDefaults(true);
        public BWModelParameters_UniformPriorOnSDs BWUModelParams
        {
            get
            {
                return bwuModelParams;
            }
            set
            {
                bwuModelParams = value;
                OnPropertyChanged();
            }
        }

        private Range meRange = resetMeasErrRange();
        public Range MERange
        {
            get
            {
                return meRange;
            }
            set {
                meRange = value;
                OnPropertyChanged();
            }
        }

        private double[] sdRange = UninformativeModelParameters.GetDefaults(true).SDRange;
        public double[] SDRange
        {
            get { return sdRange;  }
            set { sdRange = value; OnPropertyChanged(); }
        }


        public static string CR = "\r\n";

        private McmcParameters mcmcParams = new McmcParameters(nIter: 10000, nBurnin: 500, nThin: 1, monitorBurnin: false);
        public McmcParameters MCMCParams
        {
            get { return mcmcParams; }
            set { mcmcParams = value; OnPropertyChanged(); }
        }

        private PastDataSummary pastData = new PastDataSummary();
        public PastDataSummary PastData
        {
            get { return pastData; }
            set {
                pastData = value;
                OnPropertyChanged(); }
        }

        private Entrees entrs = new Entrees();
        public Entrees Entrs
        {
            get { return entrs;  }
            set { entrs = value; OnPropertyChanged();  }
        }
        

        Resultats r = null;

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.Manual;
            string hostname = System.Environment.MachineName;
            this.Left = hostname == "N50110" ? -1500 : 0;
            this.Top = 100;

            CultureInfo ci = CultureInfo.CurrentCulture;
            ObservationsChanged();

            BWInitValsCanvas.Visibility = BWInitValsCanvas.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
            BWCanvas.Visibility = BWCanvas.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
            BWWwctCanvas.Visibility = BWWwctCanvas.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void LancerCalculs(object sender, RoutedEventArgs e)
        {
            if ( Entrs.Observations.Length > 0 && ( r == null || !r.Busy ) )
            {
                Object buttonContent = this.buttonLancer.Content;
                this.buttonLancer.Content = Properties.Resources.CalcRunning;
                this.buttonLancer.IsEnabled = false;
                this.buttonLancer.Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
                Launch();
                this.buttonLancer.Content = Properties.Resources.StartCalculations;
                this.buttonLancer.IsEnabled = true;
                this.buttonLancer.Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
            }
        }

        private void Launch()
        {
            var model = buildModel();

            Task.Delay(1);

            if (model != null)
            {
                if (r != null)
                {
                    r.Close();
                }
                r = new Resultats(Entrs, model, mcmcParams, this);
                r.Show();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void ToggleDistributionLogNormal(object sender, RoutedEventArgs e)
        {
            ToggleModel((sender as RadioButton).Name);
        }

        private void ToggleModel(string senderName)
        {
            bool distLogNormal = (bool)DistLogNormale.IsChecked;
            bool useBWModel = (bool)UseModelBW.IsChecked;
            ToggleModel (distLogNormal, useBWModel, senderName);
        }

        private void ToggleModel(bool distLogNormal, bool useBWModel, string senderName = null)
        {
            
            ModelParams = SEGInformedVarModelParameters.GetDefaults(distLogNormal);
            BwModelParams = BWModelParameters.GetDefaults(distLogNormal);
            BWUModelParams = BWModelParameters_UniformPriorOnSDs.GetDefaults(distLogNormal);

            Entrs = Entrees.GetDefaults(distLogNormal, useBWModel);

            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                try
                {
                    BindingProxy bp = tb.FindResource("boundsProxy") as BindingProxy;
                    bp.Bounds.setState(distLogNormal);
                    bp.MinValue = bp.Bounds.Minimum;
                    bp.MaxValue = bp.Bounds.Maximum;
                } catch (ResourceReferenceKeyNotFoundException)
                {
                }
            }
            MECanvas.Visibility = (bool) UseModelGES.IsChecked ? Visibility.Visible : Visibility.Hidden;
            MERange = resetMeasErrRange();

            SDRange = UninformativeModelParameters.GetDefaults(distLogNormal).SDRange;

            if (senderName.StartsWith("UseModel"))
            {
                if (useBWModel)
                {
                    BWCanvas.Margin = DAPLabel.Margin;
                    BWInitValsCanvas.Margin = InitValLabel.Margin;
                }
                foreach (Canvas canv in FindVisualChildren<Canvas>(this))
                {
                    if (canv.Name.StartsWith("BW"))
                    {
                        canv.Visibility = canv.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
                    }
                }
            }
            OnPropertyChanged();
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void ForceNumericTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void ForceDecimalTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.-]+").IsMatch(e.Text);
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private static Range resetMeasErrRange()
        {
            return new Range(30, 30);
        }

        private Model buildModel()
        {
            Model model = null;
            Range mer = meRange;

            string mlStr = String.Join("|", Entrs.Observations.Split(new String[] { CR }, StringSplitOptions.RemoveEmptyEntries));
            string meStr = "";
            if ( (bool)me_CV.IsChecked && !(MERange.Minimum == 0 && MERange.Maximum == 0))
            {
                meStr = "cv(" + ShowDouble(MERange.Minimum/100) + "~" + ShowDouble(MERange.Maximum/100) + ")|";
            }

            PastDataSummary PD = new PastDataSummary();
            if ( (bool)DistriAP_ExpostatsPData.IsChecked && !double.IsNaN(PastData.Mean) && !double.IsNaN(PastData.SD) && PastData.N != 0)
            {
                PD = new PastDataSummary(PastData.Mean, PastData.SD, PastData.N);
            }

            bool preBuildError = false;
            MeasureList ml = new MeasureList(meStr + mlStr, Entrs.VLE);
            
            if ( !preBuildError )
            {
                if ((bool)UseModelGES.IsChecked)
                {
                    if ((bool)DistriAP_Expostats.IsChecked)
                    {
                        model = new SEGInformedVarModel(measures: ml, specificParams: ModelParams, mcmcParams: MCMCParams, pastDataSummary: PD);
                    }
                    else if ((bool)DistriAP_Uniforme.IsChecked)
                    {
                        UninformativeModelParameters ump = convertParams(ModelParams);
                        model = new SEGUninformativeModel(measures: ml, specificParams: ump, mcmcParams: MCMCParams);
                    }
                }
                else if ((bool)UseModelBW.IsChecked)
                {
                    if ((bool)DistribAPBW_Expostats.IsChecked)
                    {
                        model = new BetweenWorkerModel(ml, BwModelParams, MCMCParams);
                    }
                    else if ((bool)DistribAPBW_Uniform.IsChecked)
                    {
                        BWUModelParams.InitMuOverall = BwModelParams.InitMuOverall;
                        BWUModelParams.InitSigmaWithin = BwModelParams.InitSigmaWithin;
                        BWUModelParams.MuOverallLower = BwModelParams.MuOverallLower;
                        BWUModelParams.MuOverallUpper = BwModelParams.MuOverallUpper;
                        model = new BetweenWorkerModel(ml, BWUModelParams, MCMCParams);
                    }
                }
            }

            return model;
        }

        private UninformativeModelParameters convertParams(SEGInformedVarModelParameters imp)
        {
            UninformativeModelParameters ump = UninformativeModelParameters.GetDefaults(imp.LogNormalDstrn);
            ump.InitMu = imp.InitMu;
            ump.InitSD = imp.InitSigma;
            ump.MuLower = imp.MuLower;
            ump.MuUpper = imp.MuUpper;
            ump.SDRange = SDRange;
            return ump;
        }

        private void OptionChecked(object sender, RoutedEventArgs e = null)
        {
            string name = sender is RadioButton ? (sender as RadioButton).Name : (sender as CheckBox).Name;
            string[] tokens = name.Split('_');
            string pfx = "0";
            if ( tokens.Length == 2 )
            {
                pfx = tokens[0];
            }

            Control c2 = null;
            foreach (Control c in FindVisualChildren<Control>(this))
            {
                bool isCb = c is CheckBox;
                if (c is Label || c is TextBox || isCb ) {
                    string cName = c.Name;
                    if (cName != name)
                    {
                        if (cName.StartsWith(name) && !cName.Substring(name.Length + 1).Contains("_"))
                        {
                            c.IsEnabled = !c.IsEnabled;
                            if (isCb && c.IsEnabled && (bool) (c as CheckBox).IsChecked )
                            {
                                c2 = c;
                            }
                        }
                        else
                        if (cName.StartsWith(pfx) && !(sender is CheckBox) )
                        {
                            c.IsEnabled = false;
                        }
                    }
                }
            }

            if ( c2 != null )
            {
                OptionChecked(c2);
            }
        }

        private void ObservationsChanged()
        {
            ObservationsChanged(null, null);
        }

        private void ObservationsChanged(object sender, TextChangedEventArgs e)
        {
            if (NObservations != null)
            {
                int numObs = Observations.Text.Split(new String[] { CR }, StringSplitOptions.RemoveEmptyEntries).Length;
                NObservations.Content = "[" + numObs + " observation" + (numObs != 1 ? "s" : "") + "]";
            }
        }

        public static string ShowDouble(Object o)
        {
            return ShowDouble((double)o);
        }

        public static string ShowDouble(double d)
        {
            return ToSignificantDigits(d, 3);
        }

        private static string ToSignificantDigits( double value, int significant_digits)
        {
            // Use G format to get significant digits.
            // Then convert to double and use F format.
            string format1 = "{0:G" + significant_digits.ToString() + "}";
            string result = Convert.ToDouble(
                String.Format(format1, value)).ToString("F99");

            // Rmove trailing 0s.
            result = result.TrimEnd('0');

            // Rmove the decimal point and leading 0s,
            // leaving just the digits.
            string test = result.Replace(",",".").Replace(".", "").TrimStart('0');

            // See if we have enough significant digits.
            if (significant_digits > test.Length)
            {
                // Add trailing 0s.
                result += new string('0', significant_digits - test.Length);
            }
            else
            {
                // See if we should remove the trailing decimal point.
                if (/*(significant_digits < test.Length) &&*/ result.EndsWith(","))
                    result = result.Substring(0, result.Length - 1);
            }

            return result;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleBWModel(object sender, RoutedEventArgs e)
        {
            ToggleModel((sender as RadioButton).Name);
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleBurnin(object sender, RoutedEventArgs e)
        {
            MCMCParams.MonitorBurnin = !MCMCParams.MonitorBurnin;
        }

        private void ToggleCsvSep(object sender, RoutedEventArgs e)
        {
            MCMCParams.CsvSeparator = (sender as RadioButton).Name == "CsvSepPV" ? ";" : ",";
        }

        private void HistoClassesValueChange(object sender, RoutedEventArgs e)
        {
            double numClasses = (sender as Slider).Value;
            MCMCParams.NumHistoClasses = (int) numClasses;
        }


    }
}