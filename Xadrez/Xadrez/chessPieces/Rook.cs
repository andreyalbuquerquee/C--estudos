using board;

namespace chessPieces
{
    class Rook : Piece
    {
    
        public Rook(Board board, Color color)
            : base(board, color) 
        {
        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] PossibleMovs()
        {
            bool[,] movs = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // Acima
            pos.SetValues(Position.Row - 1, Position.Column);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movs[pos.Row, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) 
                {
                    break;
                }
                pos.Row--;
            }

            // Abaixo
            pos.SetValues(Position.Row + 1, Position.Column);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movs[pos.Row, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row++;
            }

            // Direita
            pos.SetValues(Position.Row, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movs[pos.Row, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column++;
            }

            // Esquerda
            pos.SetValues(Position.Row, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                movs[pos.Row, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }

            return movs;
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);

            return p == null || p.Color != Color;
        }

    }
}
