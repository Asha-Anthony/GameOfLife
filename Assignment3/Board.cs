using System;
using static System.Console;

namespace Assignment3
{

    class Board
    {
        // Default height and width of the board
        private const int LENGTH = 20;

        // Width property
        public int Width { get; set; }

        // Height property
        public int Height { get; set; }

        // Cells property
        public char[,] Cells { get; set; }

        private void Init()
        {
            /*
             * Init method to create a 2-D array of characters, 
             * set all cells to space characters
             */
            Console.Clear();
            Cells = new char[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cells[i, j] = ' ';
                }
            }
        }
        public Board(int height, int width)
        {
            /*
             * Constructor to create a board with height and width
             */
            Width = width;
            Height = height;
            Init();
        }

        public Board()
        {
            /*
             * Constructor to create a board with default height(20) and width(20)
             */
            Width = LENGTH;
            Height = LENGTH;
            Init();
        }

        public void Clear()
        {
            /*
             * Set all cells to space characters
             */
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cells[i, j] = ' ';
                }
            }
        }

        public void Print()
        {
            /*
             * Print all cells of the board
             */

            SetCursorPosition(0, 0);
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Write(Cells[i, j]);
                }
                WriteLine();
            }
        }

    }
}
