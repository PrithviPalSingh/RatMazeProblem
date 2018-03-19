using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatMazeProblem
{
    class Program
    {
        static int N = 4;
        static void Main(string[] args)
        {
            int[,] maze = new int[4, 4] { { 1, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 1, 0, 0 }, { 1, 1, 1, 1 } };
            solveMaze(maze);
            Console.Read();
        }

        /* This function solves the Maze problem using
       Backtracking. It mainly uses solveMazeUtil()
       to solve the problem. It returns false if no
       path is possible, otherwise return true and
       prints the path in the form of 1s. Please note
       that there may be more than one solutions, this
       function prints one of the feasible solutions.*/
        static bool solveMaze(int[,] maze)
        {
            int[,] sol = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };

            if (!solveMazeUtil(maze, 0, 0, sol))
            {
                Console.WriteLine("Solution doesn't exist");
                return false;
            }

            printSolution(sol);
            return true;
        }

        /* A utility function to print solution matrix
        sol[N][N] */
        static void printSolution(int[,] sol)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + sol[i, j] + " ");

                Console.WriteLine();
            }
        }

        /* A utility function to check if x,y is valid
            index for N*N maze */
        static bool isSafe(int[,] maze, int x, int y)
        {
            // if (x,y outside maze) return false
            return (x >= 0 && x < N && y >= 0 &&
                    y < N && maze[x, y] == 1);
        }

        /* A recursive utility function to solve Maze problem */
        static bool solveMazeUtil(int[,] maze, int x, int y, int[,] sol)
        {
            // if (x,y is goal) return true
            if (x == N - 1 && y == N - 1)
            {
                sol[x, y] = 1;
                return true;
            }

            // Check if maze[x][y] is valid
            if (isSafe(maze, x, y) == true)
            {
                // mark x,y as part of solution path
                sol[x, y] = 1;

                /* Move forward in x direction */
                if (solveMazeUtil(maze, x + 1, y, sol))
                    return true;

                /* If moving in x direction doesn't give solution then
                   Move down in y direction  */
                if (solveMazeUtil(maze, x, y + 1, sol))
                    return true;

                /* If none of the above movements work then BACKTRACK: 
                    unmark x,y as part of solution path */
                sol[x, y] = 0;
                return false;
            }

            return false;
        }
    }
}
