using System;
using Chess_Console;
using chessboard;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class King : Piece
    {
        public King (Chessboard chessboard, Color color): base (chessboard, color)
        {

        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position position)
        {
            Piece piece = chessboard.piece(position);
            return piece == null || piece.color != color;  
        }

        public override bool[,] possibleMovements()
        {
            bool[,] array = new bool[chessboard.lines, chessboard.columns];

            Position position = new Position(0, 0);

            //above
            position.setValues(position.line - 1, position.column);

            if (chessboard.ValidPosition(position) && canMove (position))
            {
                array[position.line, position.column] = true;
            }

            //northeast
            position.setValues(position.line - 1, position.column + 1);

            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            //right
            position.setValues(position.line, position.column +1);

            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            //southeast
            position.setValues(position.line + 1, position.column + 1);

            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            //below
            position.setValues(position.line + 1, position.column);

            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            //south-west
            position.setValues(position.line + 1, position.column - 1);

            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            //left
            position.setValues(position.line, position.column - 1);

            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            //north-west
            position.setValues(position.line - 1, position.column - 1);

            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }
            return array;
        }
    }
}
