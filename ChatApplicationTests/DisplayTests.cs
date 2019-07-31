using System;
using Xunit;
using ChatApplication;

namespace ChatApplicationTests
{
    public class MessageTest
    {
        [Fact]
        public void TestNewMessage()
        {
            User sender = new User("A");
            User receiver = new User("B");
            string text = "asdsda";
            Message message = new Message(text, sender, receiver);
        }
    }
    public class DisplayTests
    {
        [Fact]
        public void TestDisplay()
        {
            User sender = new User("A");
            User receiver = new User("B");
            string text = "asdsda";
            Message message = new Message(text, sender, receiver);
            Display display = new Display();
            display.DisplayMessage(message);
        }
    }

    public class UserTest
    {
        [Fact]
        public void TestUser()
        {
            User govind = new User("govind");
            Assert.IsType<User>(govind);
        }
    }

    public class ConversationTest
    {
        [Fact]
        public void TestConversation()
        {
            User sender = new User("A");
            User receiver = new User("B");
            string text = "asdsda";
            Conversation conversation = new Conversation();
            Message message = conversation.CreateMessage(text, sender, receiver);
            conversation.sendMessage(message);
            Message receivedMessage = conversation.receiveMessage();
            Assert.IsType<Conversation>(conversation);
        }
    }


}
