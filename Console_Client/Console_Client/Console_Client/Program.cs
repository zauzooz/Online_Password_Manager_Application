﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

public class Client
{

    private const int BUFFER_SIZE = 1024;
    private const int PORT_NUMBER = 15000;

    static ASCIIEncoding encoding = new ASCIIEncoding();

    public static void Main()
    {

        try
        {
            TcpClient client = new TcpClient();

            // 1. connect
            client.Connect("127.0.0.1", PORT_NUMBER);
            Stream stream = client.GetStream();

            Console.WriteLine("Connected to Server.");
            while (true)
            {
                Console.Write("Enter your command: ");

                string str = Console.ReadLine();
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                // 2. send
                writer.WriteLine(str);

                // 3. receive
                str = reader.ReadLine();
                Console.WriteLine(str);
                if (str.ToUpper() == "BYE")
                    break;
            }
            // 4. close
            stream.Close();
            client.Close();
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }

        Console.Read();
    }
}