using System;
using System.Collections.Generic;
using System.Linq;
using ChessMastaEngine.Obojetnie.Extensions;

namespace ChessMastaEngine.Obojetnie
{
    public class Pawn: IPieceStrategy
    {
        private readonly PieceOnChessBoard _myPiece;
        private readonly List<PieceOnChessBoard> _takenFields;
        private readonly int _defaultHorizontalPosition;
        private readonly int _allowedVerticallDifference;
        private readonly int _allowedInitVerticallDifference;

        public Pawn(PieceOnChessBoard myPiece) : this(myPiece, new List<PieceOnChessBoard>()) { }

        public Pawn(PieceOnChessBoard myPiece, List<PieceOnChessBoard> takenFields)
        {
            _myPiece = myPiece;
            _takenFields = takenFields;
            switch (myPiece.Color)
            {
                case Color.Black:
                    _defaultHorizontalPosition = 7;
                    _allowedVerticallDifference = -1;
                    _allowedInitVerticallDifference = -2;
                    break;
                case Color.White:
                    _defaultHorizontalPosition = 2;
                    _allowedVerticallDifference = 1;
                    _allowedInitVerticallDifference = 2;
                    break;
            }
        }

        public bool MoveTo(string position)
        {
            var newPosition = new Position(position);
            int horizontalDifference = (newPosition.X - _myPiece.Position.X);

            return ((_myPiece.Position.Y + _allowedVerticallDifference == newPosition.Y) 
                    || (_myPiece.Position.Y + _allowedInitVerticallDifference == newPosition.Y && _myPiece.Position.Y == _defaultHorizontalPosition && NoPiecesBetween(newPosition)))
                    && IsHorizontallChangeAllowed(horizontalDifference)
                    && (!_takenFields.Any(p=>p.Position.X != newPosition.X && p.Position.Y != newPosition.Y && horizontalDifference == 0));
        }

        private bool NoPiecesBetween(Position newPosition)
        {
            return _takenFields.All(p => !p.Position.IsHorizontallyBetween(newPosition, _myPiece.Position) 
                                      && !p.Position.IsVerticallyBetween(newPosition, _myPiece.Position));
        }

        private bool IsHorizontallChangeAllowed(int horizontalDifference)
        {
            return (horizontalDifference == 0 ||
                    _takenFields.Any(p => p.Color != _myPiece.Color && Math.Abs(horizontalDifference) == 1));
        }
    }
}
