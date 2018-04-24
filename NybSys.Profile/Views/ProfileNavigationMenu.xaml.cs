using Microsoft.Practices.Prism.Regions;
using NybSys.Infrastructure;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;

namespace NybSys.Profile.Views
{
    /// <summary>
    /// Interaction logic for ProfileNavigationMenu.xaml
    /// </summary>
    [Export]
    public partial class ProfileNavigationMenu : UserControl
    {
        private static Uri profileUri = new Uri("/CreateProfile", UriKind.Relative);
        public ProfileNavigationMenu()
        {
            InitializeComponent();
        }
        [Import]
        public IRegionManager regionManager;

        private void NavigateToProfileRadioButton_Click(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, profileUri);
        }

        private void MainContentRegion_Navigated(object sender, RegionNavigationEventArgs e)
        {
            this.UpdateNavigationButtonState(e.Uri);
        }

        private void UpdateNavigationButtonState(Uri uri)
        {
            this.NavigateToProfileRadioButton.IsChecked = (uri == profileUri);
        }

        public void OnImportsSatisfied()
        {
            IRegion mainContentRegion = this.regionManager.Regions[RegionNames.MainContentRegion];
            if (mainContentRegion != null && mainContentRegion.NavigationService != null)
            {
                mainContentRegion.NavigationService.Navigated += this.MainContentRegion_Navigated;
            }
        }
        
    }
}
