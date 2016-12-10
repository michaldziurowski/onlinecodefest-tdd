namespace CSharpClientSwissChess
{
    public struct MoveVector
    {
        public MoveVector(int horizontal, int vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public int Horizontal;
        public int Vertical;
    }
}
