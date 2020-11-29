using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Test
{
    [Collection("Customer")]
    public class CustomerTests
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerTests(CustomerFixture CustomerFixture)
        {
            _customerFixture = CustomerFixture;
        }

        [Fact]
        public void CheckNameNotNullorEmpty()
        {
            var customer = _customerFixture.Cust;
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        public void CheckLegitForDiscount()
        {
            var customer = _customerFixture.Cust;
            Assert.InRange(customer.Age, 25, 40);
        }

        [Fact]
        public void GetOrdersByNameNull()
        {
            var customer = _customerFixture.Cust;
            var exceptiondDetails = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
            Assert.Equal("Name is null", exceptiondDetails.Message);
        }

        [Fact]
        public void LoyalCustomerForOrdersGreaterThan100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(101);
            var loyalCustomer = Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, loyalCustomer.Discount);
        }
    }
}
