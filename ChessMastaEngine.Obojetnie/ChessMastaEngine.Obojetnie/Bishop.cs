using System;

namespace ChessMastaEngine.Obojetnie
{
    public class Bishop
    {
        private readonly PieceOnChessBoard _myPiece;

        public Bishop(PieceOnChessBoard myPiece)
        {
            _myPiece = myPiece;
        }

        public bool MoveTo(string newPosition)
        {
            var position = new Position(newPosition);

            return Math.Abs(position.X - _myPiece.Position.X) == Math.Abs(position.Y - _myPiece.Position.Y);
        }
    }
}
