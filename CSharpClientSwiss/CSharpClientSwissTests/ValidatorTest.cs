using CSharpClientSwissChess;
using CSharpClientSwissChess.Interfaces;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CSharpClientSwissTests
{
    public class ValidatorTest
    {
        [Theory]
        [InlineData("wKa1-a2")]
        public void Validate_Move_Success(string value)
        {
            // Arrange
            IMoveProvider moveProvider = Substitute.For<IMoveProvider>();
            IMoveParser moveParser = new MoveParser();
            IMoveValidator moveValidator = new MoveValidator(moveParser, moveProvider);

            // Act
            bool result = moveValidator.ValidateMove(value);

            // Assert
            result.Should().BeTrue();
        }
        
        [Theory]
        [InlineData("asdfwKa1-a2")]
        public void Validate_Move_Failure(string value)
        {
            // Arrange
            IMoveProvider moveProvider = Substitute.For<IMoveProvider>();
            MoveParser moveParser = new MoveParser();
            IMoveValidator moveValidator = new MoveValidator(moveParser, moveProvider);

            // Act
            bool result = moveValidator.ValidateMove(value);

            // Assert
            result.Should().BeFalse();
        }
    }
}
