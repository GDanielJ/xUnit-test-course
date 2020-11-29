using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordApp
{
    public interface IPasswordValidator
    {
        public bool Validate(string password);
    }
}
