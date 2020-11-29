using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    [Collection("Customer")]
    public class CustomerDetailsTests
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerDetailsTests(CustomerFixture CustomerFixture)
        {
            _customerFixture = CustomerFixture;
        }

        [Fact]
        public void GetFullName_GivenFirstAndLastName_ReturnsFullName()
        {
            var customer = _customerFixture.Cust;
            Assert.Equal("Pelle Persson", customer.GetFullName("Pelle", "Persson"));
        }
    }
}
