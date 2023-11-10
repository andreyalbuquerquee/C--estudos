using board;

namespace chessPieces
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer {  get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        public void MakeMove(Position origin, Position target)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovsMade();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
            if (capturedPiece != null) CapturedPieces.Add(capturedPiece);
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
        
        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> capturedPiecesByColor = new HashSet<Piece>();
            foreach(Piece p in CapturedPieces)
            {
                if (p.Color == color) capturedPiecesByColor.Add(p);
            }
            return capturedPiecesByColor;
        }

        public HashSet<Piece> PiecesInGameByColor(Color color)
        {
            HashSet<Piece> piecesInGameByColor = new HashSet<Piece>();
            foreach (Piece p in Pieces)
            {
                if (p.Color == color) piecesInGameByColor.Add(p);
            }
            piecesInGameByColor.ExceptWith(CapturedPiecesByColor(color));
            return piecesInGameByColor;
        }
        
        public void PlaceNewPiece(char column, int row,Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).toPosition());
            Pieces.Add(piece);
        }
        
        public void PlacePieces() 
        {
            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));

            PlaceNewPiece('a', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Black));
        }
    }
}
