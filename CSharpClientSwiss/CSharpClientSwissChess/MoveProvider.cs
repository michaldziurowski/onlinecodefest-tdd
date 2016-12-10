using System;
using System.Collections.Generic;
using CSharpClientSwissChess.Interfaces;

namespace CSharpClientSwissChess
{
    public class MoveProvider : IMoveProvider
    {
        public IEnumerable<Coordinates> GetPossibleMoves(Board board, MoveParserResult moveParserResult)
        {
            throw new NotImplementedException();
        }
    }
}
