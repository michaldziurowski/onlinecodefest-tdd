using System.Collections.Generic;
using System.Linq;
using ChessMastaEngine.Obojetnie.Extensions;

namespace ChessMastaEngine.Obojetnie
{
    public class Rook : IPieceStrategy
    {
        private readonly PieceOnChessBoard _myPiece;
        private readonly List<PieceOnChessBoard> _takenFields;

        public Rook(PieceOnChessBoard myPiece) : this(myPiece, new List<PieceOnChessBoard>())
        {
        }

        public Rook(PieceOnChessBoard myPiece, List<PieceOnChessBoard> takenFields)
        {
            _myPiece = myPiece;
            _takenFields = takenFields;
        }

        public bool MoveTo(string position)
        {
            var newPosition = new Position(position);

            return (_myPiece.Position.X == newPosition.X || _myPiece.Position.Y == newPosition.Y)
                && !(_myPiece.Position.X == newPosition.X && _myPiece.Position.Y == newPosition.Y)
                && !_takenFields.Any(p=> IsVorizontallyBetween(_myPiece.Position, newPosition, p.Position)
                       || IsHorizontallyBetween(_myPiece.Position, newPosition, p.Position))
                && !_takenFields.Any(p => p.Color == _myPiece.Color && p.Position.X == newPosition.X && p.Position.Y == newPosition.Y);
        }

        private bool IsVorizontallyBetween(Position elementPosition, Position targetPosition, Position positionToCheck)
        {
            return IsBetween(_myPiece.Position.X, targetPosition.X, positionToCheck.X) 
                && (positionToCheck.Y == targetPosition.Y);
        }

        private bool IsHorizontallyBetween(Position elementPosition, Position targetPosition, Position positionToCheck)
        {
            return IsBetween(_myPiece.Position.Y, targetPosition.Y, positionToCheck.Y)
                && (positionToCheck.X == targetPosition.X);
        }

        private bool IsBetween(int elementA, int elementB, int elementToCkeck)
        {
            return elementB > elementA 
                ? elementToCkeck > elementA && elementToCkeck < elementB 
                : elementToCkeck > elementB && elementToCkeck < elementA;
        }
    }
}
