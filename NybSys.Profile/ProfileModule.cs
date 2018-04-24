using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using NybSys.Infrastructure;
using NybSys.Profile.Views;

namespace NybSys.Profile
{
    [ModuleExport(typeof(ProfileModule))]
    public class ProfileModule : IModule
    {
        [Import]
        public IRegionManager regionManager;

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion, typeof(ProfileNavigationMenu));
            this.regionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion, typeof(ProfileViewNavigationMenu));
        }
    }
}
