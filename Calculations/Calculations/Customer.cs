using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculations
{
    public class Customer
    {
        public string Name => "Pelle";
        public int Age => 35;

        public int GetOrdersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name is null");

            return 100;
        }

        public string GetFullName(string FirstName, string LastName)
        {
            return $"{FirstName} {LastName}";
        }
    }

    public class LoyalCustomer : Customer
    {
        public int Discount { get; set; }

        public LoyalCustomer()
        {
            Discount = 10;
        }
    }

    public static class CustomerFactory
    {
        public static Customer CreateCustomerInstance(int orderCount)
        {
            if (orderCount <= 100)
                return new Customer();
            else
                return new LoyalCustomer();
        }
    }
}
