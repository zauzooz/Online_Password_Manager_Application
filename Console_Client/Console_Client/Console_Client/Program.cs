// A C# program for Client
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{

	class Client
	{

		static private IPHostEntry ipHost = null;
		static private IPAddress ipAddr = null;
		static private IPEndPoint localEndPoint = null;
		static private Socket sender = null;

		// Main Method
		static void Main(string[] args)
		{
			ExecuteClient();
		}

		static void EndPoint()
        {
			ipHost = Dns.GetHostEntry(Dns.GetHostName());
			ipAddr = ipHost.AddressList[0];
			localEndPoint = new IPEndPoint(ipAddr, 15000);
			sender = new Socket(ipAddr.AddressFamily,
						SocketType.Stream, ProtocolType.Tcp);
		}

		static void Connect()
        {
			sender.Connect(localEndPoint);
		}

		static void Send(string msg)
        {
			byte[] messageSent = Encoding.ASCII.GetBytes(msg);
			int byteSent = sender.Send(messageSent);
		}

		private static string Recieve()
        {
			byte[] messageReceived = new byte[1024];
			string data = null;
			
			int byteRecv = sender.Receive(messageReceived);
			data = Encoding.ASCII.GetString(messageReceived,0,byteRecv);

			return data;
			
		}

		private static void Close()
        {
			sender.Shutdown(SocketShutdown.Both);
			sender.Close();
		}

		// ExecuteClient() Method
		static void ExecuteClient()
		{
			try
			{
				EndPoint();

				try
				{

					Connect();	

					Console.WriteLine("Socket connected to -> {0} ",
								sender.RemoteEndPoint.ToString());

					Send("LOGIN:user:pass");

					// Data buffer
					string data = Recieve();
					Console.WriteLine("Message from Server -> {0}",
						data);

					Send("END CONNECTION:");
					Close();
					
				}

				// Manage of Socket's Exceptions
				catch (ArgumentNullException ane)
				{

					Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
				}

				catch (SocketException se)
				{

					Console.WriteLine("SocketException : {0}", se.ToString());
				}

				catch (Exception e)
				{
					Console.WriteLine("Unexpected exception : {0}", e.ToString());
				}
			}

			catch (Exception e)
			{

				Console.WriteLine(e.ToString());
			}
		}
	}
}
