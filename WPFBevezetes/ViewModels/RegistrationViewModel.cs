using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;

namespace WPFBevezetes.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        string _username;
        public string Username 
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); } 
        }

        string _email;
        public string Email 
        {
            get { return _email;  } 
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        SecureString _password;
        public SecureString Password 
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        SecureString _confirmPassword;
        public SecureString ConfirmPassword 
        { 
            get { return _confirmPassword; }
            set { _confirmPassword = value; OnPropertyChanged(nameof(ConfirmPassword)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string callerName = null) =>
            PropertyChanged?.Invoke(this, null);
    }
}
