using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace AutoReservation.Ui
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SetupCulture();
            InitializeComponent();
            
        }

        private void SetupCulture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-CH");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-CH");

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentUICulture.IetfLanguageTag)));
        }
    }
}
