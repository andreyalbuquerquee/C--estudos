using board;

namespace chessPieces
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color ActualPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 0;
            ActualPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void MakeMove(Position origin, Position target)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovsMade();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
        }

        public void PlacePieces() 
        {
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('a', 1).toPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('h', 1).toPosition());
        }
    }
}
