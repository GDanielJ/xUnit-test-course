using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordApp
{
    public class DefaultPasswordValidator : IPasswordValidator
    {
        public bool Validate(string password)
        {
            if (password.Length < 8) return false;
            if (!password.Any(x => char.IsUpper(x))) return false;

            return true;
        }
    }
}
