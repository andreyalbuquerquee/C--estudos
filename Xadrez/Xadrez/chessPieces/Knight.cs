using board;

namespace Xadrez.chessPieces
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) 
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovs()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            pos.SetValues(Position.Row - 1, Position.Column - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Position.Row - 2, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Position.Row - 2, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Position.Row - 1, Position.Column + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Position.Row + 1, Position.Column + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Position.Row + 2, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Position.Row + 2, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Position.Row + 1, Position.Column - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}
