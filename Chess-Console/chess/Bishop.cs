using chessboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Chessboard chessboard, Color color) : base(chessboard, color)
        {

        }

        public override string ToString()
        {
            return "B";
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

            //north-west
            position.setValues(position.line - 1, position.column - 1);
            while (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
                if (chessboard.piece(position) != null && chessboard.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.line - 1, position.column - 1);
            }

            //north-east 
            position.setValues(position.line - 1, position.column + 1);
            while (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
                if (chessboard.piece(position) != null && chessboard.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.line - 1, position.column + 1);
            }

            //south-east 
            position.setValues(position.line + 1, position.column + 1);
            while (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
                if (chessboard.piece(position) != null && chessboard.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.line + 1, position.column + 1);
            }

            //south-west
            position.setValues(position.line + 1, position.column - 1);
            while (chessboard.ValidPosition(position) && canMove(position))
            {
                array[position.line, position.column] = true;
                if (chessboard.piece(position) != null && chessboard.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.line + 1, position.column - 1);
            }
            return array;
        }
    }
}
