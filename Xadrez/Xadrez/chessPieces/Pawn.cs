using board;

namespace chessPieces
{
    class Pawn : Piece
    {
        
        public Pawn(Board board, Color color) : base(board, color) 
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool HasEnemy(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.Piece(pos) == null;
        }

        public override bool[,] PossibleMovs()
        {
            bool[,] movs = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.SetValues(Position.Row - 1, Position.Column);
                if (Board.IsPositionValid(pos) && Free(pos))
                {
                    movs[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row - 2, Position.Column);
                Position p2 = new Position(pos.Row - 1, pos.Column);
                if (Board.IsPositionValid(p2) && Free(p2) && Board.IsPositionValid(pos) && Free(pos) && MovsMade == 0)
                {
                    movs[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && HasEnemy(pos))
                {
                    movs[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && HasEnemy(pos))
                {
                    movs[pos.Row, pos.Column] = true;
                }
            }
            else
            {
                pos.SetValues(Position.Row + 1, Position.Column);
                if (Board.IsPositionValid(pos) && Free(pos))
                {
                    movs[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row + 2, Position.Column);
                Position p2 = new Position(pos.Row - 1, pos.Column);
                if (Board.IsPositionValid(p2) && Free(p2) && Board.IsPositionValid(pos) && Free(pos) && MovsMade == 0)
                {
                    movs[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && HasEnemy(pos))
                {
                    movs[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && HasEnemy(pos))
                {
                    movs[pos.Row, pos.Column] = true;
                }
            }

            return movs;
        }
    }
}
