using board;

namespace chessPieces
{
    class King : Piece
    {
    
        public King(Board board, Color color)
            : base(board, color) 
        {
        }

        public override string ToString()
        {
            return "R";
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

            return movs;

        }

        private bool CanMove(Position position) 
        {
            Piece p = Board.Piece(position);

            return p == null || p.Color != this.Color;
        }

    }
}
