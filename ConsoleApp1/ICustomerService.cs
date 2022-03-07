using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface ICustomerService
    {
        void AddCustomer(Customer customer);
    }

    public class CustomerService : ICustomerService
    {
        public void AddCustomer(Customer customer)
        {
            ///
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsManager { get; set; }
    }
}
