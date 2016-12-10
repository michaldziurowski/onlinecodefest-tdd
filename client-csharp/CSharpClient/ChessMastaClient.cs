using System;

namespace BS.ChessMasta
{
    public class ChessMastaClient
    {
        private ChessMastaConnector _connector;

        public ChessMastaClient(string serverUrl)
        {
            _connector = new ChessMastaConnector(serverUrl);
            _connector.OnRegistered += OnRegistered;
            _connector.OnMove += OnMove;
        }

        public void Run(string name)
        {
            _connector.Connect(name);
        }

        private void OnRegistered(string board)
        {
            Console.WriteLine("Board received " + board);
        }

        private void OnMove(string move)
        {
            Console.WriteLine($"Move {move} received");
            //here goes your engine magic
            string answer = "correct";

            Console.WriteLine($"Sending {answer} as an answer");
            _connector.SendAnswer(answer);
        }
    }
}
