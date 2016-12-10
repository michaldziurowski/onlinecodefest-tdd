using System.Linq;
using CSharpClientSwissChess.Interfaces;

namespace CSharpClientSwissChess
{
    public class MoveValidator : IMoveValidator
    {
        private readonly IMoveParser _moveParser;
        private readonly IMoveProvider _moveProvider;

        public MoveValidator(IMoveParser moveParser, IMoveProvider moveProvider)
        {
            _moveParser = moveParser;
            _moveProvider = moveProvider;
        }

        public bool ValidateMove(string move)
        {
            try
            {
                MoveParserResult moveParserResult;
                if (_moveParser.TryParse(move, out moveParserResult))
                {
                    MoveProvider provider = new MoveProvider();
                    var possibleMoves = provider.GetPossibleMoves(new Board(""), moveParserResult);
                    return possibleMoves.Any(x => x.Equals(moveParserResult.Move.To)); 
                }
                return false;
            }

            catch
            {
                return false;
            }
        }
    }
}
