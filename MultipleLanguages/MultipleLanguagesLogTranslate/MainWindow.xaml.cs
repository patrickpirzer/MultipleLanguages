using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Localization;
using System.Globalization;

namespace MultipleLanguagesLogTranslate
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The constructor of the window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Switches to language german.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_switchtogerman_Click(object sender, RoutedEventArgs e)
        {
            LanguageContext.Instance.Culture = CultureInfo.GetCultureInfo("de-DE");
        }

        /// <summary>
        /// Switches to language english.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_switchtoenglish_Click(object sender, RoutedEventArgs e)
        {
            LanguageContext.Instance.Culture = CultureInfo.GetCultureInfo("en-US");
        }

        /// <summary>
        /// Loads a second window which shall have the same language as the MainWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_loadWindow_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }

        /// <summary>
        /// Gets the uid.
        /// </summary>
        public new int Uid
        {
            get { return 0; }
        }

    }
}
