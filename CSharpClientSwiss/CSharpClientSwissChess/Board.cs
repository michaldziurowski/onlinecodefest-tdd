using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpClientSwissChess.Interfaces;
using Newtonsoft.Json;

namespace CSharpClientSwissChess
{
    public class Board
    {
        public Board(string input)
        {
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(input);
        }

        private Dictionary<Coordinates, IFigure> _board;

        public IFigure this[Coordinates coord]
        {
            get
            {
                if (!_board.ContainsKey(coord))
                {
                    return null;
                }

                return _board[coord];
            }
        }
    }
}