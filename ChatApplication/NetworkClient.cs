using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatApplication
{
    public class NetworkClient
    {
        private Socket _socket = null;
        private int _listeningPort;
        private int _sendingPort;

        String _myName;
        int _myPort;
        String _clientName = "Client";
        int _clientPort;
        String _clientIP;
        IPHostEntry _ipHost;
        IPAddress _ipAddr;

        public Connection Connect()
        {
            _ipHost = Dns.GetHostEntry(Dns.GetHostName());
            _ipAddr = _ipHost.AddressList[1];
            //Console.WriteLine("Your Ip Address : " + _ipAddr);
            //Console.WriteLine("Enter the port to listen on");
            //_listeningPort = int.Parse(Console.ReadLine());
            //Thread listenerThread = new Thread(new ThreadStart(Listener));
            //listenerThread.Start();

            //Console.WriteLine("Who do you want to connect?");
            //string[] nameWithIP = Console.ReadLine().Split('@');
            //string name = nameWithIP[0];
            //string ipAddress = nameWithIP[1];
            //User connectedUser = new User(name);
            //Console.WriteLine("Enter the port to listen on");
            //_sendingPort = int.Parse(Console.ReadLine());
            //IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ipAddress), _sendingPort);
            //_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //try
            //{
            //    if (_socket != null)
            //    {
            //        _socket.Connect(remoteEP);
            //        Console.WriteLine("Socket connected to {0}",
            //            _socket.RemoteEndPoint.ToString());
            //    }
            //    Console.ReadKey(true);
            //    //_socket.Shutdown(SocketShutdown.Both);
            //    //_socket.Close();
            //}
            //catch (ArgumentNullException ane)
            //{
            //    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            //}
            //catch (SocketException se)
            //{
            //    Console.WriteLine("SocketException : {0}", se.ToString());
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Unexpected exception : {0}", e.ToString());
            //}

            Console.WriteLine("Your Ip Address : " + _ipAddr);
            Console.Write("Input your Port : ");
            this._myPort = Int32.Parse(Console.ReadLine());
            //Console.Write("Input your Name :");
            //this._myName = Console.ReadLine();

            Console.Write("Input Remote Host IP : ");
            this._clientIP = _ipAddr+"";//Console.ReadLine();
            Console.Write("Input Remote Host Port : ");
            this._clientPort = Int32.Parse(Console.ReadLine());
            Thread listeningThread = new Thread(new ThreadStart(() => this.Listen()));
            listeningThread.Start();
            Console.WriteLine("enter send if you want to send a something else press enter only");
            if (Console.ReadLine().Equals("send"))
            {
                Send();
                listeningThread.Suspend();
                //Thread sendingThread = new Thread(new ThreadStart(() => this.Send()));
                //sendingThread.Start();
            }

            return new Connection(_socket,new User("asd"));
        }



        public void Send()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(_clientIP), _clientPort);

            try
            {
                while (true)
                {
                    try
                    {
                            socket.Connect(endPoint);
                            _socket = socket;
                            Console.WriteLine("Connected!");
                            break;
                    }
                    catch
                    {
                        Console.WriteLine("Waiting for connection");
                    }
                }

                //while (true)
                //{
                //    var message = Console.ReadLine();
                //    var messageToBeSent = Encoding.ASCII.GetBytes(message);
                //    _socket.Send(messageToBeSent);
                //}
            }
            catch
            {
                Console.WriteLine("Error: Unable to connect to Server!");
            }
            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();

        }

        public void Listen()
        {
            IPEndPoint endPoint = new IPEndPoint(_ipAddr, _myPort);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(endPoint);
            listener.Listen(10);
            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                if (_socket == null)
                {
                    _socket = listener.Accept();
                    Console.WriteLine("Connected using listener");
                }

                //while (true)
                //{
                //    var messageRecieved = new byte[1024];
                //    var byteRecieved = _socket.Receive(messageRecieved);
                //    Console.WriteLine(_clientName + ": " + Encoding.ASCII.GetString(messageRecieved, 0, byteRecieved));
                //}
            }
            catch
            {
                Console.WriteLine("Error: Unable to connect to Client!");
            }
            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();

        }


    }
}
