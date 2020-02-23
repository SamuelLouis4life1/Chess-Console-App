using System;
using System.Collections.Generic;
using System.Text;

namespace chessboard
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movementAmount { get; protected set; }
        public Chessboard chessboard { get; protected set; }

        public Piece(Chessboard chessboard, Color color)
        {
            this.position = null;
            this.chessboard = chessboard;
            this.color = color;
            this.movementAmount = 0;
        }       

        public void increaseMovementAmount()
        {
            movementAmount++;
        }

        public bool existingPossibleMovement()
        {
            bool[,] array = possibleMovements();
            for (int i =0; i < chessboard.lines; i ++)
            {
                for (int j = 0; j < chessboard.columns; j ++ )
                {
                    if (array[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveFor(Position position)
        {
            return possibleMovements()[position.line, position.column];
        }

        public abstract bool[,] possibleMovements(); 
    }
}
