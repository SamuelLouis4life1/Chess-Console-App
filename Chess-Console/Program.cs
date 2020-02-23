using System;
using chess;
using Chess_Console.chessboard;
using chessboard;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
                ChessMatch match = new ChessMatch();


                while (!match.finished)
                {
                    Console.Clear();
                    Screen.PrintChessBoard(match.board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPositon().toPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPositon().toPosition();

                    match.executeMovement(origin, destiny);

                }

            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
