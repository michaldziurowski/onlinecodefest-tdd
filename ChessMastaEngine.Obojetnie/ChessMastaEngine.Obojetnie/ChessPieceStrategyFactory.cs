using System.Collections.Generic;

namespace ChessMastaEngine.Obojetnie
{
    public class ChessPieceStrategyFactory
    {
        public King GetStrategy(string abbreviation, PieceOnChessBoard piece, List<PieceOnChessBoard> takenFields)
        {
            return new King(piece, takenFields);
        }
    }
}
