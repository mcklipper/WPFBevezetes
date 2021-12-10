using System.ComponentModel.DataAnnotations;
using System.Security;

namespace WPFBevezetes.Validators
{
    public class PasswordLengthAttribute : ValidationAttribute
    {
        private readonly int _minLength;

        public PasswordLengthAttribute(int minLength)
        {
            _minLength = minLength;
        }

        public override bool IsValid(object value)
        {
            return (value as SecureString).Length >= _minLength;
        }
    }
}
