using System;
using System.Collections.Generic;
using System.Text;

namespace chessboard
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movementAmount { get; protected set; }
        public Chessboard chessboard { get; protected set; }

        public Piece (Position position, Chessboard chessboard)
        {
            this.position = position;
            this.chessboard = chessboard;
            this.color = color;
            this.movementAmount = 0;
        }

    }
}
