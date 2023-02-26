using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace NQueen2
{
    public class BackTrackingBitArray
    {
        static bool bSolveAll = false;
        static BitArray col = new BitArray(40);
        static BitArray d1 = new BitArray(40);
        static BitArray d2 = new BitArray(40);

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

        public static bool Solve (int[,] board, int r, int n, ref int ans)
        {
            if (r == n)
            {
                ans++;

                if (bSolveAll)
                    PrintBoard (board, n);
                return true;
            }

            for (int c = 0; c < n; c++)
            {
                if (!col[c] && !d1[r - c + n - 1] && !d2[r + c])
                {
                    col[c] = d1[r - c + n - 1] = d2[r + c] = true; 
                    board[r, c] = 1;

                    if (Solve (board, r + 1, n, ref ans))
                    {
                        if (!bSolveAll)
                            return true;
                    }

                    col[c] = d1[r - c + n - 1] = d2[r + c] = false;
                    board[r, c] = 0;
                }
            }
            return false;
        }

        public static void Init (int n, bool bAll)
        {
            bSolveAll = bAll;

            // init with 2 * n bit elements with false
            col = new BitArray(2 * n);
            d1 = new BitArray(2 * n);
            d2 = new BitArray(2 * n);
        }

        static void Main(string[] args)
        {
            bool bAll = false;

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

            Init (n, bAll);
            int[,] board = new int[n, n];

            int ans = 0;
            var isSolved = Solve (board, 0, n, ref ans);            

            // if Solve only one solution, print it
            if (!bSolveAll)
            {
                if (isSolved)
                    PrintBoard(board, n);
                else
                    Console.WriteLine("Solution not found.");
            }

            stopwatch.Stop();

            Console.WriteLine($"Found {ans} solutions for a {n}x{n} board in {stopwatch.Elapsed.TotalSeconds} seconds.");
            Console.WriteLine($"Memory used: {(float) GC.GetTotalMemory(true) / (1024 * 1024)} MB");
        }
    }
}