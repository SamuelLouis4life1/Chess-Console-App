﻿using System;
using System.Collections.Generic;
using System.Text;

namespace chessboard
{
    class Chessboard
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Chessboard (int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece [lines, columns];
        }

        public Piece piece (int lines, int columns)
        {
            return pieces[lines, columns];
        }
    }
}
