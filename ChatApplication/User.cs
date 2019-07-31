using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApplication
{
    public class User
    {
        public string UserName { get; }
        public User(string userName)
        {
            UserName = userName;
        }
    }
}
