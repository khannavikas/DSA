using System;
using System.Collections.Generic;
using System.Linq;

namespace CCIFinal
{
    public class BackTracking
    {

        //Key to Backtracking/recursion
        // We have Choice/Constraint and a goal to solve

        // General format


        //       bool Solve(configuration conf)
        //       {
        //           if (no more choices) // BASE CASE
        //       return (conf is goal state);
        //           for (all available choices)
        //           {
        //               try one choice c;
        //               // recursively solve after making choice
        //               ok = Solve(conf with choice c made);
        //               if (ok)
        //                   return true;
        //               else
        //                   unmake choice c;
        //               }
        //return false; // tried all choices, no soln found
        //           }


   //    BackTracking(input a)
            // if goal reached
            // add to result 
            // return 

            // for each choice
            //if(choice is valid)
            // choose choice
            //Backtrack 
            //undo choice


        public static void NQueen(int a)
        {
            int[,] x = new int[a, a];

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    x[i, j] = 0;
                }
            }

            SolveNqueen(x, 0, a);
        }

        private static void SolveNqueen(int[,] x, int row, int n)
        {
            if (row == n)
            {
                Console.WriteLine("Sol");
                Print(x);
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (isValidPlace(x, row, col))
                {
                    x[row, col] = 1;
                    SolveNqueen(x, row + 1, n);
                    x[row, col] = 0;
                }
            }
        }

        private static bool isValidPlace(int[,] a, int row, int col)
        {
            // Not in columns
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (a[row, i] == 1)
                    return false;
            }

            for (int r = row - 1; r >= 0; r--)
            {
                if (a[r, col] == 1)
                    return false;
            }

            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (a[i, j] == 1)
                    return false;

            }


            for (int i = row - 1, j = col + 1; i >= 0 && j < a.GetLength(0); i--, j++)
            {
                if (a[i, j] == 1)
                    return false;

            }

            return true;
        }

        private static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    Console.Write(a[i, j] + " ");
                }

                Console.WriteLine();
            }

        }

        #region NQueen N space not Nsq space

        static int[] result = new int[4]; // this array will store the result

        // result[i]=j; means queen at i-th row is placed at j-th column.
        // Queens placed at (x1, y1) and (x2,y2)
        // x1==x2 means same rows, y1==y2 means same columns, |x2-x1|==|y2-y1| means
        // they are placed in diagonals.
        private static bool canPlace(int row, int col)
        {
            // This function will check if queen can be placed (x2,y2), or we can
            // say that Can queen at x2 row is placed at y2 column.
            // for finding the column for x2 row, we will check all the columns for
            // all the rows till x2-1.
            for (int i = 0; i < row; i++)
            {
                //result[i] == y2 => columns are same
                //|i - x2| == |result[i] - y2| => in diagonals.
                if ((result[i] == col)
                        || (Math.Abs(i - row) == Math.Abs(result[i] - col)))
                {
                    return false;
                }
            }
            return true;
        }

        public static void placeQueens(int row, int size)
        {
            for (int col = 0; col < size; col++)
            {
                //check if queen at row can be placed at column.
                if (canPlace(row, col))
                {
                    result[row] = col; // place the queen at this position.
                    if (row + 1 == size)
                    {
                        string x = null;
                        foreach (var item in result)
                        {
                            x += item;
                        }

                        Console.WriteLine(x);
                    }
                    placeQueens(row + 1, size);
                }
            }
        }


        #endregion


        #region Suduko problem

        public static void SudoKuSolve(int a)
        {
            int[,] x = new int[a, a];

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    x[i, j] = 0;
                    if (i == j)
                    {
                        x[i, j] = i + 1;
                    }
                }
            }

            SolveSudoKu(0, 0, x, a);
        }

        private static void SolveSudoKu(int row, int col, int[,] mat, int size)
        {
            if (row == size)
            {
                Console.WriteLine("Sol");
                Print(mat);
                return;
            }

            int nr = 0;
            int nc = 0;

            if (col == size - 1)
            {
                nc = 0;
                nr = row + 1;
            }
            else
            {
                nc = col + 1;
                nr = row;
            }

            if (mat[row, col] != 0)
            {
                SolveSudoKu(nr, nc, mat, size);
            }
            else
            {
                for (int val = 1; val <= 9; val++)
                {
                    if (isValidSukudoPosition(row, col, val, mat))
                    {
                        mat[row, col] = val;
                        SolveSudoKu(nr, nc, mat, size);
                        mat[row, col] = 0;
                    }

                }
            }

        }

        private static bool isValidSukudoPosition(int row, int col, int val, int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (mat[row, i] == val)
                    return false;
            }

            // Check alln rows and same colum
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (mat[i, col] == val)
                    return false;
            }

            int smi = 3 * (row / 3);
            int smj = 3 * (col / 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mat[smi + i, smj + j] == val)
                        return false;
                }
            }

            return true;
        }

        #endregion

        #region Maze Problem

        //Base condition 

        // for options
        // if valid
        // take action
        // recurse
        // undo

        public static void SolveMaze()
        {
            int[,] maze = new int[4, 4];

            maze[0, 0] = 0;
            maze[0, 1] = 0;
            maze[0, 2] = 1;
            maze[0, 3] = 1;

            maze[1, 0] = 0;
            maze[1, 1] = 0;
            maze[1, 2] = 1;
            maze[1, 3] = 0;


            maze[2, 0] = 1;
            maze[2, 1] = 0;
            maze[2, 2] = 1;
            maze[2, 3] = 1;

            maze[3, 0] = 0;
            maze[3, 1] = 0;
            maze[3, 2] = 0;
            maze[3, 3] = 0;

            SolveMaze(maze, 0, 0, 3, 3);
        }

        private static bool SolveMaze(int[,] maze, int strti, int strtj, int endi, int endj)
        {
            if (strti == endi || strtj == endj)
            {
                Print(maze);
                return true;
            }

            if (isValidMazeMove(strti + 1, strtj, maze))
            {
                maze[strti, strtj] = 7;
                SolveMaze(maze, strti + 1, strtj, endi, endj);
                maze[strti, strtj] = 0;
            }

            if (isValidMazeMove(strti, strtj + 1, maze))
            {
                maze[strti, strtj] = 7;
                SolveMaze(maze, strti, strtj + 1, endi, endj);
                maze[strti, strtj] = 0;
            }

            return false;


        }
        
        private static bool isValidMazeMove(int i, int j, int[,] maze)
        {
            if (i >= maze.GetLength(0) || j >= maze.GetLength(0))
                return false;

            return maze[i, j] == 0;
        }

        #endregion

        private static int subsetCount = 0;
        public static void PrintSubset(int[] a, int n, List<int> final)
        {
           
            if (n == 0)
            {
                subsetCount++;
                PrintList(final);
                return;
            }
        
            final.Add(a[n - 1]);
            PrintSubset(a, n - 1, final);
            final.Remove(a[n - 1]);         
            PrintSubset(a, n - 1, final);

        }

        private static void PrintList(List<int> l)
        {
            Console.WriteLine($"Subset start {subsetCount}");
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
           // Console.WriteLine("Subset end");
        }

        static int  totalways = 0;
        public static int NumWaysPaint(int n, int k)
        {

            NumWays(n, k, new string[n]);

            return totalways;

        }


        private static void NumWays(int n, int k, string[] colors)
        {            

            if (colors[0]!=null)//.Any(x=>string.IsNullOrEmpty(x)))
            {
                totalways += 1;
                return;
            }

            if (n == 0 || k == 0)
                return;

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < k; j++)
                {
                    if (isValidColor(i, 2, colors, "c" + j))
                    {
                        colors[i] = "c" + j;
                        NumWays(n - 1, k, colors);
                        colors[i] = null;
                    }

                }

            }
        }

        private static bool isValidColor(int i, int maxConsecutive, string[] colors, string j)
        {

            while (maxConsecutive > 0 && i+1 < colors.Length)
            {
                if (colors[i + 1] == null)
                    return false;
                if (colors[i+1] == j)
                    maxConsecutive--;
                else
                    break;

                i++;
            }

            if (maxConsecutive == 0)
                return false;
            else
                return true;

        }
    }
}
