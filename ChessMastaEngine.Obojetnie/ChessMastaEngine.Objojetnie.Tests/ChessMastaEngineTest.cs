using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessMastaEngine.Objojetnie.Tests
{
    [TestClass]
    public class ChessMastaEngineTest
    {
        [TestMethod]
        public void ChessMastaEngine_ReturnsCorrectAnswerForKing_Works()
        {
            var engine = new Obojetnie.ChessMastaEngine();
            var move = "wKf5-f6";

            var result = engine.ValidateMove(move);

            Assert.IsTrue(result);
        }

    }
}
