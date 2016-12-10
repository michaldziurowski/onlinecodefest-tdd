using System;

namespace BS.ChessMasta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage:\nChessMasta.exe serverUrl");
            }
            else
            {
                Console.WriteLine("Let the game begin");
                var serverUrl = args[0];
                var client = new ChessMastaClient(serverUrl);

                client.Run("CSharp Mikies");
                Console.ReadKey();
            }
        }
    }
}
