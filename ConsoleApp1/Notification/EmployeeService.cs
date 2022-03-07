using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class EmployeeService
    {
        List<Notifier> _Notifiers;

        public EmployeeService()
        {
            _Notifiers = new List<Notifier>();
        }

        public void Update(Employee employee)
        {
            UpdateEmployee(employee);
            foreach (var notifier in _Notifiers)
            {
                notifier.Notify();
            }
        }

        public void Subscribe(List<Notifier> notifiers)
        {
            _Notifiers = notifiers;
        }

        private void UpdateEmployee(Employee employee)
        {
            Console.WriteLine("Updating employee {0}.", employee.Name);
        }
    }
}
