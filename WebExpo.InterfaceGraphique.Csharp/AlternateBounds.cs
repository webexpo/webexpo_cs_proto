using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpo.InterfaceGraphique
{
    public class AlternateBounds
    {
        private const int NO_STATES = 2;
        private double[] min = new double[NO_STATES];
        private double[] max = new double[NO_STATES];
        private int state = 0;

        public AlternateBounds()
        {
            setState(true);
        }

        public AlternateBounds(double min1, double max1, double min2, double max2, bool state = false)
        {
            min[0] = min1;
            min[1] = min2;

            max[0] = max1;
            max[1] = max2;

            setState(state);
        }

        public double Minimum
        {
            get { return min[state]; }
        }

        public double Maximum
        {
            get { return max[state]; }
        }

        public void setState(bool state)
        {
            this.state = state ? 1 : 0;
        }

        public double Min1
        {
            get { return min[0]; }
            set { min[0] = value; }
        }

        public double Min2
        {
            get { return min[1]; }
            set { min[1] = value; }
        }

        public double Max1
        {
            get { return max[0]; }
            set { max[0] = value; }
        }

        public double Max2
        {
            get { return max[1]; }
            set { max[1] = value; }
        }
    }
}