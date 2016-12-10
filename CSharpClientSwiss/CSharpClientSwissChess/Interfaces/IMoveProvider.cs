using System.Collections.Generic;

namespace CSharpClientSwissChess.Interfaces
{
    public interface IMoveProvider
    {
        IEnumerable<Coordinates> GetPossibleMoves(Board board, MoveParserResult moveParserResult);
    }
}
