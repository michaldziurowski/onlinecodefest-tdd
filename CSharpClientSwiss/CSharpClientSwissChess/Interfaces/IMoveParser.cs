namespace CSharpClientSwissChess.Interfaces
{
    public interface IMoveParser
    {
        MoveParserResult Parse(string input);

        bool TryParse(string input, out MoveParserResult parseResult);
    }
}
