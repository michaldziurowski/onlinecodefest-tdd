using System;

namespace CSharpClientSwiss
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage:\nChessMasta.exe serverUrl");
            }
            else
            {
                Console.WriteLine("Let the game begin - swiss");

                Console.ReadKey();
            }
        }
    }
}
