namespace ChessMastaEngine.Obojetnie.Extensions
{
    public static class PositionExtensions
    {
        public static bool IsVerticallyBetween(this Position positionToCheck, Position targetPositionA, Position targetPositionB)
        {
            return IsBetween(targetPositionA.X, targetPositionB.X, positionToCheck.X)
                && (positionToCheck.Y == targetPositionB.Y);
        }

        public static bool IsHorizontallyBetween(this Position positionToCheck, Position targetPositionA, Position targetPositionB)
        {
            return IsBetween(targetPositionA.Y, targetPositionB.Y, positionToCheck.Y)
                && (positionToCheck.X == targetPositionB.X);
        }

        private static bool IsBetween(int elementA, int elementB, int elementToCkeck)
        {
            return elementB > elementA
                ? elementToCkeck > elementA && elementToCkeck < elementB
                : elementToCkeck > elementB && elementToCkeck < elementA;
        }
    }
}
