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
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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

        public void executeMove( Position origin, Position destiny)
        {
            executeMovement(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPossiton(Position position)
        {
            if (board.piece(position) == null)
            {
                throw new ChessBoardException("There is no piece in the chosen position");
            }
            if (currentPlayer != board.piece(position).color)
            {
                throw new ChessBoardException("The original piece chosen is not yours");
            }
            if (!board.piece(position).existingPossibleMovement())
            {
                throw new ChessBoardException("There is no movement possible for the chosen piece ! ");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveFor(destiny))
            {
                throw new ChessBoardException("Invalid destiny position");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.Whrite)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.Whrite;
            }
        }

        private void putPieces()
        {
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition ('c', 1).toPosition());
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition('c', 2).toPosition());
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition('d', 2).toPosition());
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition('e', 2).toPosition());
            board.putPiece(new Rook(board, Color.Whrite), new ChessBoarsPosition('e', 1).toPosition());


            board.putPiece(new King(board, Color.Whrite), new ChessBoarsPosition('c', 7).toPosition());
            board.putPiece(new King(board, Color.Whrite), new ChessBoarsPosition('c', 6).toPosition());
            board.putPiece(new King(board, Color.Whrite), new ChessBoarsPosition('d', 7).toPosition());
            board.putPiece(new King(board, Color.Whrite), new ChessBoarsPosition('e', 6).toPosition());
            board.putPiece(new King(board, Color.Whrite), new ChessBoarsPosition('e', 5).toPosition());

        }
    }
}
