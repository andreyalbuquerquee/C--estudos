using board;

namespace chessPieces
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer {  get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
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

        public void MakePlay(Position origin, Position target) 
        {
            MakeMove(origin, target);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position origin)
        {
            if (Board.Piece(origin) == null) throw new BoardException("Não há peças nessa posição!");
            if (ActualPlayer != Board.Piece(origin).Color) throw new BoardException("Essa peça escolhida não é sua!");
            if (!Board.Piece(origin).HasPossibleMovs()) throw new BoardException("Não há movimentos possíveis para essa peça!");
        }
        
        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (!Board.Piece(origin).CanMoveTo(target)) throw new BoardException("Posição de destino inválida!");
        }
        
        private void ChangePlayer() 
        {
            ActualPlayer = ActualPlayer == Color.White ? Color.Black : Color.White;
        }
        
        public void PlacePieces() 
        {
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('a', 1).toPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('h', 1).toPosition());
        }
    }
}
