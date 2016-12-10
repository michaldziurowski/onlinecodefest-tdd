using System.Collections.Generic;
using ChessMastaEngine.Obojetnie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ChessMastaEngine.Objojetnie.Tests
{
    [TestClass]
    public class ChessMoveInputHelperTest
    {
        [TestMethod]
        public void ChessMoveInputHelper_GetColorWhite_Works()
        {
            var inputHelper = new ChessMoveInputHelper();
            var move = "wKf5-f6";

            var result = inputHelper.GetColor(move);

            Assert.AreEqual(result, Color.White);
        }

        [TestMethod]
        public void ChessMoveInputHelper_GetColorBlack_Works()
        {
            var inputHelper = new ChessMoveInputHelper();
            var move = "bKf5-f6";

            var result = inputHelper.GetColor(move);

            Assert.AreEqual(result, Color.Black);
        }

        [TestMethod]
        public void ChessMoveInputHelper_GetPieceAbbreviation_Works()
        {
            var inputHelper = new ChessMoveInputHelper();
            var move = "bKf5-f6";

            var result = inputHelper.GetPieceAbbreviation(move);

            Assert.AreEqual(result, "K");
        }

        [TestMethod]
        public void ChessMoveInputHelper_GetStartPosition_Works()
        {
            var inputHelper = new ChessMoveInputHelper();
            var move = "bKf5-f6";

            Position result = inputHelper.GetStartPosition(move);

            Assert.AreEqual(result.X, 'f');
            Assert.AreEqual(result.Y, 5);
        }

        [TestMethod]
        public void ChessMoveInputHelper_GetEndPosition_Works()
        {
            var inputHelper = new ChessMoveInputHelper();
            var move = "bKf5-f6";

            string result = inputHelper.GetEndPosition(move);

            Assert.AreEqual(result, "f6");
        }
    }
}
