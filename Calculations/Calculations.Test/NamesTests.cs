using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    public class NamesTests
    {
        //[Fact]
        //public void MakeFullNameTest()
        //{
        //    var names = new Names();
        //    var result = names.MakeFullName("pelle", "persson");
        //    Assert.Equal("Pelle Persson", result, ignoreCase:true);
        //}

        [Fact]
        public void MakeFullNameTest()
        {
            var names = new Names();
            var result = names.MakeFullName("Pelle", "Persson");
            Assert.Contains("Pelle", result);
        }

        [Fact]
        public void NickNameMustBeNull()
        {
            var names = new Names();
            Assert.Null(names.NickName);
        }

        [Fact]
        public void NickNameMustNotBeNull()
        {
            var names = new Names();
            names.NickName = "SSSSS";
            Assert.NotNull(names.NickName);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullName("Pelle", "Persson");
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}
