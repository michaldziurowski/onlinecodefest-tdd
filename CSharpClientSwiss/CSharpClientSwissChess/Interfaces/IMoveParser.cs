namespace CSharpClientSwissChess.Interfaces
{
    public interface IMoveParser
    {
        MoveParserResult Parse(string empty);

        bool TryParse(string input, out MoveParserResult parseResult);
    }
}
