using System;
using chessboard;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard board = new Chessboard(8, 8);

            Screen.PrintChessBoard(board);

            Console.ReadLine();

        }
    }
}
