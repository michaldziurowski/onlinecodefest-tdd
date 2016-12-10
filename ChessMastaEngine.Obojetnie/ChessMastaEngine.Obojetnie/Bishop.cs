using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMastaEngine.Obojetnie
{
    public class Bishop : IPieceStrategy
    {
        private readonly PieceOnChessBoard _myPiece;
        private readonly List<PieceOnChessBoard> _takenFields;

        public Bishop(PieceOnChessBoard myPiece) : this(myPiece, new List<PieceOnChessBoard>())
        {
        }

        public Bishop(PieceOnChessBoard myPiece, List<PieceOnChessBoard> takenFields)
        {
            _myPiece = myPiece;
            _takenFields = takenFields;
        }

        public bool MoveTo(string newPosition)
        {
            var position = new Position(newPosition);

            return Math.Abs(position.X - _myPiece.Position.X) == Math.Abs(position.Y - _myPiece.Position.Y) &&
                   !IsPieceOnPath();
        }

        private bool IsPieceOnPath()
        {
            var boardAvailableLetters = new[] {'e', 'f', 'g'};
            var isOnPath = false;

            var idxVerticalOffset = 1;
            foreach (var boardAvailableLetter in boardAvailableLetters)
            {
                if (
                    _takenFields.Any(
                        p =>
                            p.Position.X == boardAvailableLetter &&
                            p.Position.Y == _myPiece.Position.Y + idxVerticalOffset))
                {
                    isOnPath = true;
                }
                idxVerticalOffset++;
            }

            return isOnPath;
        }
    }
}
