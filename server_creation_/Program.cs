using System;
using System.Net.Sockets;
using System.IO;

namespace server_creation_
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listen_response 
                =  new TcpListener(System.Net.IPAddress.Any, 32);

            listen_response.Start();
            Console.WriteLine("Waiting for connection.....");
            Socket socket_pipe = listen_response.AcceptSocket();
            Stream stream_sender = new NetworkStream(socket_pipe);
            StreamWriter client_writer = new StreamWriter(stream_sender);
            client_writer.WriteLine("TCP server is connected");
            client_writer.Flush();
            Console.WriteLine("Closing connection!");
            stream_sender.Close();
            socket_pipe.Close();

        }
    }
}
