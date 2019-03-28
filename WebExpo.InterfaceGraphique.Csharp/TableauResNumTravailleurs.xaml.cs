using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Controls;

namespace WebExpo.InterfaceGraphique
{
    using Dict = Dictionary<String, double>;
    using Pair1 = KeyValuePair<String, KeyValuePair<int, Object>>;
    using Pair2 = KeyValuePair<int, Object>;
    using ResItem = List<KeyValuePair<String, KeyValuePair<int, Object>>>;
    using ResList= Dictionary<String,List<KeyValuePair<String, KeyValuePair<int, Object>>>>;

    public partial class TableauResNumTravailleurs : Window
    {
        private IList<String> workerIds;
        private ResList resList;

        public TableauResNumTravailleurs(ResList rl)
        {
            resList = rl;
            workerIds = rl.Keys.ToArray();
            InitializeComponent();
            WorkerShown.ItemsSource = workerIds;
            WorkerShown.SelectedIndex = 0;

            WorkerShown_SelectionChanged(WorkerShown);
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink l = sender as Hyperlink;
            string fileUrl = l.NavigateUri.ToString();
            System.Diagnostics.Process.Start(fileUrl);
        }

        private void WorkerShown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e = null)
        {
            String val = "";

            TextBlock textBlock1 = new TextBlock();
            textBlock1.Inlines.Add(new Bold(new Run(Properties.Resources.NumRes + " (" + Properties.Resources.WorkerC + " : ")));
            Bold b2 = new Bold(new Italic(new Run(WorkerShown.SelectedValue as String)));
            b2.Foreground = Brushes.Red;
            textBlock1.Inlines.Add(b2);
            textBlock1.Inlines.Add(new Bold(new Run(")")));
            textBlock1.FontSize = 20;
            
            BlockUIContainer uic = new BlockUIContainer(textBlock1);

            TableCell tc = new TableCell(uic);
            tc.ColumnSpan = 2;
            tc.TextAlignment = TextAlignment.Center;
            TableRow heading = new TableRow();
            heading.Background = Brushes.SkyBlue;
            heading.Cells.Add(tc);
            TableRowGroup rg = new TableRowGroup();
            rg.Rows.Add(heading);

            foreach (Pair1 p in resList[WorkerShown.SelectedValue as String])
            {
                String lbl = p.Key;
                Pair2 p2 = p.Value;
                bool isFileLink = false;

                if (p2.Key == 0)
                {
                    val = MainWindow.ShowDouble(p2.Value);
                }
                else if (p2.Key == 2)
                {
                    val = p2.Value.ToString();
                    isFileLink = true;
                }
                else
                {
                    Dict dict = p2.Value as Dict;
                    bool ok = false;
                    try
                    {
                        ok = dict.TryGetValue("est", out double v);
                        ok = dict.TryGetValue("lcl", out double v1);
                        ok = dict.TryGetValue("ucl", out double v2);
                        val = MainWindow.ShowDouble(v) + " [" + MainWindow.ShowDouble(v1) + " - " + MainWindow.ShowDouble(v2) + "]";
                    }
                    catch (ArgumentNullException)
                    {

                    }
                }

                TableRow tr = new TableRow();
                tr.Cells.Add(new TableCell(new Paragraph(new Run(lbl))));
                Run run2 = new Run(val);
                if (isFileLink)
                {
                    Hyperlink fileLink = new Hyperlink(run2);
                    fileLink.Click += openFile_Click;
                    fileLink.NavigateUri = new Uri(val);
                    tr.Cells.Add(new TableCell(new Paragraph(fileLink)));
                }
                else
                {
                    tr.Cells.Add(new TableCell(new Paragraph(run2)));
                }
                rg.Rows.Add(tr);
            }
            tableauResultats.RowGroups[0] = rg;
        }
    }
}
