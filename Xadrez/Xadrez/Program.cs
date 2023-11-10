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
                    try
                    {
                        Console.Clear();
                        Screen.DisplayMatch(match);

                        Console.WriteLine();
                        Console.WriteLine("Origem: ");
                        Position origin = Screen.ReadChessPosition().toPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = match.Board.Piece(origin).PossibleMovs();

                        Console.Clear();
                        Screen.DisplayBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.WriteLine("Destino: ");
                        Position target = Screen.ReadChessPosition().toPosition();
                        match.ValidateTargetPosition(origin, target);

                        match.MakePlay(origin, target);
                    }
                    catch (BoardException ex) 
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.DisplayMatch(match);
            
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

