using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatApplication
{
    public class Connection
    {
        public Socket Socket { get; }
        public User ConnectedUser { get; }

        public Connection(Socket socket, User connectedUser)
        {
            Socket = socket;
            ConnectedUser = connectedUser;
        }
    }
}