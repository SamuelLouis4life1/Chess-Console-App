﻿using System;
using chess;
using chessboard;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard board = new Chessboard(8, 8);

            board.putPiece(new Rook(board, Color.Black), new Position(0,0));
            board.putPiece(new Rook(board, Color.Black), new Position(1, 3));
            board.putPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintChessBoard(board);

            Console.ReadLine();

        }
    }
}