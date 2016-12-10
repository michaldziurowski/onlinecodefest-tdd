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
        public void Bishop_MoveNFieldsDiagonallyRightTop_Correct()
        {
            var piece = new PieceOnChessBoard
            {
                Position = new Position("a1")
            };

            var bishop = new Bishop(piece);
            var result = true;
            var possibleMovesHorizontally = new[] { "b", "c", "d", "e", "f", "g", "h" };
            var idxVertically = 2;

            foreach (var possibleMoveHorizontally in possibleMovesHorizontally)
            {
                if (!bishop.MoveTo(possibleMoveHorizontally + idxVertically))
                {
                    result = false;
                }

                idxVertically++;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Bishop_MoveNFieldsDiagonallyLeftDown_Correct()
        {
            var piece = new PieceOnChessBoard
            {
                Position = new Position("h8")
            };

            var bishop = new Bishop(piece);
            var result = true;
            var possibleMovesHorizontally = new[] { "g","f","e","d","c","b","a" };
            var idxVertically = 7;

            foreach (var possibleMoveHorizontally in possibleMovesHorizontally)
            {
                if (!bishop.MoveTo(possibleMoveHorizontally + idxVertically))
                {
                    result = false;
                }

                idxVertically--;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Bishop_MoveNFieldsDiagonallyLeftTop_Correct()
        {
            var piece = new PieceOnChessBoard
            {
                Position = new Position("h1")
            };

            var bishop = new Bishop(piece);
            var result = true;
            var possibleMovesHorizontally = new[] { "g", "f", "e", "d", "c", "b", "a" };
            var idxVertically = 2;

            foreach (var possibleMoveHorizontally in possibleMovesHorizontally)
            {
                if (!bishop.MoveTo(possibleMoveHorizontally + idxVertically))
                {
                    result = false;
                }

                idxVertically++;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Bishop_MoveNFieldsDiagonallyRightDown_Correct()
        {
            var piece = new PieceOnChessBoard
            {
                Position = new Position("a8")
            };

            var bishop = new Bishop(piece);
            var result = true;
            var possibleMovesHorizontally = new[] { "b", "c", "d", "e", "f", "g", "h" };
            var idxVertically = 7;

            foreach (var possibleMoveHorizontally in possibleMovesHorizontally)
            {
                if (!bishop.MoveTo(possibleMoveHorizontally + idxVertically))
                {
                    result = false;
                }

                idxVertically--;
            }

            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void Bishop_MoveNFieldUpVertically_Incorrect()
        {
            var piece = new PieceOnChessBoard
            {
                Position = new Position("a1")
            };

            var bishop = new Bishop(piece);
            var result = false;
            
            for (var idxVerically = 2; idxVerically<=8;idxVerically++)
            {
                if (bishop.MoveTo("a" + idxVerically))
                {
                    result = true;
                }
            }

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Bishop_MoveNFieldDownVerically_Incorrect()
        {
            var piece = new PieceOnChessBoard
            {
                Position = new Position("a8")
            };

            var bishop = new Bishop(piece);
            var result = false;

            for (var idxVerically = 7; idxVerically >= 1; idxVerically--)
            {
                if (bishop.MoveTo("a" + idxVerically))
                {
                    result = true;
                }
            }

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Bishop_MoveNFieldsRightHorizontally_Incorrect()
        {
            var piece = new PieceOnChessBoard
            {
                Position = new Position("a1")
            };

            var bishop = new Bishop(piece);
            var result = false;
            var possibleMovesHorizontally = new[] { "b", "c", "d", "e", "f", "g", "h" };
            

            foreach (var possibleMoveHorizontally in possibleMovesHorizontally)
            {
                if (bishop.MoveTo(possibleMoveHorizontally + "1"))
                {
                    result = true;
                }
            }

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Bishop_MoveNFieldLeftHorizontally_Incorrect()
        {
            var piece = new PieceOnChessBoard
            {
                Position = new Position("h1")
            };

            var bishop = new Bishop(piece);
            var result = false;
            var possibleMovesHorizontally = new[] { "g", "f", "e", "d", "c", "b", "a" };


            foreach (var possibleMoveHorizontally in possibleMovesHorizontally)
            {
                if (bishop.MoveTo(possibleMoveHorizontally + "1"))
                {
                    result = true;
                }
            }

            Assert.IsFalse(result);
        }
    }
}