using Microsoft.Practices.Prism.Regions;
using NybSys.Profile.ViewModels; 
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace NybSys.Profile.Views
{
    /// <summary>
    /// Interaction logic for CreateProfile.xaml
    /// </summary>
    [Export("CreateProfile")]
    public partial class CreateProfile : UserControl, INavigationAware
    {
        public CreateProfile()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager regionManager;

        [Import]
        public CreateProfileViewModel ViewModel
        {
            get
            {
                return (CreateProfileViewModel)this.DataContext;
            }
            set
            {
                this.DataContext = value;
            }
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //Intensionally blank
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavigationParameters parameters = navigationContext.Parameters;

            //regionManager.RequestNavigate(ProfileRegionNames.ProfileDetailsRegion, new Uri(profileView, UriKind.Relative));

        }
    }
}
