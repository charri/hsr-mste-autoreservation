using System.Globalization;
using System.Threading;
using System.Windows;

namespace AutoReservation.Ui
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-CH");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-CH");

            InitializeComponent();
            
        }
    }
}
