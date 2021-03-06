﻿using System;
using Chess_Console.chessboard;
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

        public Piece piece(Position position)
        {
            return pieces[position.line, position.column];
        }

        public bool existPieceInPosition(Position position)
        {
            ValidatePosition(position);
            return piece(position) != null;
        }

        public void putPiece(Piece piece, Position postionOnBoard)
        {
            if (existPieceInPosition(postionOnBoard))
            {
                throw new ChessBoardException("There is already a piece in position");
            }
            pieces[postionOnBoard.line, postionOnBoard.column] = piece;
            piece.position = postionOnBoard;
        }

        public Piece RemovePiece(Position position)
        {
            if (piece (position) == null)
            {
                return null;
            }
            Piece aux = piece(position);
            aux.position = null;
            pieces[position.line, position.column] = null;
            return aux;
        }

        public bool ValidPosition(Position position)
        {
            if (position.line < 0 || position.line >=lines || position.column < 0 || position.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new ChessBoardException("Invalid Position");
            }
        }
    }
}
