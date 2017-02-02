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
using System.Resources;

namespace MultipleLanguages
{
    /// <summary>
    /// Class for the MainWindow.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// For testing the resource dictionaries.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_testresource_Click(object sender, RoutedEventArgs e)
        {
            // Shows the name of the current culture.
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
            MessageBox.Show("The name of the current culture is '" + ci.Name + "'");

            ////// Shows the text to the resource key "firstname" according to the current culture.
            ////ResourceManager rm1 = new ResourceManager("MultipleLanguages.TextResource1", System.Reflection.Assembly.GetExecutingAssembly());
            ////MessageBox.Show("'firstname' aus MultipleLanguages.TextResource1" + rm1.GetString("firstname"));
            ////ResourceManager rm2 = new ResourceManager("MultipleLanguages.TextResources.TextResource2", System.Reflection.Assembly.GetExecutingAssembly());
            ////MessageBox.Show("'firstname' aus MultipleLanguages.TextResources.TextResource2" + rm2.GetString("firstname"));

            // Shows values to the given names from the resource - according to the current culture, which was set in App.xaml.cs.
            ResourceManager rm = MultipleLanguages.Properties.Resources.ResourceManager;
            MessageBox.Show("firstname : " + rm.GetString("firstname"));
            MessageBox.Show("lastname : " + rm.GetString("lastname"));
        }

        private void btn_switchtogerman_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).SwitchToLanguageGerman();
            UpdateLayout();
        }

        private void btn_switchtoenglish_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).SwitchToLanguageEnglish();
            UpdateLayout();
        }

    }
}
