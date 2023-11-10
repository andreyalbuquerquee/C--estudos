using board;
using chessPieces;

namespace Xadrez
{
    class Screen
    {
        public static void DisplayMatch(ChessMatch match)
        {
            DisplayBoard(match.Board);
            Console.WriteLine();
            DisplayCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine($"Turno: {match.Turn}");
            Console.WriteLine($"Aguardando jogada: {(match.ActualPlayer == Color.White ? "Brancas" : "Pretas")}");
        }
        
        public static void DisplayCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            DisplayPiecesGroup(match.CapturedPiecesByColor(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            DisplayPiecesGroup(match.CapturedPiecesByColor(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void DisplayPiecesGroup(HashSet<Piece> piecesGroup)
        {
            Console.Write("[");
            foreach(Piece p in piecesGroup)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }
        
        public static void DisplayBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void DisplayBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            ConsoleColor differentBackground = ConsoleColor.DarkMagenta;
            
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    Console.BackgroundColor = possiblePositions[i, j] ? differentBackground : defaultColor;
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = defaultColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = defaultColor;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new ChessPosition(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;

                }
                Console.Write(" ");
            }

            
        }
    }
}
