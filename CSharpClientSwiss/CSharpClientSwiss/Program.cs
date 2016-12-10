using System;

namespace CSharpClientSwiss
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage:\nChessMasta.exe serverUrl");
            }
            else
            {
                Console.WriteLine("Let the game begin - swiss");
                var serverUrl = args[0];
                var client = new ChessMastaClient(serverUrl);

                client.Run("Swiss");
                Console.ReadKey();
            }
        }
    }
}
