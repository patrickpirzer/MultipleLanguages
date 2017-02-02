using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Localization;
using System.Globalization;

namespace MultipleLanguagesLogTranslate
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Registers the dictionaries while startup of the application.
        /// </summary>
        /// <param name="e">The eventarguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            LanguageDictionary.RegisterDictionary(
                CultureInfo.GetCultureInfo("de-DE"),
                new XmlLanguageDictionary("Languages/de-DE.xml"));

            LanguageDictionary.RegisterDictionary(
                CultureInfo.GetCultureInfo("en-US"),
                new XmlLanguageDictionary("Languages/en-US.xml"));

            LanguageContext.Instance.Culture = CultureInfo.GetCultureInfo("de-DE");

            base.OnStartup(e);
        }

    }
}
