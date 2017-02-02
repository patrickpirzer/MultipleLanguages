using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MultipleLanguages
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public App()
        {
            // Sets the desired language.
            ChangeLanguage("de-DE");
        }

        /// <summary>
        /// Switches to language german.
        /// </summary>
        public void SwitchToLanguageGerman()
        {
            ChangeLanguage("de-DE");
        }

        /// <summary>
        /// Switches to language english.
        /// </summary>
        public void SwitchToLanguageEnglish()
        {
            ChangeLanguage("en-US");
        }

        /// <summary>
        /// Changes the language according to the given culture.
        /// </summary>
        /// <param name="culture">The culture.</param>
        private void ChangeLanguage(string culture)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            MultipleLanguages.Properties.Resources.Culture = new CultureInfo(culture);
        }

    }
}
