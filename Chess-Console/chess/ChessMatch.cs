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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool cheque { get; private set; }

        public ChessMatch()
        {
            board = new Chessboard(8, 8);
            turn = 1;
            currentPlayer = Color.Whrite;
            finished = false;
            cheque = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public Piece executeMovement(Position origin, Position destiny )
        {
            Piece piece = board.RemovePiece(origin);
            piece.increaseMovementAmount();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.putPiece(piece, destiny);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = board.RemovePiece(destiny);
            piece.decreaseMovementAmount();
            if (capturedPiece != null)
            {
                board.putPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.putPiece(piece, origin);
        }

        public void executeMove( Position origin, Position destiny)
        {
            Piece capturedPiece = executeMovement(origin, destiny);

            if (isInCheck(currentPlayer))
            {
                undoMovement(origin, destiny, capturedPiece);
                throw new ChessBoardException("You can't put yourself in check ");
            }

            if (isInCheck(adversary(currentPlayer)))
            {
                cheque = true;
            }
            else
            {
                cheque = false;
            }

            if (testChequeMate(adversary(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }           
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

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach ( Piece x  in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> pieceInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color adversary(Color color)
        {
            if (color == Color.Whrite)
            {
                return Color.Black;
            }
            else
            {
                return Color.Whrite;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in pieceInPlay(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece Ki = king(color);
            if (Ki == null)
            {
                throw new ChessBoardException("There is no king of color " + color + " on the board !");
            }
            foreach (Piece x in pieceInPlay(adversary(color)))
            {
                bool[,] array = x.possibleMovements();
                if (array[Ki.position.line, Ki.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testChequeMate(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }
            foreach (Piece x in pieceInPlay(color))
            {
                bool[,] array = x.possibleMovements();
                for (int i = 0; i < board.lines; i ++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (array[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = executeMovement(origin, destiny);
                            bool testCheque = isInCheck(color);
                            undoMovement(origin, destiny, capturedPiece);
                            if (!testCheque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new ChessBoarsPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece('a', 1, new Rook(board, Color.Whrite));
            putNewPiece('b', 1, new Knight(board, Color.Whrite));
            putNewPiece('c', 1, new Bishop(board, Color.Whrite));
            putNewPiece('d', 1, new Queen(board, Color.Whrite));
            putNewPiece('e', 1, new King(board, Color.Whrite, this));
            putNewPiece('f', 1, new Bishop(board, Color.Whrite));
            putNewPiece('g', 1, new Knight(board, Color.Whrite));
            putNewPiece('h', 1, new Rook(board, Color.Whrite));
            putNewPiece('a', 2, new Pawn(board, Color.Whrite, this));
            putNewPiece('b', 2, new Pawn(board, Color.Whrite, this));
            putNewPiece('c', 2, new Pawn(board, Color.Whrite, this));
            putNewPiece('d', 2, new Pawn(board, Color.Whrite, this));
            putNewPiece('e', 2, new Pawn(board, Color.Whrite, this));
            putNewPiece('f', 2, new Pawn(board, Color.Whrite, this));
            putNewPiece('g', 2, new Pawn(board, Color.Whrite, this));
            putNewPiece('h', 2, new Pawn(board, Color.Whrite, this));

            putNewPiece('a', 8, new Rook(board, Color.Black));
            putNewPiece('b', 8, new Knight(board, Color.Black));
            putNewPiece('c', 8, new Bishop(board, Color.Black));
            putNewPiece('d', 8, new Queen(board, Color.Black));
            putNewPiece('e', 8, new King(board, Color.Black, this));
            putNewPiece('f', 8, new Bishop(board, Color.Black));
            putNewPiece('g', 8, new Knight(board, Color.Black));
            putNewPiece('h', 8, new Rook(board, Color.Black));
            putNewPiece('a', 7, new Pawn(board, Color.Black, this));
            putNewPiece('b', 7, new Pawn(board, Color.Black, this));
            putNewPiece('c', 7, new Pawn(board, Color.Black, this));
            putNewPiece('d', 7, new Pawn(board, Color.Black, this));
            putNewPiece('e', 7, new Pawn(board, Color.Black, this));
            putNewPiece('f', 7, new Pawn(board, Color.Black, this));
            putNewPiece('g', 7, new Pawn(board, Color.Black, this));
            putNewPiece('h', 7, new Pawn(board, Color.Black, this));
        }
    }
}
