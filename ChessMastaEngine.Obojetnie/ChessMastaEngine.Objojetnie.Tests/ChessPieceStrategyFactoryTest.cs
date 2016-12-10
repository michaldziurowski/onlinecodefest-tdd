using System;
using System.Collections.Generic;
using ChessMastaEngine.Obojetnie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessMastaEngine.Objojetnie.Tests
{
    [TestClass]
    public class ChessPieceStrategyFactoryTest
    {
        [TestMethod]
        public void ChessPieceStrategyFactory_ReturnsKingStrategy_Works()
        {
            var factory = new ChessPieceStrategyFactory();

            var kingAbbrivieation = "k";
            var position = new PieceOnChessBoard();
            var takenFields = new List<PieceOnChessBoard>();

            var strategy = factory.GetStrategy(kingAbbrivieation,position,takenFields);

            Assert.IsInstanceOfType(strategy,typeof(King));
        }
    }
}


