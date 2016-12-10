using CSharpClientSwissChess;
using CSharpClientSwissChess.Interfaces;
using FluentAssertions;
using Xunit;

namespace CSharpClientSwissTests
{
    public class ProviderTest
    {
        [Theory]
        public void GetPossibleMoves_Returns_Collection_Of_Moves_Success()
        {
            // Arrange
            IMoveProvider moveProvider = new MoveProvider();
            Board board = new Board("");
            MoveParserResult parserResult = new MoveParserResult();

            // Act
            var possibleMoves = moveProvider.GetPossibleMoves(board, parserResult);

            // Assert
            possibleMoves.Should().NotBeNull();
        }
    }
}
