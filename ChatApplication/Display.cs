using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApplication
{
    public class Display
    {
        public void DisplayMessage(Message message)
        {
            Console.WriteLine("{0} >> {1}",message.Sender.UserName,message.Text);
        }
    }
}
