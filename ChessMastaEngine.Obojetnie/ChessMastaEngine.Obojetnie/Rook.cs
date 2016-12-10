using System.Collections.Generic;
using System.Linq;
using ChessMastaEngine.Obojetnie.Extensions;

namespace ChessMastaEngine.Obojetnie
{
    public class Rook : IPieceStrategy
    {
        private readonly PieceOnChessBoard _myPiece;
        private readonly List<PieceOnChessBoard> _takenFields;

        public Rook(PieceOnChessBoard myPiece) : this(myPiece, new List<PieceOnChessBoard>()) { }

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
                && !_takenFields.Any(p => p.Position.IsVerticallyBetween(newPosition, _myPiece.Position)
                       || p.Position.IsHorizontallyBetween(newPosition, _myPiece.Position))
                && !_takenFields.Any(p => p.Color == _myPiece.Color && p.Position.X == newPosition.X && p.Position.Y == newPosition.Y);
        }
    }
}
