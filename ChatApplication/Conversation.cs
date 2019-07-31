using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApplication
{
    public class Conversation
    {
        public Connection connection { get; }
        public Conversation()
        {
            NetworkClient networkClient = new NetworkClient();
            connection = networkClient.Connect();
        }
        public Message CreateMessage(string text, User sender, User receiver)
        {
            Message message = new Message(text, sender, receiver);
            return message;
        }

        public void sendMessage(Message message)
        {
            throw new NotImplementedException();
            // all the ugly stuff
        }
        
        public Message receiveMessage()
        {
            throw new NotImplementedException();
            // all the ugly stuff
        }
    }
}
