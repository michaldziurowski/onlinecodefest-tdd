using System.Collections.Generic;

namespace ChessMastaEngine.Obojetnie
{
    public class ChessPieceStrategyFactory
    {
        public IPieceStrategy GetStrategy(string abbreviation, PieceOnChessBoard piece, List<PieceOnChessBoard> takenFields)
        {
            switch (abbreviation)
            {
                case "K":
                    return new King(piece, takenFields);
                case "R":
                    return new Rook(piece, takenFields);
                case "B":
                    return new Bishop(piece, takenFields);
                case "P":
                    return new Pawn(piece, takenFields);
                default:
                    return null;
            }
        }
    }
}
