using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.ChessMasta;
using ChessMastaEngine.Obojetnie;

namespace ChessMastaClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new ChessMastaClient("http://10.10.240.44:3000");
            client.Run("obojetnie");

            Console.ReadKey();
        }
    }

    public class ChessMastaClient
    {
        private ChessMastaConnector _connector;
        private ChessMoveInputHelper _inputHelper = new ChessMoveInputHelper();
        private List<PieceOnChessBoard> _takenFields; 

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
            _takenFields = _inputHelper.GetPiecesOnChessBoard(board);
        }

        private void OnMove(string move)
        {
            Console.WriteLine($"Move {move} received");

            var pieceAbb = _inputHelper.GetPieceAbbreviation(move);
            var myPiece = new PieceOnChessBoard
            {
                Position = _inputHelper.GetStartPosition(move),
                Color = _inputHelper.GetColor(move),
                IsKing = pieceAbb == "K"
            };

            var pieceStrategy = new ChessPieceStrategyFactory().GetStrategy(pieceAbb,myPiece,_takenFields);

            var answer = pieceStrategy.MoveTo(_inputHelper.GetEndPosition(move))? "correct": "incorrect";

            Console.WriteLine($"Sending {answer} as an answer");
            _connector.SendAnswer(answer);
        }
    }
}
