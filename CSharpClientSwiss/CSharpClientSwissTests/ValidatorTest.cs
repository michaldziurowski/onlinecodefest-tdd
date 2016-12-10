using System.Collections.Generic;
using CSharpClientSwissChess;
using CSharpClientSwissChess.Interfaces;
using Xunit;

namespace CSharpClientSwissTests
{
    public class ValidatorTest
    {
        [Theory]
        [InlineData("wKa1-a2")]
        public void Validate_Move(string value)
        {
            IMoveParser moveParser = new MoveParser();
            IMoveProvider moveProvider = new MoveProvider();
            IMoveValidator moveValidator = new MoveValidator(moveParser, moveProvider);

            moveValidator.ValidateMove(value);
        }
    }
}
