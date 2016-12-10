using CSharpClientSwissChess;
using CSharpClientSwissChess.Interfaces;
using FluentAssertions;
using Xunit;

namespace CSharpClientSwissTests
{
    public class ValidatorTest
    {
        [Theory]
        [InlineData("wKa1-a2")]
        public void Validate_Move_Success(string value)
        {
            IMoveParser moveParser = new MoveParser();
            IMoveProvider moveProvider = new MoveProvider();
            IMoveValidator moveValidator = new MoveValidator(moveParser, moveProvider);

            moveValidator.ValidateMove(value).Should().BeTrue();
        }
        
        [Theory]
        [InlineData("asdfwKa1-a2")]
        public void Validate_Move_Failure(string value)
        {
            IMoveParser moveParser = new MoveParser();
            IMoveProvider moveProvider = new MoveProvider();
            IMoveValidator moveValidator = new MoveValidator(moveParser, moveProvider);

            moveValidator.ValidateMove(value).Should().BeFalse();
        }
    }
}
