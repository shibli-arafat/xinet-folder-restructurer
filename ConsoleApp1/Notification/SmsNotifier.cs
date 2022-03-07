using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SmsNotifier : Notifier
    {
        private Message _Message;
        public SmsNotifier(Message message) : base(message)
        {
            _Message = message;
        }
        public override void Notify()
        {
            Console.WriteLine("Sending SMS to '{0}' wtih subject '{1}'", _Message.To, _Message.Subject);
        }
    }
}
