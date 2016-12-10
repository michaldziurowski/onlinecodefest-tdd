using System;
using System.Collections.Generic;
using CSharpClientSwissChess.Interfaces;

namespace CSharpClientSwissChess
{
    public class MoveProvider : IMoveProvider
    {
        private IDictionary<char, List<MoveVector>> _possibleMoveVectors;

        public MoveProvider(IDictionary<char, List<MoveVector>> possibleMoveVectors)
        {
            _possibleMoveVectors = possibleMoveVectors;
        }

        public MoveProvider()
        {
            _possibleMoveVectors = new Dictionary<char, List<MoveVector>>();
            var kingMoves = new List<MoveVector>();
            kingMoves.Add(new MoveVector(0, 1));
            kingMoves.Add(new MoveVector(1, 0));
            kingMoves.Add(new MoveVector(1, 1));
            kingMoves.Add(new MoveVector(0, -1));
            kingMoves.Add(new MoveVector(-1, 0));
            kingMoves.Add(new MoveVector(-1, -1));

            _possibleMoveVectors.Add('K', kingMoves);

        }
        public IEnumerable<Coordinates> GetPossibleMoves(Board board, MoveParserResult moveParserResult)
        {
            var result = new List<Coordinates>();
            for (int i = 0; i < 8; i++)
            {
                var coord = new Coordinates();
                coord.Letter = (char)(65 + i);
                coord.Number = i + 1;
                var figure = board[coord];
                if (IsFieldEmpty(figure) &&
                       IsDestinationDifferentThanFrom(moveParserResult) &&
                       IsDestinationFieldPossible(moveParserResult) &&
                       !HasCollision(board, moveParserResult))
                {
                    result.Add(coord);
                }
            }

            return result;
        }

        private bool IsDestinationDifferentThanFrom(MoveParserResult moveParserResult)
        {
            var move = moveParserResult.Move;
            return !move.From.Equals(move.To);
        }

        private static bool IsFieldEmpty(IFigure figure)
        {
            return figure != null;
        }

        private bool HasCollision(Board board, MoveParserResult moveParserResult)
        {
            return false;
        }

        private bool IsDestinationFieldPossible(MoveParserResult moveParserResult)
        {
            return true;
        }
    }
}
