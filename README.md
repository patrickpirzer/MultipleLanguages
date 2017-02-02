# MultipleLanguages

This solution was an experiment for switching between multiple languages in a WPF-application.
My first attempt (-> project "MultipleLanguages") was using *.resx-files as resource dictionaries.
According to the initial selected language the texts in the GUI appear in that language.
But after switching to another language just the current culture of the thread changed but nothing happened in the GUI.

So i made my second attempt on the base of this article:
http://blogs.microsoft.co.il/tomershamam/2007/10/30/wpf-localization-on-the-fly-language-selection/

The result are the class library "Localization" which takes the job of converting texts and the WPF-project "MultipleLanguagesLogTranslate" for test purposes.
When the user changes the language at runtime, all texts in the mainwindow as well as in all subwindows - opened by the mainwindow - will be translated all at once.
