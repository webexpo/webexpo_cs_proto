using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WebExpo.InterfaceGraphique
{
    public class Wrapper : DependencyObject
    {
        public static DependencyProperty MaxMuProperty =
             DependencyProperty.Register("MaxMu", typeof(double),
             typeof(Wrapper), new FrameworkPropertyMetadata(double.MaxValue));

        public double MaxMu
        {
            get
            {
                double d = (double) GetValue(MaxMuProperty);
                return d;
            }
            set
            {
                SetValue(MaxMuProperty, value);
            }
        }

        private int foo = 42;
        public int Foo
        {
            get
            {
                return foo;
            }
            set
            {
                foo = value;
            }
        }

        public Wrapper() {
        }
    }


}
