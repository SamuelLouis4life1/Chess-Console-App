using System;
using Chess_Console;
using chessboard;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class King : Piece
    {
        private ChessMatch chessmatch;

        public King (Chessboard chessboard, Color color, ChessMatch chessMatch ) : base (chessboard, color)
        {
            this.chessmatch = chessMatch;
        }

        public override string ToString()
        {
            return "Ki";
        }

        private bool canMove(Position position)
        {
            Piece piece = chessboard.piece(position);
            return piece == null || piece.color != color;  
        }

        private bool testRookForCastle (Position position)
        {
            Piece piece = chessboard.piece(position);
            return piece != null && piece is Rook && piece.color == color && piece.movementAmount == 0;
        }


        public override bool[,] possibleMovements()
        {
            bool[,] array = new bool[chessboard.lines, chessboard.columns];

            Position position = new Position(0, 0);

            //above
            position.setValues(position.line - 1, position.column);

            if (chessboard.ValidPosition(position) && canMove(position))
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
            position.setValues(position.line, position.column + 1);

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

            // special move Castle
            if (movementAmount == 0 && !chessmatch.cheque)
            {
                // #special move Castle Kingside
                Position positionRook1 = new Position(position.line, position.column + 3);
                if (testRookForCastle(positionRook1))
                {
                    Position position1 = new Position(position.line, position.column + 1);
                    Position position2 = new Position(position.line, position.column + 2);
                    if (chessboard.piece(position1) == null && chessboard.piece(position2)==null)
                    {
                        array[position.line, position.column + 2] = true;
                    }
                }
                // #special move Castle Queenside
                Position positionRook2 = new Position(position.line, position.column - 4);
                if (testRookForCastle(positionRook2))
                {
                    Position position1 = new Position(position.line, position.column - 1);
                    Position position2 = new Position(position.line, position.column - 2);
                    Position position3 = new Position(position.line, position.column - 3);
                    if (chessboard.piece(position1) == null && chessboard.piece(position2) == null && chessboard.piece(position3) == null)
                    {
                        array[position.line, position.column - 2] = true;
                    }
                }
            }

            return array;
        }
    }
}
