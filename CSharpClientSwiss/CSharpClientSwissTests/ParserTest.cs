using CSharpClientSwissChess;
using CSharpClientSwissChess.Interfaces;
using FluentAssertions;
using Xunit;

namespace CSharpClientSwissTests
{
    public class ParserTest
    {
        [Theory]
        [InlineData("wKa1-a3")]
        [InlineData("bPb2-b4")]
        [InlineData("wRc4-c5")]
        public void Parse_Move_Of_Figure_Input_Parsing_Success(string value)
        {
            // Arrange 
            IMoveParser moveParser = new MoveParser();
            MoveParserResult parserResult;

            // Act
            bool parsed = moveParser.TryParse(value, out parserResult);

            // Assert 
            parsed.Should().BeTrue();
            parserResult.Should().NotBeNull();
        }

        [Theory]
        [InlineData("a782834127a01")]
        [InlineData("wKAa1-a1")]
        public void Parse_Move_Of_Figure_Input_Parsing_Failure(string value)
        {
            // Arrange 
            IMoveParser moveParser = new MoveParser();
            MoveParserResult parserResult;

            // Act
            bool parsed = moveParser.TryParse(value, out parserResult);

            // Assert
            parsed.Should().BeFalse();
            parserResult.Should().BeNull();
        }

        [Theory]
        [InlineData("wKa1-a3")]
        [InlineData("bPb2-b4")]
        [InlineData("wRc4-c5")]
        public void Parse_Move_Of_Figure_Returns_Initialized_Result_Success(string value)
        {
            // Arrange
            IMoveParser moveParser = new MoveParser();

            // Act
            MoveParserResult moveParserResult = moveParser.Parse(value);

            // Assert
            moveParserResult.Figure.Should().NotBeNull();
            moveParserResult.Move.Should().NotBeNull();
        }

        [Theory]
        [InlineData("wKa1-a3")]
        public void Parse_Move_Of_Figure_Returns_Concrete_Result_Success(string value)
        {
            // Arrange
            IMoveParser moveParser = new MoveParser();

            // Act
            MoveParserResult moveParserResult = moveParser.Parse(value);

            // Assert
            moveParserResult.Figure.Should().BeOfType<Figure>();
            moveParserResult.Figure.Color.Should().Be('w');
            moveParserResult.Move.Should().BeOfType<Move>();
            moveParserResult.Move.From.Letter.Should().Be('a');
            moveParserResult.Move.From.Number.Should().Be(1);
            moveParserResult.Move.To.Letter.Should().Be('a');
            moveParserResult.Move.To.Number.Should().Be(3);
        }
    }
}
