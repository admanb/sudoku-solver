using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    class Solver
    {
        public List<List<int>> Puzzle { get; set; }
        public List<List<bool>> RowValues { get; set; } = new List<List<bool>>();
        public List<List<bool>> ColumnValues { get; set; } = new List<List<bool>>();
        public List<List<bool>> SquareValues { get; set; } = new List<List<bool>>();

        public Solver(List<List<int>> puzzle)
        {
            for(var i = 0; i < 9; i++)
            {
                RowValues.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false });
                ColumnValues.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false });
                SquareValues.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false });
            }

            this.Puzzle = puzzle;
            this.ConfigureInitialPossibilities();
            this.Solve();
        }

        public void Solve()
        {
            var solved = false;
            while (!solved)
            {
                solved = true;
                for (var row = 0; row < 9; row++)
                {
                    for (var col = 0; col < 9; col++)
                    {
                        var val = Puzzle[row][col];
                        if (val == 0)
                        {
                            solved = false;
                            List<int> possibilites = CalculatePossibilities(col, row);
                            if (possibilites.Count == 1)
                            {
                                Puzzle[row][col] = possibilites[0];
                                RowValues[row][possibilites[0]] = true;
                                ColumnValues[col][possibilites[0]] = true;
                                SquareValues[ConvertToSquare(col, row)][possibilites[0]] = true;
                            }
                        }
                    }
                }
            }
        }

        public void ConfigureInitialPossibilities()
        {
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    var val = Puzzle[row][col];
                    if (val != 0)
                    {
                        RowValues[row][val] = true;
                        ColumnValues[col][val] = true;
                        SquareValues[ConvertToSquare(col, row)][val] = true;
                    }
                }
            }
        }

        public List<int> CalculatePossibilities(int col, int row)
        {
            var result = new List<int>();
            var square = ConvertToSquare(col, row);

            for (var i = 1; i <= 9; i++)
            {
                if (!RowValues[row][i] && !ColumnValues[col][i] && !SquareValues[square][i])
                {
                    result.Add(i);
                }
            }

            return result;
        }

        public int ConvertToSquare(int col, int row)
        {
            return col / 3 + 3 * (row / 3);
        }

        public void Print()
        {
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    Console.Write(Puzzle[row][col] + " ");
                }
                Console.Write("\n");
            }
        }

    }
}
