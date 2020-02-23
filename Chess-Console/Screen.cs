﻿using System;
using chessboard;
using chess;
using Chess_Console;
using System.Collections.Generic;
using System.Text;

namespace Chess_Console
{
    class Screen
    {
        public static void PrintChessBoard(Chessboard board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    PrintPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintChessBoard(Chessboard board, bool[,] availablePositions)
        {
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;
            ConsoleColor alterateBackgroundColor = ConsoleColor.DarkRed;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (availablePositions[i, j])
                    {
                        Console.BackgroundColor = alterateBackgroundColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackgroundColor;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackgroundColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackgroundColor;
        }

        public static ChessBoarsPosition readChessPositon()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessBoarsPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.Whrite)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
            }
            Console.Write("");

        }
    }
}
