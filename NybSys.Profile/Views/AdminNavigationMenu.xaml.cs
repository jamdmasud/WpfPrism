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
    public partial class AdminNavigationMenu : UserControl
    {
        private static Uri viewProfileUri = new Uri("/ViewProfile", UriKind.Relative);
        public AdminNavigationMenu()
        {
            InitializeComponent();
        }
        [Import]
        public IRegionManager regionManager;
        
        private void MainContentRegion_Navigated(object sender, RegionNavigationEventArgs e)
        {
            this.UpdateNavigationButtonState(e.Uri);
        }

        private void UpdateNavigationButtonState(Uri uri)
        {
            this.NavigateToViewProfileRadioButton.IsChecked = (uri == viewProfileUri);
        }
        public void OnImportsSatisfied()
        {
            IRegion mainContentRegion = this.regionManager.Regions[RegionNames.MainContentRegion];
            if (mainContentRegion != null && mainContentRegion.NavigationService != null)
            {
                mainContentRegion.NavigationService.Navigated += this.MainContentRegion_Navigated;
            }
        }

        private void NavigateToViewProfileRadioButton_Click(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionNames.MainContentRegion, viewProfileUri);
        }
    }
}
