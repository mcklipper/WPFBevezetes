using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using WPFBevezetes.Validators;

namespace WPFBevezetes.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        string _username;
        [Required]
        [StringLength(50)]
        public string Username 
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); } 
        }

        string _email;
        [Required]
        [EmailAddress]
        public string Email 
        {
            get { return _email;  } 
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        SecureString _password;
        [Required]
        [PasswordLength(8, ErrorMessage = "Password should be at least 8 characters!")]
        [PasswordContainsUppercase(ErrorMessage = "Password should contain upper case letter!")]
        [PasswordContainsNumber(ErrorMessage = "Password should contain number!")]
        public SecureString Password 
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        SecureString _confirmPassword;
        [Required]
        [ConfirmPassword(nameof(Password))]
        public SecureString ConfirmPassword 
        { 
            get { return _confirmPassword; }
            set { _confirmPassword = value; OnPropertyChanged(nameof(ConfirmPassword)); }
        }


        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                List<ValidationResult> results = new();
                var property = GetType().GetProperty(columnName).GetValue(this);

                if (Validator.TryValidateProperty(property, new(this) { MemberName = columnName}, results))
                    return null;

                return results.First().ErrorMessage;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string callerName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
    }
}
