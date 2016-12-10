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

            var kingAbbrivieation = "K";
            var position = new PieceOnChessBoard();
            var takenFields = new List<PieceOnChessBoard>();

            var strategy = factory.GetStrategy(kingAbbrivieation,position,takenFields);

            Assert.IsInstanceOfType(strategy,typeof(King));
        }

        [TestMethod]
        public void ChessPieceStrategyFactory_ReturnsRookStrategy_Works()
        {
            var factory = new ChessPieceStrategyFactory();

            var kingAbbrivieation = "R";
            var position = new PieceOnChessBoard();
            var takenFields = new List<PieceOnChessBoard>();

            var strategy = factory.GetStrategy(kingAbbrivieation, position, takenFields);

            Assert.IsInstanceOfType(strategy, typeof (Rook));
        }

        [TestMethod]
        public void ChessPieceStrategyFactory_ReturnsBishopStrategy_Works()
        {
            var factory = new ChessPieceStrategyFactory();

            var kingAbbrivieation = "B";
            var position = new PieceOnChessBoard();
            var takenFields = new List<PieceOnChessBoard>();

            var strategy = factory.GetStrategy(kingAbbrivieation, position, takenFields);

            Assert.IsInstanceOfType(strategy, typeof(Bishop));
        }

        [TestMethod]
        public void ChessPieceStrategyFactory_ReturnsPawnStrategy_Works()
        {
            var factory = new ChessPieceStrategyFactory();

            var kingAbbrivieation = "P";
            var position = new PieceOnChessBoard();
            var takenFields = new List<PieceOnChessBoard>();

            var strategy = factory.GetStrategy(kingAbbrivieation, position, takenFields);

            Assert.IsInstanceOfType(strategy, typeof(Pawn));
        }
    }
}


