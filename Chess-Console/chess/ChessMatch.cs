using System;
using Chess_Console.chessboard;
using chessboard;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class ChessMatch
    {
        public Chessboard board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool finished { get; set;}

        public ChessMatch()
        {
            board = new Chessboard(8, 8);
            turn = 1;
            currentPlayer = Color.Whrite;
            finished = false;
            putPieces();
        }

        public void executeMovement(Position origin, Position destiny )
        {
            Piece piece = board.RemovePiece(origin);
            piece.increaseMovementAmount();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.putPiece(piece, destiny);
        }

        private void putPieces()
        {
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition ('c', 1).toPosition());
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition('c', 2).toPosition());
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition('d', 2).toPosition());
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition('e', 2).toPosition());
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition('e', 1).toPosition());

        }
    }
}
