using System;
using CSharpClientSwissChess;
using CSharpClientSwissChess.Interfaces;

namespace CSharpClientSwiss
{
    public class ChessMastaClient
    { 
        private BS.ChessMasta.ChessMastaConnector _connector;

        public ChessMastaClient(string serverUrl)
        {
            _connector = new BS.ChessMasta.ChessMastaConnector(serverUrl);
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
            Board chessBoard = new Board(board);
        }

        private void OnMove(string move)
        {
            Console.WriteLine($"Move {move} received");

            IMoveParser moveParser = new MoveParser();
            IMoveProvider moveProvider = new MoveProvider();
            MoveValidator validator = new MoveValidator(moveParser, moveProvider);

            var answer = validator.ValidateMove(move) ? "correct" : "inncorect";
            
            Console.WriteLine($"Sending {answer} as an answer");
            _connector.SendAnswer(answer);
        }
    }
}
