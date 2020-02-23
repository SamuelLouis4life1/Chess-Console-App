using System;
using chessboard;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Chessboard chessboard, Color color) : base(chessboard, color)
        {

        }

        public override string ToString()
        {
            return "Rook";
        }
    }
}
