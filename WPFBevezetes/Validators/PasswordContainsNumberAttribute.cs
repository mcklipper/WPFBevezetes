using System;
using System.ComponentModel.DataAnnotations;
using System.Security;
using System.Text.RegularExpressions;
using WPFBevezetes.Security;

namespace WPFBevezetes.Validators
{
    public class PasswordContainsNumberAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            return (value as SecureString).Check(bytes => Array.Exists(bytes, b => Regex.IsMatch(((char)b).ToString(), @"[0-9]")));
        }
    }
}
