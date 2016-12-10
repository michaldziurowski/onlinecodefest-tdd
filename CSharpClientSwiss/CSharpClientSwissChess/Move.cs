using CSharpClientSwissChess.Interfaces;

namespace CSharpClientSwissChess
{
    public class Move : IMove
    {
        public Move(string input)
        {
            From = new Coordinates { Letter = input[2], Number = int.Parse(input[3].ToString()) };
            To = new Coordinates { Letter = input[5], Number = int.Parse(input[6].ToString()) };
        }

        public Coordinates From { get; set; }

        public Coordinates To { get; set; }
    }
}
