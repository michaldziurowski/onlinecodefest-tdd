using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMastaEngine.Obojetnie
{
    public class King
    {
        private readonly PieceOnChessBoard _myPiece;
        private readonly List<PieceOnChessBoard> _takenFields;

        public King(PieceOnChessBoard myPiece) : this(myPiece, new List<PieceOnChessBoard>()){}

        public King(PieceOnChessBoard myPiece, List<PieceOnChessBoard> takenFields)
        {
            _myPiece = myPiece;
            _takenFields = takenFields;
        }

        public bool MoveTo(string position)
        {
            var newPosition = new Position(position);
            int horizontalDifference = Math.Abs((newPosition.Y - _myPiece.Position.Y));
            int verticalDifference = Math.Abs(newPosition.X - _myPiece.Position.X);

            return (horizontalDifference == 0 || horizontalDifference == 1)
                   && (verticalDifference == 0 || verticalDifference == 1)
                   && !(verticalDifference == 0 && horizontalDifference == 0)
                   && !_takenFields.Any(p => p.Color == _myPiece.Color && p.Position.X == newPosition.X && p.Position.Y == newPosition.Y)
                   && CheckIfMoveNearOtherKing(newPosition);
        }

        private bool CheckIfMoveNearOtherKing(Position start)
        {
            var otherKing = _takenFields.FirstOrDefault(p => p.IsKing && p.Color != _myPiece.Color);

            if (otherKing == null)
            {
                return true;
            }

            int horizontalDifference = Math.Abs((otherKing.Position.Y - start.Y));
            int verticalDifference = Math.Abs(otherKing.Position.X - start.X);

            return !((horizontalDifference == 0 || horizontalDifference == 1)
                     && (verticalDifference == 0 || verticalDifference == 1));
        }
    }

    public enum Color
    {
        White,
        Black
    }

    public class PieceOnChessBoard
    {
        public bool IsKing { get; set; }
        public Color Color { get; set; }
        public Position Position { get; set; }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(string position)
        {
            X = position.Substring(0, 1).ToCharArray()[0];
            Y = int.Parse(position.Substring(1, 1));
        }
    }
}
