using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApplication
{
    public class Message
    {
        public string Text { get; }
        public User Sender { get; }
        public User Receiver { get; }

        public Message(string text, User sender, User receiver)
        {
            Text = text;
            Sender = sender;
            Receiver = receiver;
        }
    }
}
