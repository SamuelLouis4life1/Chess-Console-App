using chessboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Chessboard chessboard, Color color) : base(chessboard, color)
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

            position.setValues(position.line - 1, position.column - 2);
            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            position.setValues(position.line - 2, position.column - 1);
            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            position.setValues(position.line - 2, position.column + 1);
            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            position.setValues(position.line - 1, position.column + 2);
            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            position.setValues(position.line + 1, position.column + 2);
            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            position.setValues(position.line +2 , position.column + 1);
            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            position.setValues(position.line + 2, position.column - 1);
            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            position.setValues(position.line + 1, position.column - 2);
            if (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
            }

            return array;
        }
    }
}
