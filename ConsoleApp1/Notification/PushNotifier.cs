using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PushNotifier : Notifier
    {
        private Message _Message;

        public PushNotifier(Message message) : base(message)
        {
            _Message = message;
        }

        public override void Notify()
        {
            Console.WriteLine(@"Sending Push notification to '{0}' wtih subject '{1}'", _Message.To, _Message.Subject);
        }
    }
}
