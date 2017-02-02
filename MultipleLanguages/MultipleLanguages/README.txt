Dieses Projekt war ein Test für Mehrsprachigkeit in WPF-Anwendungen mit Hilfe von RESX-ResourceDictionaries.
Im Gegensatz zu XAML-ResourceDictionaries gibt es hierbei allerdings ein Problem, wenn man von einer Sprache zu einer anderen wechseln möchte.
Die CurrentCulture des Threads wird zwar umgestellt, aber die GUI reagiert nicht darauf.