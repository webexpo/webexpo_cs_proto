using System.Windows;
using System.Globalization;

namespace WebExpo.InterfaceGraphique
{
    public partial class App : Application
    {
        public static CultureInfo vCulture { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var lang = "en";
            if ( e.Args.Length == 1 && e.Args[0].Length == 2 )
            {
                lang = e.Args[0].ToLower();
            }
            var region = lang + "-CA";
            vCulture = new CultureInfo(region);
            System.Threading.Thread.CurrentThread.CurrentUICulture = vCulture;
        }
    }
}
