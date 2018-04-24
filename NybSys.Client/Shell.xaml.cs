using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using NybSys.Infrastructure;
using System;
using System.ComponentModel.Composition;
using System.Windows;

namespace NybSys.Client
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    [Export]
    public partial class Shell : Window, IPartImportsSatisfiedNotification
    {
        private const string ProfileModuleName = "ProfileModule";
        private static Uri InboxViewUri = new Uri("/CreateProfile", UriKind.Relative);
        public Shell()
        {
            InitializeComponent();
        }
        
        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;

        public void OnImportsSatisfied()
        {
            this.ModuleManager.LoadModuleCompleted +=
             (s, e) =>
             {
                 if (e.ModuleInfo.ModuleName == ProfileModuleName)
                 {
                     this.RegionManager.RequestNavigate(
                         RegionNames.MainContentRegion,
                         InboxViewUri);
                 }
             };
        }
    }
}
