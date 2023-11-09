using board;
using chessPieces;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args) 
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.DisplayBoard(match.Board);

                    Console.WriteLine();
                    Console.WriteLine("Origem: ");
                    Position origin = Screen.ReadChessPosition().toPosition();

                    bool[,] possiblePositions = match.Board.Piece(origin).PossibleMovs();
                    
                    Console.Clear();
                    Screen.DisplayBoard(match.Board, possiblePositions);
                    
                    Console.WriteLine("Destino: ");
                    Position target = Screen.ReadChessPosition().toPosition();

                    match.MakeMove(origin, target);
                }

            
            }
            catch (BoardException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

