using NReco.VideoConverter;
using Sp.Selenium;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = "abc@&def* hello ---";
            string input = "---------------";
            Console.WriteLine(input.TrimEnd('-'));
        }

        private static StringCollection CreateStringList()
        {
            StringCollection strings = new StringCollection();
            strings.Add("Shibli");
            strings.Add("Mohammad");
            strings.Add("Arafat");
            strings.Add("David");
            strings.Add("Roman");
            strings.Add("Roman1");
            strings.Add("Roman3");
            strings.Add("Roman2");
            return strings;
        }


        class CustomerController
        {
            private ICustomerBol _CustomerBol;
            private IMailSender _MailSender;

            public CustomerController(ICustomerBol customerBol, IMailSender mailSender)
            {
                _CustomerBol = customerBol;
                _MailSender = mailSender;
            }

            public int AddCustomer(Customer customer)
            {
                CheckManager(customer);
                return _CustomerBol.AddCustomer(customer);
            }

            private void CheckManager(Customer customer)
            {
                if (customer.IsManager)
                {
                    _MailSender.SendMail();
                }
            }
        }       

        interface ICustomerBol
        {
            int AddCustomer(Customer customer);

            int UpdateCustomer(Customer customer);
        }

        class CustomerBol : ICustomerBol
        {
            public int AddCustomer(Customer customer)
            {
                return 1;
            }

            public int UpdateCustomer(Customer customer)
            {
                return customer.Id;
            }
        }

    }


    public class DynamicMediatorCollection : List<DynamicMediator>
    {
    }

    public class DynamicMediator
    {
        public int ActivityId { get; set; }
        public bool IsDuplicate { get; set; }
    }

    public class CustomFieldViewObjectCollection : List<CustomFieldViewObject>
    {
    }

    public class CustomFieldViewObject
    {
        public DynamicMediatorCollection DynamicMediatorList { get; set; }
    }

    public class CustomFormViewObject
    {
        public CustomFieldViewObjectCollection FieldList { get; set; }

        public DynamicMediatorCollection GetMediatorList(int activityId)
        {
            DynamicMediatorCollection mediators = new DynamicMediatorCollection();
            foreach (var item in this.FieldList)
            {
                foreach (DynamicMediator mediator in item.DynamicMediatorList)
                {
                    mediator.ActivityId = activityId;
                    mediator.IsDuplicate = false;
                    mediators.Add(mediator);
                }
            }
            return mediators;
        }
    }
}
