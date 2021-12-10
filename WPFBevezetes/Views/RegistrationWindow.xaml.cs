using System.Security;
using System.Windows;
using System.Windows.Data;
using WPFBevezetes.ViewModels;

namespace WPFBevezetes.Views
{
    public partial class RegistrationWindow : Window
    {
        public DependencyProperty Password =
            DependencyProperty.RegisterAttached("Password", typeof(SecureString), typeof(RegistrationWindow));

        public DependencyProperty ConfirmPassword =
            DependencyProperty.RegisterAttached("ConfirmPassword", typeof(SecureString), typeof(RegistrationWindow));

        public RegistrationViewModel Model => 
            DataContext as RegistrationViewModel;

        public RegistrationWindow()
        {
            InitializeComponent();

            pbPassword.SetBinding(Password, new Binding(Password.Name)
            {
                Source = Model,
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                ValidatesOnDataErrors = true
            });

            pbConfirmPassword.SetBinding(ConfirmPassword, new Binding(ConfirmPassword.Name)
            {
                Source = Model,
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                ValidatesOnDataErrors = true
            });

        }

        private void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{Model.Username}\n" +
            $"{Model.Email}\n" +
            $"{Model.Password.Length}\n" +
            $"{Model.ConfirmPassword.Length}");
        }

        private void PbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Model.Password = pbPassword.SecurePassword;
        }

        private void PbConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Model.ConfirmPassword = pbConfirmPassword.SecurePassword;
        }
    }
}
