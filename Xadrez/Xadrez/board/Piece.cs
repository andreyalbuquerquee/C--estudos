namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovsMade { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            MovsMade = 0;
        }

        public void IncreaseMovsMade() 
        {
            MovsMade++;
        }

        public abstract bool[,] PossibleMovs();

        public bool HasPossibleMovs()
        {
            bool[,] movs = PossibleMovs();

            for (int i = 0; i < Board.Rows; i++) 
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (movs[i, j]) return true;
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position) 
        {
            return PossibleMovs()[position.Row, position.Column];
        }
    }
}
