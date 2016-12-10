using System;
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

        public void ValidateMove(string move)
        {
            throw new NotImplementedException();
        }
    }
}
