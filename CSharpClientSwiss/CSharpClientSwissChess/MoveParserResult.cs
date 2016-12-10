using CSharpClientSwissChess.Interfaces;

namespace CSharpClientSwissChess
{
    public class MoveParserResult
    {
        public IFigure Figure { get; set; }
        public IMove Move { get; set; }
    }
}
