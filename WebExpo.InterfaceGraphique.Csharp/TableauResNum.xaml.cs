using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace WebExpo.InterfaceGraphique
{
    using Dict = Dictionary<String, double>;
    using Pair1 = KeyValuePair<String, KeyValuePair<int, Object>>;
    using Pair2 = KeyValuePair<int, Object>;
    using ResItem = List<KeyValuePair<String, KeyValuePair<int, Object>>>;
    using ResList = Dictionary<String, List<KeyValuePair<String, KeyValuePair<int, Object>>>>;

    public partial class TableauResNum : Window
    {
        public TableauResNum(ResList d)
        {
            String val = "";
            InitializeComponent();

            foreach ( Pair1 p in d["RES"] )
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
                } else {
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
                Run run = new Run(val);
                if (isFileLink)
                {
                    Hyperlink fileLink = new Hyperlink(run);
                    fileLink.Click += openFile_Click;
                    fileLink.NavigateUri = new Uri(val);
                    tr.Cells.Add(new TableCell(new Paragraph(fileLink)));
                }
                else
                {
                    tr.Cells.Add(new TableCell(new Paragraph(run)));
                }
                tableauResultats.RowGroups[0].Rows.Add(tr);
            }
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink l = sender as Hyperlink;
            string fileUrl = l.NavigateUri.ToString();
            System.Diagnostics.Process.Start(fileUrl);
        }
        
    }
}
