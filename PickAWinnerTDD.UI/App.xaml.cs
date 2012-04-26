﻿using System.Windows;

namespace PickAWinnerTDD.UI {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            StructureMapBootstrapper.BootstrapStructureMap();
        }
    }
}