using System;
using chess;
using Chess_Console;
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
                    try
                    {
                        Console.Clear();
                        Screen.printChessMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPositon().toPosition();
                        match.validateOriginPossiton(origin);

                        bool[,] possiblePositions = match.board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.PrintChessBoard(match.board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readChessPositon().toPosition();
                        match.validateDestinyPosition(origin, destiny);

                        match.executeMove(origin, destiny);
                    }
                    catch (ChessBoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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
