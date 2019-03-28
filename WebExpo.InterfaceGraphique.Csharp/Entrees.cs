using System;
using System.Linq;

namespace WebExpo.InterfaceGraphique
{
    public class Entrees
    {
        public String Observations { get; set; } = String.Join("\r\n", ((new double[] { 28.9, 19.4, 5.5, 149.9, 26.42, 56.1 }).Select(z => (z == 5.5 ? "<" : "") + z.ToString()).ToArray()));
        public double VLE { get; set; } = 100;
        public double FacteurModVLE { get; set; } = 1;
        public double ProbCred { get; set; } = 90;
        public double SeuilRisqueSurexpo { get; set; } = 30;
        public double FracDepassementLimite { get; set; } = 5;
        public double CentileCritique { get; set; } = 95;
        public double SeuilCorrelationIntraTravailleur { get; set; } = 0.2;
        public double CouvertureRatioRb { get; set; } = 80;
        public double SeuilProbSurexpoIndiv { get; set; } = 20;

        public static Entrees GetDefaults(bool distLogNorm = true, bool useBWModel = false)
        {
            Entrees e = new Entrees();

            if ( useBWModel )
            {
                e.Observations = String.Join("\r\n", (new ValueTuple<double, string>[] { (40.1, Properties.Resources.Worker + "-10"), (28.5, Properties.Resources.Worker + "-02"), (48.5,Properties.Resources.Worker + "-09"), (87.0, Properties.Resources.Worker + "-01"), (6.73, Properties.Resources.Worker + "-05"), (105, Properties.Resources.Worker + "-07"), (64.6, Properties.Resources.Worker + "-01"), (87.5, Properties.Resources.Worker + "-06"), (6.38, Properties.Resources.Worker + "-02"), (68.6, Properties.Resources.Worker + "-06"), (41.4, Properties.Resources.Worker + "-10"), (92.2, Properties.Resources.Worker + "-08"), (19.1, Properties.Resources.Worker + "-02"), (67.9, Properties.Resources.Worker + "-08"), (345, Properties.Resources.Worker + "-01"), (63.7, Properties.Resources.Worker + "-04"), (17.6, Properties.Resources.Worker + "-03"), (89.1, Properties.Resources.Worker + "-07"), (59.8, Properties.Resources.Worker + "-09"), (87.4, Properties.Resources.Worker + "-01"), (89.2, Properties.Resources.Worker + "-04"), (82.3, Properties.Resources.Worker + "-08"), (12.6, Properties.Resources.Worker + "-05"), (198, Properties.Resources.Worker + "-07"), (25.1, Properties.Resources.Worker + "-03") }).Select(k => k.Item1.ToString() + "\t" + k.Item2).ToArray());
            }
            else if (!distLogNorm)
            {
                e.Observations = String.Join("\r\n", ((new double[] { 77.8, 82.5, 86.1, 77.6, 86.9, 76.7, 88.5, 73.7, 79.3, 86.6 }).Select(z => z.ToString()).ToArray()));
                e.VLE = 85;
            }

            return e;
        }
    }
}
