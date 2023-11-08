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
            Board board = new Board(8, 8);


            board.PlacePiece(new Rook(board, Color.White), new Position(7, 0));
            board.PlacePiece(new Rook(board, Color.White), new Position(7, 7));

            Screen.DisplayBoard(board);
            }
            catch (BoardException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

