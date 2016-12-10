using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMastaEngine.Obojetnie
{
    public class Pawn
    {
        private readonly PieceOnChessBoard _myPiece;
        private readonly List<PieceOnChessBoard> _takenFields;
        private int _defaultHorizontalPosition;

        public Pawn(PieceOnChessBoard myPiece) : this(myPiece, new List<PieceOnChessBoard>()) { }

        public Pawn(PieceOnChessBoard myPiece, List<PieceOnChessBoard> takenFields)
        {
            _myPiece = myPiece;
            _takenFields = takenFields;
            switch (myPiece.Color)
            {
                case Color.Black:
                    _defaultHorizontalPosition = 7;
                    break;
                case Color.White:
                    _defaultHorizontalPosition = 2;
                    break;
            }
        }

        public bool MoveTo(string position)
        {
            var newPosition = new Position(position);
            int horizontalDifference = (newPosition.X - _myPiece.Position.X);
            int verticalDifference = (newPosition.Y - _myPiece.Position.Y);

            return (_myPiece.Color == Color.Black 
                        && ((_myPiece.Position.Y -1 == newPosition.Y) || (_myPiece.Position.Y - 2 == newPosition.Y && _myPiece.Position.Y == _defaultHorizontalPosition ))
                        && (horizontalDifference == 0 ||  _takenFields.Any(p=>p.Color != _myPiece.Color && horizontalDifference == -1)))
                || (_myPiece.Color == Color.White 
                        && ((_myPiece.Position.Y + 1 == newPosition.Y) || (_myPiece.Position.Y + 2 == newPosition.Y && _myPiece.Position.Y == _defaultHorizontalPosition))
                        && (horizontalDifference == 0 ||  _takenFields.Any(p => p.Color != _myPiece.Color && horizontalDifference == 1)))
               ;
        }
    }
}
