﻿using board;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args) 
        {
            Board board = new Board(8, 8);

            Screen.DisplayBoard(board);
        }
    }
}
