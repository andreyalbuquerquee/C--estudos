﻿namespace board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;
        
        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }

        public Piece Piece(int row, int column) 
        {
            return Pieces[row, column];
        }

        public void PlacePiece(Piece piece, Position position) 
        {
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
    }
}
