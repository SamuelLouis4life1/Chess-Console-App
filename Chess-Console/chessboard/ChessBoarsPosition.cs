using System;
using chessboard;
using System.Collections.Generic;
using System.Text;

namespace chessboard
{
    class ChessBoarsPosition
    {
        public char column { get; set; }
        public int line { get; set; }

        public ChessBoarsPosition(char column, int line)
        {
            this.column = column;
            this.line = line;
        }

        public Position toPosition()
        {
            return new Position(8 - line, column - 'a');
        }

        public override string ToString()
        {
            return "" + column + line;
        }
    }
}
