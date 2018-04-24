using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NybSys.Profile.Views
{
    /// <summary>
    /// Interaction logic for ViewProfile.xaml
    /// </summary>
    [Export("ViewProfile")]
    public partial class ViewProfile : UserControl
    {
        public ViewProfile()
        {
            InitializeComponent();
        }
    }
}
