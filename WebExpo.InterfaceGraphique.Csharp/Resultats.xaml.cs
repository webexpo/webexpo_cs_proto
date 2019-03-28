using System;
using System.Windows;
using Zygotine.WebExpo;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace WebExpo.InterfaceGraphique
{
    using ResList = Dictionary<String, List<KeyValuePair<String, KeyValuePair<int, Object>>>>;

    /// <summary>
    /// Logique d'interaction pour Resultats.xaml
    /// </summary>
    public partial class Resultats : Window
    {
        private ResultatsBarreProg barreProg;

        private bool DistrLogNormal { get; set; }

        private bool SEGModel { get; set; }

        private Entrees entrees;

        private TableauResNum trn = null;

        private TableauResNumTravailleurs trnt = null;

        private BackgroundWorker worker = null;

        public bool Busy { get; set; } = false;

        private bool KeepBurnin = false;

        private string CsvSep = null;

        private int NumHistoClasses { get; set; } = 10;

        public Resultats(Entrees e, Model m, McmcParameters mcmc, Window mw)
        {
            InitializeComponent();
            Reset(e, m);
            KeepBurnin = mcmc.MonitorBurnin;
            CsvSep = mcmc.CsvSeparator;
            NumHistoClasses = mcmc.NumHistoClasses;
            barreProg = new ResultatsBarreProg(this);
            if (mw != null)
            {
                this.Left = mw.Left + mw.Width;
                this.Top = mw.Top;
            }
            Update(e, m);
        }

        public void Reset(Entrees e, Model model)
        {
            entrees = e;
            DistrLogNormal = model.OutcomeIsLogNormallyDistributed;
            SEGModel = model is SEGInformedVarModel || model is SEGUninformativeModel;
        }

        public void Update(Entrees e, Model model, bool showProgress = false)
        {
            if ( model.Valid )
            {
                model.Compute();
                afficherResultats(model.Result, model.ResultParams);
            }
        }

        void afficherResultats(ModelResult res, Object[] extraModelParams = null)
        {
            if (res != null)
            {
                Dictionary<String, double[]> burninChains = new Dictionary<string, double[]>();

                if (SEGModel)
                {
                    double[] muChain = res.GetChainByName("muSample");
                    double[] sigmaChain = res.GetChainByName("sdSample");

                    if (DistrLogNormal)
                    {
                        for (int i = 0; i < muChain.Length; i++)
                        {
                            muChain[i] += Math.Log(entrees.VLE);
                        }

                    }

                    if (KeepBurnin)
                    {
                        double[] muBChain = res.GetChainByName("muBurnin");
                        double[] sigmaBChain = res.GetChainByName("sdBurnin");
                        
                        burninChains.Add("muBurnin", muBChain);
                        burninChains.Add("sigmaBurnin", sigmaBChain);
                    }

                    ResultatsNumeriques rn = new ResultatsNumeriques(muChain, sigmaChain, entrees, DistrLogNormal, burninChains, CsvSep);
                    ResList allResults = rn.allResults();
                    trn = new TableauResNum(allResults);
                    trn.Show();

                    drawHistogram(histoMu, "mu", muChain, NumHistoClasses);
                    drawHistogram(histoSigma, "sigma", sigmaChain, NumHistoClasses);
                    histoSigma2.Visible = false;

                }
                else
                {
                    double[] muOverallChain = res.GetChainByName("muOverallSample");
                    double[] sigmaBetweenChain = res.GetChainByName("sigmaBetweenSample");
                    double[] sigmaWithinChain = res.GetChainByName("sigmaWithinSample");

                    if (KeepBurnin)
                    {
                        double[] muBChain = res.GetChainByName("muOverallBurnin");
                        double[] sigmaBChain = res.GetChainByName("sigmaBetweenBurnin");
                        double[] sigmaWBChain = res.GetChainByName("sigmaWithinBurnin");
                        burninChains.Add("muBurnin", muBChain);
                        burninChains.Add("sigmaBurnin", sigmaBChain);
                        burninChains.Add("sigma2Burnin", sigmaWBChain);
                    }

                    Dictionary<String, double[]> workerMuChains = new Dictionary<string, double[]>();
                    IList<String> workerIds = extraModelParams[0] as IList<String>;

                    foreach (string workerId in workerIds)
                    {
                        string muChainId = "mu_" + workerId + "Sample";
                        workerMuChains.Add(workerId, res.GetChainByName(muChainId));
                    }

                    if (DistrLogNormal)
                    {
                        for (int i = 0; i < muOverallChain.Length; i++)
                        {
                            muOverallChain[i] += Math.Log(entrees.VLE);
                        }

                        foreach (string workerId in workerIds)
                        {
                            for (int i = 0; i < workerMuChains[workerId].Length; i++)
                            {
                                workerMuChains[workerId][i] += Math.Log(entrees.VLE);
                            }
                        }
                    }

                    ResultatsNumeriques rng = new ResultatsNumeriques(muOverallChain, sigmaBetweenChain, entrees, DistrLogNormal, burninChains, CsvSep, sigmaWithinChain);
                    ResList allResults = rng.allResults();
                    trn = new TableauResNum(allResults);
                    trn.Show();

                    ResultatsNumeriques rnw = new ResultatsNumeriques(muOverallChain, sigmaBetweenChain, entrees, DistrLogNormal, burninChains, CsvSep, sigmaWithinChain, workerMuChains);
                    ResList allResultsW = rnw.allResults();
                    trnt = new TableauResNumTravailleurs(allResultsW);
                    trnt.Show();

                    drawHistogram(histoMu, "mu.overall", muOverallChain, NumHistoClasses);
                    drawHistogram(histoSigma, "sigma.between", sigmaBetweenChain, NumHistoClasses);
                    drawHistogram(histoSigma2, "sigma.within", sigmaWithinChain, NumHistoClasses);
                }

                this.WindowState = WindowState.Normal;
                this.Busy = false;
            }
            else
            {
                this.Close();
            }
        }

        private void drawHistogram(Chart chart, String seriesName, double[] chain, int numCateg)
        {
            chart.ChartAreas[0].AxisY.Title = "Total";
            Series series = chart.Series[0];
            series.LegendText = seriesName;

            Array.Sort(chain);

            foreach (Series s in chart.Series)
            {
                s.Points.Clear();
            }

            int[] histoCount = new int[numCateg];
            double[] histoIntervals = new double[numCateg + 1];

            double chainMin = chain[0], chainMax = chain[chain.Length - 1], delta = (chainMax - chainMin) / numCateg;

            Axis chartXAxis = chart.ChartAreas[0].AxisX;
            chartXAxis.Minimum = 0;
            chartXAxis.Maximum = numCateg + 2;
            chartXAxis.Interval = 1;
            chartXAxis.IntervalOffset = -0.5;

            for (int i = 0; i < numCateg; i++)
            {
                histoCount[i] = 0;
                histoIntervals[i] = chainMin + (delta * i);
                if (i > 0)
                {
                    chartXAxis.CustomLabels.Add(i + 0.5, i + 1.5, MainWindow.ShowDouble(histoIntervals[i]));
                }
            }
            histoIntervals[histoIntervals.Length - 1] = chainMax;

            chartXAxis.CustomLabels.Add(-0.5, 0.5, "");
            chartXAxis.CustomLabels.Add(0.5, 1.5, MainWindow.ShowDouble(chainMin) + "\n(min)");
            chartXAxis.CustomLabels.Add(numCateg + 0.5, numCateg + 1.5, MainWindow.ShowDouble(chainMax) + "\n(max)");
            chartXAxis.CustomLabels.Add(numCateg + 1.5, numCateg + 2.5, "");

            for (int i = 0; i < chain.Length; i++)
            {
                ++histoCount[getHistoCategory(chain[i], histoIntervals)];
            }

            for (int i = 0; i < histoCount.Length; i++)
            {
                series.Points.AddXY(i + 1.5, histoCount[i]);
            }

        }
        
        private int getHistoCategory(double val, double[] intervals)
        {
            for ( int i = 0; i < intervals.Length - 1; i++ )
            {
                double lowerLim = intervals[i], upperLim = intervals[i + 1];
                bool lastCategory = i == intervals.Length - 2;
                bool valInThisCategory = val >= lowerLim && ( lastCategory ? val <= upperLim : val < upperLim );
                if ( valInThisCategory )
                {
                    return i;
                }
            }

            return -1;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ( this.trn != null )
            {
                this.trn.Close();
            }

            if (this.trnt != null)
            {
                this.trnt.Close();
            }
        }

        public void Abort()
        {
            if (worker != null)
            {
                worker.CancelAsync();
            }
        }
    }
}
