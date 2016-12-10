using ChessMastaEngine.Obojetnie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessMastaEngine.Objojetnie.Tests
{
    [TestClass]
    public class ChessBishopTest
    {
        private PieceOnChessBoard _myPiece;

        [TestInitialize]
        public void InitTest()
        {
            _myPiece = new PieceOnChessBoard
            {
                Color = Color.White,
                Position = new Position("d5")
            };
        }

        [TestMethod]
        public void Bishop_MoveOneFieldDiagonallyRightTop_Correct()
        {
            var bishop = new Bishop(_myPiece);
            var result = bishop.MoveTo("e6");

            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void Bishop_MoveOneFieldDiagonallyLeftDown_Correct()
        {
            var bishop = new Bishop(_myPiece);
            var result = bishop.MoveTo("c4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Bishop_MoveTwoFieldsDiagonallyLeftTop_Correct()
        {
            var bishop = new Bishop(_myPiece);
            var result = bishop.MoveTo("b7");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Bishop_MoveThreeFieldsDiagonallyRightDown_Correct()
        {
            var bishop = new Bishop(_myPiece);
            var result = bishop.MoveTo("g2");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Bishop_MoveOneFieldUpVertically_Incorrect()
        {
            var bishop = new Bishop(_myPiece);
            var result = bishop.MoveTo("d6");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Bishop_MoveOneFieldDownVerically_Incorrect()
        {
            var bishop = new Bishop(_myPiece);
            var result = bishop.MoveTo("d4");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Bishop_MoveOneFieldRightHorizontally_Incorrect()
        {
            var bishop = new Bishop(_myPiece);
            var result = bishop.MoveTo("e5");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Bishop_MoveOneFieldLeftHorizontally_Incorrect()
        {
            var bishop = new Bishop(_myPiece);
            var result = bishop.MoveTo("c5");

            Assert.IsFalse(result);
        }
    }
}