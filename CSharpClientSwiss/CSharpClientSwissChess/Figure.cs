using CSharpClientSwissChess.Interfaces;

namespace CSharpClientSwissChess
{
    public class Figure : IFigure
    {
        public Figure(string value)
        {
            Color = value[0];
            Code = value[1];
        }

        public char Color { get; set; }
        public char Code { get; set; }
    }
}
