using System.Windows;
using WPFBevezetes.ViewModels;

namespace WPFBevezetes.Views
{
    public partial class RegistrationWindow : Window
    {

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((DataContext as RegistrationViewModel).Username);
        }
    }
}
