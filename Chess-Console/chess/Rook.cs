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
            return "R";
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

            while (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
                if (chessboard.piece(position) != null && chessboard.piece(position).color != color)
                {
                    break;
                }
                position.line = position.line - 1;
            }

            //below
            position.setValues(position.line + 1, position.column);

            while (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
                if (chessboard.piece(position) != null && chessboard.piece(position).color != color)
                {
                    break;
                }
                position.line = position.line + 1;
            }

            //right
            position.setValues(position.line, position.column + 1);

            while (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
                if (chessboard.piece(position) != null && chessboard.piece(position).color != color)
                {
                    break;
                }
                position.column = position.column + 1;
            }

            //left
            position.setValues(position.line, position.column - 1);

            while (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
                if (chessboard.piece(position) != null && chessboard.piece(position).color != color)
                {
                    break;
                }
                position.column = position.column - 1;
            }

            return array;
        }
    }
}
