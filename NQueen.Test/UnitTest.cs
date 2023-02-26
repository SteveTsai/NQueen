using Microsoft.VisualStudio.TestTools.UnitTesting;

using NQueen;
using NQueen2;

namespace NQueen.Test;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void TestIsSafe()
    {
        // 1. test with empty board
        int[,] board = {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 }
            };
        
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                Assert.IsTrue(BackTracking.IsSafe(board, i, j, 4));

        // 2. test existing board
        int[,] board2 = {
            { 0, 1, 0, 0 }, 
            { 0, 0, 0, 1 }, 
            { 1, 0, 0, 0 }, 
            { 0, 0, 1, 0 }
            };
        
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                //if ((i != j) && (i != 0) && (j != 0))
                if (1 == board2[i, j])
                {
                    // remove queen, check if place here is safe, place queen back
                    board2[i, j] = 0;
                    Assert.IsTrue(BackTracking.IsSafe(board2, i, j, 4));
                    board2[i, j] = 1;
                }
            }
    }

    [TestMethod]
    public void Test2Solvers()
    {
        for (int n = 4; n <= 25; n++)
        {
            int[,] board = new int[n, n];

            BackTracking.Init (false);
            var isSolved = BackTracking.BoardSolver(board, 0, n);
            Assert.IsTrue (isSolved);

            int ans = 0;
            int[,] board2 = new int[n, n];

            BackTrackingBitArray.Init (n, false);
            isSolved = BackTrackingBitArray.Solve(board2, 0, n, ref ans);
            Assert.IsTrue (isSolved);

            // Cross refenece if 2 solutions are the same.
            // Note that 2 matrix are transpose. 
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Assert.AreEqual(board[i, j], board2[j, i]);
        }
    }

    [TestMethod]
    public void Test2SolverAllSolutionCounts()
    {
        for (int n = 4; n <= 12; n++)
        {
            int[,] board = new int[n, n];

            BackTracking.Init (true);
            var isSolved = BackTracking.BoardSolver(board, 0, n);

            // It run out all possible solution the return is false.
            Assert.IsFalse (isSolved);

            int ans = 0;
            int[,] board2 = new int[n, n];

            BackTrackingBitArray.Init (n, true);
            isSolved = BackTrackingBitArray.Solve(board2, 0, n, ref ans);

            // It run out all possible solution the return is false.
            Assert.IsFalse (isSolved);

            Assert.AreEqual(BackTracking.SolutionsCount, ans);
        }
    }

}