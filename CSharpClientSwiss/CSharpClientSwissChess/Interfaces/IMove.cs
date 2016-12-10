namespace CSharpClientSwissChess.Interfaces
{
    public interface IMove
    {
        Coordinates From { get; set; }
        Coordinates To { get; set; }
    }

    public struct Coordinates
    {
        public char Letter;
        public int Number;
    }
}
