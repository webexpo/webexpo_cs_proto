using System;
using System.IO;
using System.Windows;
using Zygotine.Statistics;
using Zygotine.Statistics.Distribution;
using System.Collections.Generic;

namespace WebExpo.InterfaceGraphique
{
    using Dict = Dictionary<String, double>;
    using Pair1 = KeyValuePair<String, KeyValuePair<int, Object>>;
    using Pair2 = KeyValuePair<int, Object>;
    using ResItem = List<KeyValuePair<String, KeyValuePair<int, Object>>>;   // List<stat_desc, KeyValuePair<res_type, res>>
    using ResList = Dictionary<String, List<KeyValuePair<String, KeyValuePair<int, Object>>>>;

    class ResultatsNumeriques
    {
        public double[] MuChain { get; set; }
        public double[] SigmaChain { get; set; } // or SigmaBetweenChain
        public double[] SigmaWithinChain { get; set; }
        private Dictionary<String, double[]> BurninChains = null;
        public Dictionary<String, double[]> MuWorkerChains;
        public double ProbCred { get; set; }
        public double Oel { get; set; }
        public double TargetPerc { get; set; }
        public double FracThreshold{ get; set; }
        public double OverexposureRiskThreshold { get; set; }
        public double WithinWorkerCorrelationThreshold { get; set; }
        public double RbRatioCoverage { get; set; }
        public double IndivOverexpoProbThreshold { get; set; }
        public bool DistributionLogNormale { get; set; }
        private bool SEGModel { get; set; }
        private String CsvSep { get; set; } = ";";
        
        public ResultatsNumeriques(double[] muChain, double[] sigmaChain, Entrees e, bool distri_log_normal = true, Dictionary<String, double[]> burninChains = null, String csvSep = "", double[] sigmaWithinChain = null, Dictionary<String, double[]> muWorkerChains = null)
        {
            MuChain = muChain;
            SigmaChain = sigmaChain;
            SigmaWithinChain = sigmaWithinChain;
            MuWorkerChains = muWorkerChains;
           ProbCred = e.ProbCred;
            Oel = e.VLE;
            FracThreshold = e.FracDepassementLimite;
            TargetPerc = e.CentileCritique;
            OverexposureRiskThreshold = e.SeuilRisqueSurexpo;
            WithinWorkerCorrelationThreshold = e.SeuilCorrelationIntraTravailleur;
            RbRatioCoverage = e.CouvertureRatioRb;
            IndivOverexpoProbThreshold = e.SeuilProbSurexpoIndiv;

            DistributionLogNormale = distri_log_normal;
            SEGModel = sigmaWithinChain == null;

            BurninChains = burninChains;
            CsvSep = csvSep;
        }

        public Dict gm(string wid = null) {
            double[] chain = new double[MuChain.Length];

            for (int i = 0; i < MuChain.Length; i++)
            {
                double k = (wid == null ? MuChain : MuWorkerChains[wid])[i];
                chain[i] = DistributionLogNormale ? Math.Exp(k) : k;
            }

            return median(chain);
        }

        public Dict gsd(bool useOtherSigmaChain = false)
        {
            double[] sigmaChainRef = useOtherSigmaChain ? SigmaWithinChain : SigmaChain;
            double[] chain = new double[sigmaChainRef.Length];

            for (int i = 0; i < sigmaChainRef.Length; i++)
            {
                double k = sigmaChainRef[i];
                chain[i] = DistributionLogNormale ? Math.Exp(k) : k;
            }

            return median(chain);
        }

        public Dict gsdw()
        {
            return gsd(true);
        }

        public Dict frac(string wid = null)
        {
            double[] muChainRef = wid == null ? MuChain : MuWorkerChains[wid];
            double[] sigmaChainRef = wid == null ? SigmaChain : SigmaWithinChain;
            double[] chain = new double[muChainRef.Length];
            for ( int i = 0; i < muChainRef.Length; i++ )
            {
                chain[i] = 100 * (1 - NormalDistribution.PNorm(((DistributionLogNormale ? Math.Log(Oel) : Oel) - muChainRef[i]) / sigmaChainRef[i]));
            }

            return median(chain);
        }

        public Dict perc(string wid = null)
        {
            double[] muChainRef = wid == null ? MuChain : MuWorkerChains[wid];
            double[] sigmaChainRef = wid == null ? SigmaChain : SigmaWithinChain;
            double[] chain = new double[muChainRef.Length];
            for (int i = 0; i < MuChain.Length; i++)
            {
                double k = muChainRef[i] + NormalDistribution.QNorm(TargetPerc / 100) * sigmaChainRef[i];
                chain[i] = DistributionLogNormale ? Math.Exp(k) : k;
            }

            return median(chain);
        }

        public Dict am(string wid = null)
        {
            double[] muChainRef = wid == null ? MuChain : MuWorkerChains[wid];
            double[] sigmaChainRef = wid == null ? SigmaChain : SigmaWithinChain;
            double[] chain = new double[muChainRef.Length];

            for (int i = 0; i < muChainRef.Length; i++)
            {
                chain[i] = DistributionLogNormale ? Math.Exp(muChainRef[i] + 0.5 * Math.Pow(sigmaChainRef[i],2)) : muChainRef[i];
            }

            return median(chain);
        }

        public Dict rho()
        {
            double[] chain = new double[SigmaChain.Length];
            for (int i = 0; i < SigmaChain.Length; i++)
            {
                chain[i] = Math.Pow(SigmaChain[i], 2) / (Math.Pow(SigmaChain[i], 2) + Math.Pow(SigmaWithinChain[i], 2));
            }

            return median(chain);
        }

        public double probRhoOverX()
        {
            double[] chain = new double[SigmaChain.Length];
            int count = 0;

            for (int i = 0; i < SigmaChain.Length; i++)
            {
                chain[i] = Math.Pow(SigmaChain[i], 2) / (Math.Pow(SigmaChain[i], 2) + Math.Pow(SigmaWithinChain[i], 2));
                count += chain[i] > WithinWorkerCorrelationThreshold ? 1 : 0;
            }

            double probOver = (double)100 * count / (double)chain.Length;
            return probOver;
        }

        public Dict Rratio()
        {
            double[] chain = new double[SigmaChain.Length];
            for (int i = 0; i < SigmaChain.Length; i++)
            {
                chain[i] = Math.Exp(2 * NormalDistribution.QNorm(1 - (100 - RbRatioCoverage) / 200) * SigmaChain[i]);
            }

            return median(chain);
        }

        public Dict Rdiff()
        {
            double[] chain = new double[MuChain.Length];
            double groupMean = median(MuChain)["est"];

            for (int i = 0; i < MuChain.Length; i++)
            {
                chain[i] = 200 * NormalDistribution.QNorm(1 - (100 - RbRatioCoverage) / 200) * SigmaChain[i] / groupMean;
            }

            return median(chain);
        }

        public double probRRatioOverX(double X)
        {
            double[] chain = new double[SigmaChain.Length];
            int count = 0;

            for (int i = 0; i < SigmaChain.Length; i++)
            {
                chain[i] = Math.Exp(2 * NormalDistribution.QNorm(1 - (100 - RbRatioCoverage) / 200) * SigmaChain[i]);
                count += chain[i] > X ? 1 : 0;
            }

            double probOver = (double)100 * count / (double)chain.Length;
            return probOver;
        }

        public Dict probIndOverexpoPerc()
        {
            double[] chain = new double[SigmaChain.Length];

            for (int i = 0; i < SigmaChain.Length; i++)
            {
                chain[i] = 100 * (1 - NormalDistribution.PNorm(((DistributionLogNormale ? Math.Log((Oel)) : Oel) - MuChain[i] - NormalDistribution.QNorm(TargetPerc / 100) * SigmaWithinChain[i]) / SigmaChain[i]));
            }

            return median(chain);
        }

        public double probIndOverexpoPercOverX()
        {
            double[] chain = new double[SigmaChain.Length];
            int count = 0;

            for (int i = 0; i < SigmaChain.Length; i++)
            {
                chain[i] = 100 * (1 - NormalDistribution.PNorm((( DistributionLogNormale ? Math.Log(Oel) : Oel ) - MuChain[i] - NormalDistribution.QNorm(TargetPerc / 100) * SigmaWithinChain[i]) / SigmaChain[i]));
                count += chain[i] > IndivOverexpoProbThreshold ? 1 : 0;
            }

            double probOver = (double)100 * count / (double)chain.Length;
            return probOver;
        }

        public Dict probIndOverexpoAM()
        {
            double[] chain = new double[SigmaChain.Length];

            for (int i = 0; i < SigmaChain.Length; i++)
            {
                chain[i] = 100 * (1 - NormalDistribution.PNorm(((DistributionLogNormale ? (Math.Log(Oel) - 0.5 * Math.Pow(SigmaWithinChain[i], 2)) : Oel) - MuChain[i]) / SigmaChain[i]));
            }

            return median(chain);
        }

        // chain <- 100 * ( 1 - pnorm( ( log( ( oel ) ) - mu.overall - 0.5 * sigma.within^2 ) / sigma.between ) )
        // chain <- 100 * ( 1 - pnorm( (        oel     - mu.overall                        ) / sigma.between ) )
        public double probIndOverexpoAMOverX()
        {
            double[] chain = new double[SigmaChain.Length];
            int count = 0;

            for (int i = 0; i < SigmaChain.Length; i++)
            {
                double pn = DistributionLogNormale ? Math.Log(Oel) - 0.5 * Math.Pow(SigmaWithinChain[i], 2) : Oel;
                chain[i] = chain[i] = 100 * (1 - NormalDistribution.PNorm((pn - MuChain[i]) / SigmaChain[i]));
                count += chain[i] > IndivOverexpoProbThreshold ? 1 : 0;
            }

            double probOver = (double)100 * count / (double)chain.Length;
            return probOver;
        }

        public double frac_risk(string wid = null)
        {
            double[] muChainRef = wid == null ? MuChain : MuWorkerChains[wid];
            double[] sigmaChainRef = wid == null ? SigmaChain : SigmaWithinChain;
            double[] chain = new double[muChainRef.Length];
            int count = 0;
            for (int i = 0; i < muChainRef.Length; i++)
            {
                chain[i] = 100 * (1 - NormalDistribution.PNorm(((DistributionLogNormale ? Math.Log(Oel) : Oel) - muChainRef[i]) / sigmaChainRef[i]));
                count += chain[i] > FracThreshold ? 1 : 0;
            }
            double risk = (double) 100 * count / (double) chain.Length;
            return risk;
        }

        public double perc_risk(string wid = null)
        {
            double[] muChainRef = wid == null ? MuChain : MuWorkerChains[wid];
            double[] sigmaChainRef = wid == null ? SigmaChain : SigmaWithinChain;
            double[] chain = new double[muChainRef.Length];
            int count = 0;
            for (int i = 0; i < muChainRef.Length; i++)
            {
                double k = muChainRef[i] + NormalDistribution.QNorm(TargetPerc / 100) * sigmaChainRef[i];
                chain[i] = DistributionLogNormale ? Math.Exp(k) : k;
                count += chain[i] > Oel ? 1 : 0;
            }

            double risk = (double) 100 * count / (double) chain.Length;
            return risk;
        }

        public double am_risk(string wid = null)
        {
            double[] muChainRef = wid == null ? MuChain : MuWorkerChains[wid];
            double[] sigmaChainRef = wid == null ? SigmaChain : SigmaWithinChain;
            double[] chain = new double[muChainRef.Length];
            int count = 0;
            for (int i = 0; i < muChainRef.Length; i++)
            {
                double k = muChainRef[i] + 0.5 * sigmaChainRef[i] * sigmaChainRef[i];
                chain[i] = DistributionLogNormale ? Math.Exp(k) : k;
                count += chain[i] > Oel ? 1 : 0;
            }

            double risk = (double) 100 * count / (double) chain.Length;
            return risk;
        }

        public ResList allResults()
        {
            ResItem resElem = new ResItem();
            ResList allR = new ResList();

            Pair2 moyG = new Pair2(1, gm());
            Pair2 moyA = new Pair2(1, am());
            Pair2 moyARisk = new Pair2(0, am_risk());
            Pair2 ec = new Pair2(1, gsd());
            Pair2 fracD = new Pair2(1, frac());
            Pair2 fracDRisk = new Pair2(0, frac_risk());
            Pair2 cc = new Pair2(1, perc());
            Pair2 ccRisk = new Pair2(0, perc_risk());

            if (SEGModel)
            {
                if (DistributionLogNormale)
                {
                    resElem.Add(new Pair1(Properties.Resources.GeomMean, moyG));
                    resElem.Add(new Pair1(Properties.Resources.GeomSD, ec));
                    resElem.Add(new Pair1(Properties.Resources.Exceedance + " (%)", fracD));
                    resElem.Add(new Pair1(Properties.Resources.Exceedance + " - " + Properties.Resources.OverExpoRiskPerc, fracDRisk));
                    resElem.Add(new Pair1(Properties.Resources.CritPercentile, cc));
                    resElem.Add(new Pair1(Properties.Resources.CritPercentile + " - " + Properties.Resources.OverExpoRiskPerc, ccRisk));
                    resElem.Add(new Pair1(Properties.Resources.ArithMean, moyA));
                    resElem.Add(new Pair1(Properties.Resources.ArithMean + " - " + Properties.Resources.OverExpoRiskPerc, moyARisk));
                }
                else
                {
                    resElem.Add(new Pair1(Properties.Resources.ArithMean, moyA));
                    resElem.Add(new Pair1(Properties.Resources.ArithSD, ec));
                    resElem.Add(new Pair1(Properties.Resources.ArithMean + " - " + Properties.Resources.OverExpoRiskPerc, moyARisk));
                    resElem.Add(new Pair1(Properties.Resources.Exceedance + " (%)", fracD));
                    resElem.Add(new Pair1(Properties.Resources.Exceedance + " - " + Properties.Resources.OverExpoRiskPerc, fracDRisk));
                    resElem.Add(new Pair1(Properties.Resources.CritPercentile, cc));
                    resElem.Add(new Pair1(Properties.Resources.CritPercentile + " - " + Properties.Resources.OverExpoRiskPerc, ccRisk));
                }
                resElem.Add(new Pair1(Properties.Resources.MarcovChainsCSV, new Pair2(2, dumpChainesMarkov())));

                if ( BurninChains.Count > 0 )
                {
                    resElem.Add(new Pair1(Properties.Resources.BurnInChainsCSV, new Pair2(2, dumpChainesMarkov(true))));
                }
                allR.Add("RES", resElem);
            }
            else
            {
                if (MuWorkerChains == null)
                {
                    Pair2 ec2 = new Pair2(1, gsd(true));
                    Pair2 rhoo = new Pair2(1, rho());
                    Pair2 probRhoOva = new Pair2(0, probRhoOverX());
                    Pair2 rratio = new Pair2(1, Rratio());

                    if (DistributionLogNormale)
                    {
                        resElem.Add(new Pair1(Properties.Resources.GroupGeomMean, moyG));
                        resElem.Add(new Pair1(Properties.Resources.GeomSD + "(" + Properties.Resources.BetweenWorkers + ")", ec));
                        resElem.Add(new Pair1(Properties.Resources.GeomSD + "(" + Properties.Resources.WithinWorkers + ")", ec2));
                        resElem.Add(new Pair1("rho", rhoo));
                        resElem.Add(new Pair1("Prob.rho." + Properties.Resources.ProbGreaterThan + "X(%)", probRhoOva));
                        resElem.Add(new Pair1("R.ratio", rratio));
                        resElem.Add(new Pair1("Prob.R." + Properties.Resources.ProbGreaterThan + ".2 (%)", new Pair2(0, probRRatioOverX(2))));
                        resElem.Add(new Pair1("Prob.R." + Properties.Resources.ProbGreaterThan + ".10 (%)", new Pair2(0, probRRatioOverX(10))));
                    }
                    else
                    {
                        resElem.Add(new Pair1(Properties.Resources.GroupArithMean, moyG));
                        resElem.Add(new Pair1(Properties.Resources.ArithSD + "(" + Properties.Resources.BetweenWorkers + ")", ec));
                        resElem.Add(new Pair1(Properties.Resources.ArithSD + "(" + Properties.Resources.BetweenWorkers + ")", ec2));
                        resElem.Add(new Pair1("rho", rhoo));
                        resElem.Add(new Pair1("Prob.rho." + Properties.Resources.ProbGreaterThan + "X (%)", probRhoOva));
                        resElem.Add(new Pair1("R.diff", new Pair2(1, Rdiff())));
                    }

                    resElem.Add(new Pair1("Prob.ind." + Properties.Resources.OverExpo + ".perc", new Pair2(1, probIndOverexpoPerc())));
                    resElem.Add(new Pair1("Prob.ind." + Properties.Resources.OverExpo + ".perc." + Properties.Resources.ProbGreaterThan + "X (%)", new Pair2(0, probIndOverexpoPercOverX())));
                    resElem.Add(new Pair1("Prob.ind." + Properties.Resources.OverExpo + ".am", new Pair2(1, probIndOverexpoAM())));
                    resElem.Add(new Pair1("Prob.ind." + Properties.Resources.OverExpo + ".am." + Properties.Resources.ProbGreaterThan + "X (%)", new Pair2(0, probIndOverexpoAMOverX())));
                    resElem.Add(new Pair1(Properties.Resources.MarcovChainsCSV, new Pair2(2, dumpChainesMarkov())));
                    if (BurninChains.Count > 0)
                    {
                        resElem.Add(new Pair1(Properties.Resources.BurnInChainsCSV, new Pair2(2, dumpChainesMarkov(true))));
                    }
                    allR.Add("RES", resElem);
                }
                else
                {
                    foreach (string wid in MuWorkerChains.Keys)
                    {
                        ResItem riWorker = new ResItem();
                        if (DistributionLogNormale)
                        {
                            riWorker.Add(new Pair1(Properties.Resources.GeomMean, new Pair2(1, gm(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.GeomSD, new Pair2(1, gsdw())));
                            riWorker.Add(new Pair1(Properties.Resources.Exceedance, new Pair2(1, frac(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.Exceedance + " - " + Properties.Resources.OverExpoRiskPerc, new Pair2(0, frac_risk(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.CritPercentile, new Pair2(1, perc(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.CritPercentile + " - " + Properties.Resources.OverExpoRiskPerc, new Pair2(0, perc_risk(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.ArithMean, new Pair2(1, am(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.ArithMean + " - " + Properties.Resources.OverExpoRiskPerc, new Pair2(0, am_risk(wid))));
                        }
                        else
                        {
                            riWorker.Add(new Pair1(Properties.Resources.ArithMean, new Pair2(1, gm(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.ArithSD, new Pair2(1, gsdw())));
                            riWorker.Add(new Pair1(Properties.Resources.ArithMean + " - " + Properties.Resources.OverExpoRiskPerc, new Pair2(0, am_risk(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.Exceedance, new Pair2(1, frac(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.Exceedance + " - " + Properties.Resources.OverExpoRiskPerc, new Pair2(0, frac_risk(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.CritPercentile, new Pair2(1, perc(wid))));
                            riWorker.Add(new Pair1(Properties.Resources.CritPercentile + " - " + Properties.Resources.OverExpoRiskPerc, new Pair2(0, perc_risk(wid))));
                        }

                        riWorker.Add(new Pair1(Properties.Resources.MarcovChainsCSV, new Pair2(2, dumpChainesMarkov(false, wid))));
                        allR.Add(wid, riWorker);
                    }
                }
            }

            return allR;
        }

        public TableauResultats showResults()
        {
            return new TableauResultats();
        }

        public class TableauResultats : Window
        {

        }

        private Dict median(double[] chaine )
        {
            return median(chaine, ProbCred);
        }

        private Dict median(double[] chaine, double conf )
        {
            Array.Sort(chaine);
            var med = new Dict();
            double est = chaine[chaine.Length / 2];
            double lcl = new Quantile((100 - conf) / 200).Compute(chaine)[0];
            double ucl = new Quantile(1 - (100 - conf) / 200).Compute(chaine)[0];
            med.Add("est", est);
            med.Add("lcl", lcl);
            med.Add("ucl", ucl);
            return med;
        }

        private string dumpChainesMarkov(bool dumpBurnin = false, string wid = null)
        {
            string tempDir = Path.GetTempPath();
            string webexpoDir = tempDir + @"sortieWebexpo\";
            if ( !Directory.Exists(webexpoDir) )
            {
                Directory.CreateDirectory(webexpoDir);
            }
            double[] muCha = dumpBurnin ? BurninChains["muBurnin"] : MuChain;
            double[] sigCha = dumpBurnin ? BurninChains["sigmaBurnin"] : SigmaChain;
            double[] sigWCha = dumpBurnin && !SEGModel ? BurninChains["sigma2Burnin"] : SigmaWithinChain;

            string muChainDesc = SEGModel ? "mu" : "muOverall";
            string sigmaChainDesc = SEGModel ? "sigma" : "sigmaBetween";
            string sigmaWChainDesc = SEGModel ? "" : "sigmaWithin";
            if (MuWorkerChains != null && wid != null)
            {
                muCha = MuWorkerChains[wid];
                muChainDesc = "muWorker{" + wid + "}";
            } else
            if ( dumpBurnin )
            {
                muChainDesc += "Burnin";
                sigmaChainDesc += "Burnin";
                sigmaWChainDesc += "Burnin";
            }

            string outFile = webexpoDir + "chaines-" + ( dumpBurnin ? "burnin" : "markov") + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".csv";
            
            using (StreamWriter file = new StreamWriter(outFile))
            {
                string[] headings = SEGModel ? new string[] { muChainDesc, sigmaChainDesc } : new string[] { muChainDesc, sigmaChainDesc, sigmaWChainDesc };
                file.WriteLine(String.Join(CsvSep, headings));

                for (int i = 0; i < muCha.Length; i++)
                {
                    String line = String.Join(CsvSep, new string[] { MainWindow.ShowDouble(muCha[i]), MainWindow.ShowDouble(sigCha[i]) }) + (!SEGModel ? (CsvSep + MainWindow.ShowDouble(sigWCha[i])) : "");
                    file.WriteLine(line);
                }
            }

            return outFile;
        }

        private FileInfo CreateTmpFile()
        {
            string fileName = string.Empty;
            FileInfo fileInfo = null;

            try
            {
                // Get the full name of the newly created Temporary file. 
                // Note that the GetTempFileName() method actually creates
                // a 0-byte file and returns the name of the created file.
                fileName = Path.GetTempFileName();

                // Craete a FileInfo object to set the file's attributes
                fileInfo = new FileInfo(fileName);

                // Set the Attribute property of this file to Temporary. 
                // Although this is not completely necessary, the .NET Framework is able 
                // to optimize the use of Temporary files by keeping them cached in memory.
                fileInfo.Attributes = FileAttributes.Temporary;

                Console.WriteLine("TEMP file created at: " + fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to create TEMP file or set its attributes: " + ex.Message);
            }

            return fileInfo;
        }
    }
}
