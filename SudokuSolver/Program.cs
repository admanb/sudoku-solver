using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(ConvertToSquare(0, 0));
            Console.WriteLine(ConvertToSquare(7, 7));
            Console.WriteLine(ConvertToSquare(5, 5));
            Console.WriteLine(ConvertToSquare(7, 0));

            List<List<int>> puzzle = new List<List<int>>
            {
                new List<int> { 0, 3, 0, 0, 0, 0, 9, 0, 6 },
                new List<int> { 6, 0, 2, 9, 4, 3, 8, 5, 1 },
                new List<int> { 0, 0, 0, 0, 0, 0, 0, 7, 3 },
                new List<int> { 3, 9, 1, 7, 0, 0, 0, 6, 8 },
                new List<int> { 0, 0, 0, 0, 1, 0, 0, 4, 2 },
                new List<int> { 4, 0, 0, 0, 8, 6, 0, 0, 0 },
                new List<int> { 9, 4, 7, 0, 3, 0, 0, 0, 0 },
                new List<int> { 0, 1, 6, 0, 9, 5, 0, 3, 0 },
                new List<int> { 8, 0, 0, 0, 6, 7, 0, 0, 9 },
            };

            var solver = new Solver(puzzle);
            solver.Print();
        }

        public static int ConvertToSquare(int col, int row)
        {
            return col / 3 + 3 * (row / 3);
        }
    }
}
