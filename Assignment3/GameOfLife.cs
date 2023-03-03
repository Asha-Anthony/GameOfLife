using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Array;
using System.IO;

namespace Assignment3
{
    class GameOfLife
    {
        private int rows, columns;
        Board Board;
        private int[,] current { get; set; }
        private int[,] next { get; set; }
        private char[,] input { get; set; }

        private void Start()
        {
            int calculatedSecond = 0, currentSecond = 0;               // an integer , recording seconds in Time
            ReadInput();
            Board = new Board(rows, columns);
            current = new int[rows, columns];
            next = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (input[i, j] == '#')
                    {
                        Board.Cells[i, j] = '#';
                        current[i, j] = 1;
                    }
                }
            }
            calculatedSecond = CheckTime();
            Board.Print();
            while (true)
            {
                currentSecond = CheckTime();
                if (calculatedSecond != currentSecond)
                {
                    CreateNextGen();
                    Board.Clear();
                    Array.Clear(current, 0, current.Length);
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            current[i, j] = next[i, j];
                            if (next[i, j] == 1)
                            {
                                Board.Cells[i, j] = '#';
                            }
                        }
                    }
                    Board.Print();
                    Array.Clear(next, 0, next.Length);
                    calculatedSecond = currentSecond;
                }
            }
        }

        private void ReadInput()
        {
            const string IN_FILE = "input.txt";
            string line;
            int count = 0;
            int i = 0, j = 0;

            try
            {
                StreamReader reader = new StreamReader(IN_FILE);
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                    if (count == 1)
                    {
                        rows = int.Parse(line);
                    }
                    else if (count == 2)
                    {
                        columns = int.Parse(line);
                        input = new char[rows, columns];
                    }
                    else
                    {
                        i = int.Parse(line.Substring(0, 1));
                        j = int.Parse(line.Substring(2, 1));
                        input[i, j] = '#';
                    }
                }
                reader.Close();
            }
            catch (IOException e)
            {
                Console.Write(e);
            }
        }

        private int CheckTime()
        {
            int sec;
            DateTime now = DateTime.Now;
            return (sec = now.Second);
        }

        private void CreateNextGen()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    next[i, j] = DetermineState(Board.Cells[i, j], CheckNeighbours(i, j));
                }
            }
        }

        private int CheckNeighbours(int x, int y)
        {
            int noOfNeighbours = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0)
                    { continue; }                                             //exclude self
                    int row = (x + i + rows) % rows;
                    int col = (y + j + columns) % columns;
                    noOfNeighbours += current[row, col];
                }
            }
            return (noOfNeighbours);
        }

        private int DetermineState(char currentState, int neighbourCount)
        {
            int nextState = 0;

            if (currentState == '#' && (neighbourCount == 2 || neighbourCount == 3))
            {
                nextState = 1;
            }
            else if (currentState == ' ' && neighbourCount == 3)
            {
                nextState = 1;
            }
            return nextState;
        }

        public static void Main(string[] args)
        {
            GameOfLife game = new GameOfLife();
            game.Start();
            ReadKey();
        }
    }
}
