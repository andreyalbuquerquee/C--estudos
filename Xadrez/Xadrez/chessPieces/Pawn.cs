using board;
using System.Text;

namespace chessPieces
{
    class Pawn : Piece
    {
        private ChessMatch Match;

        public Pawn(Board board, Color color, ChessMatch match) : base(board, color) 
        {
            Match = match;
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

                // #JogadaEspecial en passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(left) && HasEnemy(left) && Board.Piece(left) == Match.VulnerableEnPassant)
                    {
                        movs[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(right) && HasEnemy(right) && Board.Piece(right) == Match.VulnerableEnPassant)
                    {
                        movs[right.Row - 1, right.Column] = true;
                    }
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

                // #JogadaEspecial en passant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(left) && HasEnemy(left) && Board.Piece(left) == Match.VulnerableEnPassant)
                    {
                        movs[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(right) && HasEnemy(right) && Board.Piece(right) == Match.VulnerableEnPassant)
                    {
                        movs[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return movs;
        }
    }
}
