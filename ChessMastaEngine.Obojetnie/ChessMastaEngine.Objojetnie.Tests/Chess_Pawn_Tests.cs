using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessMastaEngine.Obojetnie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessMastaEngine.Objojetnie.Tests
{
    [TestClass]
    public class Chess_Pawn_Tests
    {
        private PieceOnChessBoard _myPiece;
        [TestInitialize]
        public void InitTest()
        {
            _myPiece = new PieceOnChessBoard
            {
                Position = new Position("d4"),
            };
        }

        [TestMethod]
        public void PawnWhite_VerticallyOneFieldUp_Correct()
        {
            _myPiece.Color = Color.White;
            
            var rook = new Pawn(_myPiece);
            bool result = rook.MoveTo("d5");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PawnBlack_VerticallyOneFieldUp_Incorrect()
        {
            _myPiece.Color = Color.Black;

            var rook = new Pawn(_myPiece);
            bool result = rook.MoveTo("d5");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Pawn_HorizontallyRightOneField_Incorrect()
        {
            _myPiece.Color = Color.White;

            var rook = new Pawn(_myPiece);
            bool result = rook.MoveTo("e4");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Pawn_HorizontallyLeftOneField_Incorrect()
        {
            _myPiece.Color = Color.White;

            var rook = new Pawn(_myPiece);
            bool result = rook.MoveTo("c4");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Pawn_2Up3RightField_Incorrect()
        {
            _myPiece.Color = Color.White;

            var rook = new Pawn(_myPiece);
            bool result = rook.MoveTo("f7");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_InitialMove2FieldsUp_Correct()
        {
            _myPiece.Color = Color.White;

            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d2"),
                Color = Color.White
            });

            bool result = rook.MoveTo("d4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PawnBlack_InitialMove2FieldsDown_Correct()
        {
            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d7"),
                Color = Color.Black
            });

            bool result = rook.MoveTo("d5");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PawnBlack_Move2FieldsDown_Incorrect()
        {
            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d6"),
                Color = Color.Black
            });

            bool result = rook.MoveTo("d4");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_Move2FieldsUp_Incorrect()
        {
            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d4"),
                Color = Color.White
            });

            bool result = rook.MoveTo("d6");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_Move3FieldsUp_Incorrect()
        {
            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d4"),
                Color = Color.White
            });

            bool result = rook.MoveTo("d7");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_Move3FieldsUpFromInitField_Incorrect()
        {
            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d2"),
                Color = Color.White
            });

            bool result = rook.MoveTo("d5");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_MoveFiled1Up1Right_Incorrect()
        {
            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d2"),
                Color = Color.White
            });

            bool result = rook.MoveTo("e3");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_MoveFiled1Up1Left_Incorrect()
        {
            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d2"),
                Color = Color.White
            });

            bool result = rook.MoveTo("c3");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_MoveFiled1Down1Left_Incorrect()
        {
            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d2"),
                Color = Color.White
            });

            bool result = rook.MoveTo("a3");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_MoveFiled1Up1LeftOnFieldTakebByOpposite_Correct()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("e3"),
                    Color = Color.Black
                }
            };

            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d2"),
                Color = Color.White
            }, piecesOnBoard);

            bool result = rook.MoveTo("e3");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PawnBlack_MoveFiled1Down1LeftOnFieldTakebByOpposite_Correct()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("c3"),
                    Color = Color.White
                }
            };

            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d4"),
                Color = Color.Black
            }, piecesOnBoard);

            bool result = rook.MoveTo("c3");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PawnBlack_MoveFiled1Down1LeftOnFieldTakebByTheSameColor_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("c3"),
                    Color = Color.Black
                }
            };

            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d4"),
                Color = Color.Black
            }, piecesOnBoard);

            bool result = rook.MoveTo("c3");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_MoveFiled1Up1LeftOnFieldTakebByTheSameColor_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("c5"),
                    Color = Color.White
                }
            };

            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d4"),
                Color = Color.White
            }, piecesOnBoard);

            bool result = rook.MoveTo("c5");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_Move2UpWithPieceInBetween_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("d3"),
                    Color = Color.White
                }
            };

            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d2"),
                Color = Color.White
            }, piecesOnBoard);

            bool result = rook.MoveTo("d4");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PawnWhite_Move3UpWithPieceInBetween_Incorrect()
        {
            List<PieceOnChessBoard> piecesOnBoard = new List<PieceOnChessBoard>
            {
                new PieceOnChessBoard
                {
                    Position =new Position("d3"),
                    Color = Color.White
                }
            };

            var rook = new Pawn(new PieceOnChessBoard
            {
                Position = new Position("d2"),
                Color = Color.White
            }, piecesOnBoard);

            bool result = rook.MoveTo("d5");

            Assert.IsFalse(result);
        }
    }
}
