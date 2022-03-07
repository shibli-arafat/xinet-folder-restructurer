using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StringCollection : List<string>
    {
        public void Print()
        {
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }
    }
}
