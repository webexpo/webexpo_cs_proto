using System.ComponentModel;

namespace WebExpo.InterfaceGraphique
{
    public class BindingProxy : INotifyPropertyChanged
    {
        private double min, max;
        
        public event PropertyChangedEventHandler PropertyChanged;
        public BindingProxy()
        {
        }

        private AlternateBounds _bounds = null;
        public AlternateBounds Bounds
        {
            get {
                return _bounds;
            }
            set
            {
                _bounds = value;
            }
        }

        public double MinValue
        {
            get {
                return Bounds.Minimum;
            }
            set
            {
                min = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("MinValue");
            }
        }

        public double MaxValue
        {
            get
            {
                return Bounds.Maximum;
            }
            set
            {
                max = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("MaxValue");
            }
        }

        //// Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}