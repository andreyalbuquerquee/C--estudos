using board;
using Xadrez.chessPieces;

namespace chessPieces
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;
        public bool Check { get; private set; }
        public Piece VulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            Check = false;
            VulnerableEnPassant = null;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        public Piece MakeMove(Position origin, Position target)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovsMade();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
            if (capturedPiece != null) CapturedPieces.Add(capturedPiece);

            // #JogadaEspecial roque pequeno
            if (p is King && target.Column == (origin.Column + 2))
            {
                Position towerOrigin = new Position(origin.Row, origin.Column + 3);
                Position towerTarget = new Position(origin.Row, origin.Column + 1);
                Piece tower = Board.RemovePiece(towerOrigin);
                tower.IncreaseMovsMade();
                Board.PlacePiece(tower, towerTarget);
            }

            // #JogadaEspecial roque grande
            
            if (p is King && target.Column == origin.Column - 2) 
            {
                Position towerOrigin = new Position(origin.Row, origin.Column - 4);
                Position towerTarget = new Position(origin.Row, origin.Column - 1);
                Piece tower = Board.RemovePiece(towerOrigin);
                tower.IncreaseMovsMade();
                Board.PlacePiece(tower, towerTarget);
            }

            // #JogadaEspecial en passant
            if (p is Pawn && target.Column != origin.Column && capturedPiece == null) 
            {
                Position capturedPawnPosition;
                if (p.Color == Color.White)
                {
                    capturedPawnPosition = new Position(target.Row + 1, target.Column);
                }
                else
                {
                    capturedPawnPosition = new Position(target.Row - 1, target.Column);
                }
                capturedPiece = Board.RemovePiece(capturedPawnPosition);
                CapturedPieces.Add(capturedPiece);
            }
            
            return capturedPiece;
        }

        public void UnmakeMove(Position origin, Position target, Piece capturedPiece)
        {
            Piece movedPiece = Board.RemovePiece(target);
            movedPiece.DecreaseMovsMade();
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, target);
                CapturedPieces.Remove(capturedPiece);
            }
            Board.PlacePiece(movedPiece, origin);

            // #JogadaEspecial roque pequeno
            if (movedPiece is King && target.Column == origin.Column + 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Column + 3);
                Position towerTarget = new Position(origin.Row, target.Column + 1);
                Piece tower = Board.RemovePiece(towerTarget);
                tower.DecreaseMovsMade();
                Board.PlacePiece(tower, towerOrigin);
            }

            // #JogadaEspecial roque grande

            if (movedPiece is King && target.Column == origin.Column - 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Column - 4);
                Position towerTarget = new Position(origin.Row, origin.Column - 1);
                Piece tower = Board.RemovePiece(towerTarget);
                tower.DecreaseMovsMade();
                Board.PlacePiece(tower, towerOrigin);
            }

            // #JogadaEspecial en passant
            if (movedPiece is Pawn && origin.Column != target.Column && capturedPiece == VulnerableEnPassant) 
            {
                Piece pawn = Board.RemovePiece(target);
                Position pawnPosition;
                if (movedPiece.Color == Color.White)
                {
                    pawnPosition = new Position(3, target.Column);
                }
                else
                {
                    pawnPosition = new Position(4, target.Column);
                }
                Board.PlacePiece(pawn, pawnPosition);
            }
        }
        
        public void MakePlay(Position origin, Position target) 
        {
            Piece capturedPiece = MakeMove(origin, target);

            if (IsKingInCheck(ActualPlayer))
            {
                UnmakeMove(origin, target, capturedPiece);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            Piece p = Board.Piece(target);

            // #JogadaEspecial promoção
            if (p is Pawn && (p.Color == Color.White && target.Column == 0 || p.Color == Color.Black && target.Column == 7))
            {
                p = Board.RemovePiece(target);
                Pieces.Remove(p);
                Piece queen = new Queen(Board, p.Color);
                Board.PlacePiece(queen, target);
                Pieces.Add(queen);
            }

            Check = IsKingInCheck(EnemyColor(ActualPlayer));

            if (IsKingInCheckmate(EnemyColor(ActualPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }


            // #JogadaEspecial EnPassant
            VulnerableEnPassant = p is Pawn && (target.Row == origin.Row + 2 || target.Row == origin.Row - 2) ? p : null;
            
        }

        public void ValidateOriginPosition(Position origin)
        {
            if (Board.Piece(origin) == null) throw new BoardException("Não há peças nessa posição!");
            if (ActualPlayer != Board.Piece(origin).Color) throw new BoardException("Essa peça escolhida não é sua!");
            if (!Board.Piece(origin).HasPossibleMovs()) throw new BoardException("Não há movimentos possíveis para essa peça!");
        }
        
        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (!Board.Piece(origin).PossibleMov(target)) throw new BoardException("Posição de destino inválida!");
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
        
        private static Color EnemyColor(Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }

        private Piece King(Color color)
        {
            foreach(Piece p in PiecesInGameByColor(color))
            {
                if (p is King) return p;
            }
            return null;
        }
        
        public bool IsKingInCheck(Color color)
        {
            // Não é pra isso acontecer, mas estou colocando só pra proteger, caso não instancie um rei no tabuleiro
            Piece king = King(color) ?? throw new BoardException("Não há rei no tabuleiro!");
            foreach (Piece p in PiecesInGameByColor(EnemyColor(color)))
            {
                bool[,] possiblePieceMoves = p.PossibleMovs();
                if (possiblePieceMoves[king.Position.Row, king.Position.Column])
                {
                    return true;
                } 
            }

            return false;
        }
        
        public bool IsKingInCheckmate(Color color)
        {
            if (!IsKingInCheck(color)) return false;
            foreach(Piece p in PiecesInGameByColor(color))
            {
                bool[,] possibleMovs = p.PossibleMovs();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (possibleMovs[i, j])
                        {
                            Position origin = p.Position;
                            Position target = new Position(i, j);
                            Piece capturedPiece = MakeMove(origin, target);
                            bool isCheck = IsKingInCheck(color);
                            UnmakeMove(origin, target, capturedPiece);
                            if (!isCheck) return false;
                        }
                    }
                }
            }
            return true;
        }
        
        public void PlaceNewPiece(char column, int row,Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).toPosition());
            Pieces.Add(piece);
        }

        public void PlacePieces()
        {
            // Peças brancas
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
            PlaceNewPiece('b', 1, new Knight(Board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('d', 1, new Queen(Board, Color.White));
            PlaceNewPiece('e', 1, new King(Board, Color.White, this));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 1, new Knight(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));

            // Peças pretas
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('a', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black, this));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Black));
        }


    }
}
