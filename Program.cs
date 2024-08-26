using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Connect to the server.
            TcpClient client = new TcpClient("localhost", 8080);
            
            // Get the network stream to send and receive data.
            NetworkStream stream = client.GetStream();

            // Get user input for their choice (rock, paper, or scissors).
            Console.WriteLine("Enter your choice (rock, paper, or scissors):");
            string choice = Console.ReadLine().ToLower();

            // Send the user's choice to the server.
            byte[] choiceBytes = Encoding.ASCII.GetBytes(choice);
            stream.Write(choiceBytes, 0, choiceBytes.Length);

            // Receive the result from the server.
            byte[] data = new byte[1024];
            int bytes = stream.Read(data, 0, data.Length);
            string result = Encoding.ASCII.GetString(data, 0, bytes);

            // Display the result to the user.
            Console.WriteLine("Result: " + result);

            // Close the connection.
            stream.Close();
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
