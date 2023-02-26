using System.Diagnostics;

namespace NQueen
{
    public class BackTracking
    {
        static bool bSolveAll = false;
        public static int SolutionsCount {get; set;}
        static void PrintBoard(int[,] board, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
        public static Boolean IsSafe(int[,] board, int row, int col, int n)
        {
            int i, j;
            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1) return false;
            }
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1) return false;
            }
            for (i = row, j = col; j >= 0 && i < n; i++, j--)
            {
                if (board[i, j] == 1) return false;
            }
            return true;
        }
        public static Boolean BoardSolver(int[,] board, int col, int n)
        {
            if (col >= n)
            {
                SolutionsCount++;
                if (bSolveAll)
                    PrintBoard(board, n);
                return true;
            }

            // Consider this column and try placing this queen in all rows one by one 
            for (int i = 0; i < n; i++)
            {
                if (IsSafe(board, i, col, n))
                {
                    board[i, col] = 1;

                    // recur to place rest of the queens
                    if (BoardSolver(board, col + 1, n))
                    {
                        if (!bSolveAll)
                            return true;
                    }

                    // Backtracking is important in this one.  
                    board[i, col] = 0;
                }
            }
            return false;
        }

        public static void Init (bool bAll)
        {
            bSolveAll = bAll;
            SolutionsCount = 0;
        }

        static void Main(string[] args)
        {
            bool bAll = false;

            // Console.WriteLine("State the value of N in this program!");
            // N = Convert.ToInt32(Console.ReadLine());
            if (args.Count() < 1)
            {
                Console.WriteLine("Input square board size as an argument!");
                return;
            }
            else
            {
                if (args.Count() > 1)
                    bAll = Convert.ToBoolean(args[1]);

                Console.WriteLine("Calculating... the board size (N): " + args[0]);
            }

            var stopwatch = Stopwatch.StartNew();

            int n = int.Parse(args[0]);
            int[,] board = new int[n, n];

            Init (bAll);
            var isSolved = BoardSolver(board, 0, n);

            // if Solve only one solution, print it
            if (!bSolveAll)
            {
                if (isSolved)
                    PrintBoard(board, n);
                else
                    Console.WriteLine("Solution not found.");
            }

            stopwatch.Stop();

            Console.WriteLine($"Found {SolutionsCount} solutions for a {n}x{n} board in {stopwatch.Elapsed.TotalSeconds} seconds.");
            Console.WriteLine($"Memory used: {(float)GC.GetTotalMemory(true) / (1024 * 1024)} MB");
        }
    }
}