using System;
using System.Text.RegularExpressions;

using CSharpClientSwissChess.Interfaces;

namespace CSharpClientSwissChess
{
    public class MoveParser : IMoveParser
    {
        public MoveParserResult Parse(string input)
        {
            return new MoveParserResult { Figure = new Figure(input), Move = new Move(input) };
        }

        public bool TryParse(string input, out MoveParserResult parseResult)
        {
            if (!ValidateInput(input))
            {
                parseResult = null;
                return false;
            }

            parseResult = Parse(input);
            return true;
        }

        private bool ValidateInput(string input)
        {
            Regex regex = new Regex(@"^[w,b][B,K,N,Q,P,R][a-h][1-8][-][a-h][1-8]$");
            Match match = regex.Match(input);

            return match.Success;
        }
    }
}
