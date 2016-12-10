using CSharpClientSwissChess;
using FluentAssertions;
using Xunit;

namespace CSharpClientSwissTests
{
    public class FigureTest
    {
        [Theory]
        [InlineData("wK")]
        public void CreateFigure_Returns_Initialized_Figure_Success(string value)
        {
            // Arrange
            Figure figure = new Figure(value);

            // Assert
            figure.Color.Should().Be('w');
            figure.Code.Should().Be('K');
        }
    }
}
