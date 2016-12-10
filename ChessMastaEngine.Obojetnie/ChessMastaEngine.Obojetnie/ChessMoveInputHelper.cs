using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChessMastaEngine.Obojetnie
{
    public class ChessMoveInputHelper
    {
        public Color GetColor(string move)
        {
            var colorString = move.Substring(0, 1);

            return colorString == "w"? Color.White : Color.Black;
        }

        public string GetPieceAbbreviation(string move)
        {
            return move.Substring(1, 1);
        }

        public Position GetStartPosition(string move)
        {
            var position = new Position(move.Substring(2, 2));
            
            return position;
        }

        public string GetEndPosition(string move)
        {
            var position = move.Substring(5, 2);

            return position;
        }

        public List<PieceOnChessBoard> GetPiecesOnChessBoard(string board)
        {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(board);

            List<PieceOnChessBoard> positions = new List<PieceOnChessBoard>();

            foreach (var position in dictionary.Keys)
            {
                positions.Add(new PieceOnChessBoard
                {
                    Position = new Position(position),
                    Color = new ChessMoveInputHelper().GetColor(dictionary[position]),
                    IsKing = dictionary[position].Substring(1, 1) == "K"
                });
            }

            return positions;
        }
    }
}
