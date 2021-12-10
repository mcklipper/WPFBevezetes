using System.ComponentModel.DataAnnotations;
using System.Security;
using WPFBevezetes.Security;

namespace WPFBevezetes.Validators
{
    public class ConfirmPasswordAttribute : ValidationAttribute
    {
        private readonly string _propName;

        public ConfirmPasswordAttribute(string propName)
        {
            _propName = propName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            SecureString other = validationContext.ObjectInstance.GetType().GetProperty(_propName).GetValue(validationContext.ObjectInstance) as SecureString;

            if ((value as SecureString).Confirm(other))
                return ValidationResult.Success;

            return new("");
        }
    }
}
