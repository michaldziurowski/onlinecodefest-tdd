using System;
using CSharpClientSwissChess.Interfaces;

namespace CSharpClientSwissChess
{
    public class MoveParser : IMoveParser
    {
        public MoveParserResult Parse(string empty)
        {
            throw new NotImplementedException();
        }

        public bool TryParse(string input, out MoveParserResult parseResult)
        {
            throw new NotImplementedException();
        }
    }
}
