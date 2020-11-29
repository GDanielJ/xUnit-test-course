using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    public class Names
    {
        public string NickName { get; set; }
        public string MakeFullName(string firstname, string lastname)
        {
            return $"{firstname} {lastname}";
        }
    }
}
