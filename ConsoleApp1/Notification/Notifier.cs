using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class Notifier
    {
        private Message _Message;
        public Notifier(Message message)
        {
            _Message = message;
        }     
        public abstract void Notify();
    }
}
