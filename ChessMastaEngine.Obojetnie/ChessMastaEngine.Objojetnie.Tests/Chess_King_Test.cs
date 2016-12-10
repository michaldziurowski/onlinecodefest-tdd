using System.Collections.Generic;
using ChessMastaEngine.Obojetnie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessMastaEngine.Objojetnie.Tests
{
    [TestClass]
    public class Chess_King_Test
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
        public void ChessKing_VerticallyByOneFieldUp_Correct()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("d5");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChessKing_VerticallyByTwoFieldUp_Incorrect()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("d6");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChessKing_VerticallyByTwoFieldDown_Incorrect()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("d2");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChessKing_VerticallyByOneFieldDown_Correct()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("d3");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChessKing_HorizontallyByOneFieldRight_Correct()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("e4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChessKing_HorizontallyByOneFieldLeft_Correct()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("c4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChessKing_HorizontallyByTwoFieldsLeft_Incorrect()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("b4");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChessKing_DiangonalyByOneFieldLeftUp_Correct()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("c5");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChessKing_DiangonalyByOneFieldLeftDown_Correct()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("c3");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChessKing_DiangonalyByOneFieldRightDown_Correct()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("e3");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChessKing_DiangonalyByOneFieldRightUp_Correct()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("e5");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChessKing_DiangonalyByTwoFieldsRightUp_Incorrect()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("e6");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChessKing_DiangonalyByThreeFieldsRightDown_Incorrect()
        {
            var king = new King(_myPiece);
            bool result = king.MoveTo("f6");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChessKing_DontChangePosition_Incorrect()
        {
            var myPiece = new PieceOnChessBoard
            {
                Position = new Position("d4"),
                Color = Color.White
            };
            var king = new King(myPiece);
            bool result = king.MoveTo("d4");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChessKing_FieldUpTakenByPieceFromTheSameColor_Inorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("d5"),
                    Color = Color.White
                }
            };

            var king = new King(_myPiece, piecesOnBoard);
            bool result = king.MoveTo("d5");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChessKing_FieldUpTakenByPieceFromTheOppositeColor_Correct()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("d5"),
                    Color = Color.Black
                }
            };

            var king = new King(_myPiece, piecesOnBoard);
            bool result = king.MoveTo("d5");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChessKing_TwoFieldUpTakenByKingOfTheOppositeColor_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("d6"),
                    Color = Color.Black,
                    IsKing = true
                }
            };

            var king = new King(_myPiece, piecesOnBoard);
            bool result = king.MoveTo("d6");

            Assert.IsFalse(result);
        }
    }
}

