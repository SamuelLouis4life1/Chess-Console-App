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

            //ChessBoarsPosition position = new ChessBoarsPosition('a', 1);

            //Console.WriteLine(position.toPosition());

            //Console.WriteLine(position);

            try
            {
                Chessboard board = new Chessboard(8, 8);

                board.putPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.putPiece(new Rook(board, Color.Black), new Position(1, 6));
                board.putPiece(new King(board, Color.Black), new Position(0, 5));

                Screen.PrintChessBoard(board);

                Console.ReadLine();

            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
