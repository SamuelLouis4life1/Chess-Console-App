using System;
using chessboard;
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
                    if(board.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.piece(i, j) + "  ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write(" a b c d e f g h");
        }
    }
}
