using chessboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class Pawn : Piece
    {

        private ChessMatch chessMatch;

        public Pawn (Chessboard chessboard, Color color, ChessMatch chessMatch) : base(chessboard, color)
        {
            this.chessMatch = chessMatch;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeEnemy(Position position)
        {
            Piece piece = chessboard.piece(position);
            return piece != null && piece.color != color;
        }

        private bool free(Position position)
        {
            return chessboard.piece(position) == null;
        }


        public override bool[,] possibleMovements()
        {
            bool[,] array = new bool[chessboard.lines, chessboard.columns];

            Position position = new Position(0, 0);

            if (color == Color.Whrite)
            {
                position.setValues(position.line - 1, position.column);
                if (chessboard.ValidPosition(position) && free(position))
                {
                    array[position.line, position.column] = true;
                }

                position.setValues(position.line - 2, position.column);
                Position p2 = new Position(position.line - 1, position.column);
                if (chessboard.ValidPosition(p2) && free(p2) && chessboard.ValidPosition(position) && free (position) && movementAmount == 0)
                {
                    array[position.line, position.column] = true;
                }

                position.setValues(position.line - 1, position.column - 1);
                if (chessboard.ValidPosition(position) && existeEnemy(position))
                {
                    array[position.line, position.column] = true;
                }

                position.setValues(position.line - 1, position.column + 1);
                if (chessboard.ValidPosition(position) && existeEnemy(position))
                {
                    array[position.line, position.column] = true;
                }
                
                // special move en passant 
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (chessboard.ValidPosition(left) && existeEnemy(left) && chessboard.piece(left) == chessMatch.vulnerableEnPassant)
                    {
                        array[left.line - 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (chessboard.ValidPosition(right) && existeEnemy(right) && chessboard.piece(right) == chessMatch.vulnerableEnPassant)
                    {
                        array[right.line - 1, right.column] = true;
                    }
                }
            }
            else
            {
                position.setValues(position.line + 1, position.column);
                if (chessboard.ValidPosition(position) && free(position))
                {
                    array[position.line, position.column] = true;
                }

                position.setValues(position.line + 2, position.column);
                Position p2 = new Position(position.line + 1, position.column);
                if (chessboard.ValidPosition(p2) && free(p2) && chessboard.ValidPosition(position) && free(position) && movementAmount == 0)
                {
                    array[position.line, position.column] = true;
                }

                position.setValues(position.line + 1, position.column - 1);
                if (chessboard.ValidPosition(position) && existeEnemy(position))
                {
                    array[position.line, position.column] = true;
                }

                position.setValues(position.line + 1, position.column + 1);
                if (chessboard.ValidPosition(position) && existeEnemy(position))
                {
                    array[position.line, position.column] = true;
                }

                // special move en passant 
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (chessboard.ValidPosition(left) && existeEnemy(left) && chessboard.piece(left) == chessMatch.vulnerableEnPassant)
                    {
                        array[left.line + 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (chessboard.ValidPosition(right) && existeEnemy(right) && chessboard.piece(right) == chessMatch.vulnerableEnPassant)
                    {
                        array[right.line + 1, right.column] = true;
                    }
                }
            }
            return array;
        }
    }
}
