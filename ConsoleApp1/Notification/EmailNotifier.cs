using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class EmailNotifier : Notifier
    {
        public Message _Message { get; set; }
        public EmailNotifier(Message message) : base(message)
        {
            _Message = message;
        }

        public override void Notify()
        {
            Console.WriteLine("Sending email to '{0}' wtih subject '{1}'", _Message.To, _Message.Subject);
        }
    }
}
