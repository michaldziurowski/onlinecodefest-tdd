using System.Collections.Generic;
using ChessMastaEngine.Obojetnie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessMastaEngine.Objojetnie.Tests
{
    [TestClass]
    public class Chess_Rook_Tests
    {
        private PieceOnChessBoard _myPiece;
        [TestInitialize]
        public void InitTest()
        {
            _myPiece = new PieceOnChessBoard
            {
                Position = new Position("d4"),
                Color = Color.White
            };
        }

        [TestMethod]
        public void Rook_VerticallyOneFieldUp_Correct()
        {
            var rook = new Rook(_myPiece);
            bool result = rook.MoveTo("d5");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_VerticallyOneFieldDown_Correct()
        {
            var rook = new Rook(_myPiece);
            bool result = rook.MoveTo("d3");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_HorizontallyOneFieldRight_Correct()
        {
            var rook = new Rook(_myPiece);
            bool result = rook.MoveTo("e4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_HorizontallyOneFieldLeft_Correct()
        {
            var rook = new Rook(_myPiece);
            bool result = rook.MoveTo("c4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_DinagonallyRight2Up3_Incorrect()
        {
            var rook = new Rook(_myPiece);
            bool result = rook.MoveTo("f7");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_DinagonallyLeft2Down3_Incorrect()
        {
            var rook = new Rook(_myPiece);
            bool result = rook.MoveTo("b1");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_DinagonallyLeft2Up3_Incorrect()
        {
            var rook = new Rook(_myPiece);
            bool result = rook.MoveTo("b7");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_DontChangePosition_Incorrect()
        {
            var rook = new Rook(_myPiece);
            bool result = rook.MoveTo("d4");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_FieldUpTakenByPieceFromTheSameColor_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("d5"),
                    Color = Color.White
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("d5");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_Field4UpTakenByPieceFromTheSameColor_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("d8"),
                    Color = Color.White
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("d8");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_Field4UpTakenByPieceFromTheOppositeColor_Correct()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("d8"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("d8");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_Field4Up3LeftTakenByPieceFromTheOppositeColor_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("a8"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("a8");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_Field4Up3LeftTakenByPieceFromTheSameColor_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("a8"),
                    Color = Color.White
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("a8");

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void Rook_FieldHorizontallyRightWithOtherPieceInTheMiddle_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position = new Position("f4"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("h4");

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void Rook_FieldHorizontallyLeftWithOtherPieceInTheMiddle_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position = new Position("b4"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("a4");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_FieldVerticallyUpWithOtherPieceInTheMiddle_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position = new Position("d5"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("d8");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_FieldVerticallyDownWithOtherPieceInTheMiddle_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position = new Position("d3"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("d2");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rook_FieldVerticallyDownWithOtherPieceAfterNewPosition_Correct()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position = new Position("d2"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("d3");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_FieldVerticallyUpWithOtherPieceAfterNewPosition_Correct()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position = new Position("d6"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("d5");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_FieldHorizontallyRightWithOtherPieceAfterNewPosition_Correct()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position = new Position("f4"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("e4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_FieldHorizontallyLeftWithOtherPieceBeforeNewPosition_Correct()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position = new Position("a4"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("b4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_FieldUp2Right2WithOtherPieceBeforeNewPosition_Correct()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position = new Position("a4"),
                    Color = Color.Black
                }
            };

            var rook = new Rook(_myPiece, piecesOnBoard);
            bool result = rook.MoveTo("f6");

            Assert.IsFalse(result);
        }
    }
}
