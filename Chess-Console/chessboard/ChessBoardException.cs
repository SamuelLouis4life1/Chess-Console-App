using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Console.chessboard
{
    class ChessBoardException : Exception
    {
        public ChessBoardException (string msg): base(msg)
        {

        }

    }
}
