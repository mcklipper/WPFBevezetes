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

        public ApplicationDbContext Context { get; set; }

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

            Context = new();
        }

        private void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            Context.Users.Add(new()
            {
                UserName = Model.Username,
                Email = Model.Email,
                PasswordHash = pbPassword.Password
            });

            Context.SaveChanges();
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
