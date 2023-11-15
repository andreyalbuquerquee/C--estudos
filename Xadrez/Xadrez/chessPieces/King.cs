using board;

namespace chessPieces
{
    class King : Piece
    {

        private ChessMatch Match;
        
        public King(Board board, Color color, ChessMatch match)
            : base(board, color) 
        {
            Match = match;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool TestTowerCastling(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Rook && p.Color == Color && p.MovsMade == 0;
        }
        
        public override bool[,] PossibleMovs()
        {
            bool[,] movs = new bool[Board.Rows, Board.Columns];
            
            Position pos = new Position(0, 0);

            // Acima
            pos.SetValues(Position.Row - 1, Position.Column);
            if (Board.IsPositionValid(pos) && CanMove(pos)) movs[pos.Row, pos.Column] = true;

            // Nordeste
            pos.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos)) movs[pos.Row, pos.Column] = true;

            // Direita
            pos.SetValues(Position.Row, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos)) movs[pos.Row, pos.Column] = true;

            // Sudeste
            pos.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos)) movs[pos.Row, pos.Column] = true;

            // Abaixo
            pos.SetValues(Position.Row + 1, Position.Column);
            if (Board.IsPositionValid(pos) && CanMove(pos)) movs[pos.Row, pos.Column] = true;

            // Sudoeste
            pos.SetValues(Position.Row + 1, Position.Column -1);
            if (Board.IsPositionValid(pos) && CanMove(pos)) movs[pos.Row, pos.Column] = true;

            // Esquerda
            pos.SetValues(Position.Row, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos)) movs[pos.Row, pos.Column] = true;

            // Noroeste
            pos.SetValues(Position.Row -1, Position.Column -1);
            if (Board.IsPositionValid(pos) && CanMove(pos)) movs[pos.Row, pos.Column] = true;

            // #JogadaEspecial roque
            if (MovsMade == 0 && !Match.Check)
            {
                // roque pequeno
                Position rightTowerPosition = new Position(Position.Row, Position.Column + 3);
                if (TestTowerCastling(rightTowerPosition))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    movs[Position.Row, Position.Column + 2] = Board.Piece(p1) == null && Board.Piece(p2) == null ? true : false;
                }

                // roque grande
                Position leftTowerPosition = new Position(Position.Row, Position.Column - 4);
                if (TestTowerCastling(rightTowerPosition))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    movs[Position.Row, Position.Column - 2] = Board.Piece(p1) == null && Board.Piece(p2) == null
                        && Board.Piece(p3) == null ? true : false;
                }
            }


            return movs;

        }

        private bool CanMove(Position position) 
        {
            Piece p = Board.Piece(position);

            return p == null || p.Color != this.Color;
        }

    }
}
