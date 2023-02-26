# NQueen
### Program Architecture:
  * C# Console Program
### Build Source Code:
  * Git clone Repo.
  * Use VS Code or VS to open the project.
  * Visual Studio Code prompts you to add the missing assets to build and debug your app. Select Yes, and Visual Studio Code creates a .vscode folder with launch.json and tasks.json files.
  * Option 1:
    * in .vscode folder
      * in launch.json file modify as the following 
        * "program": "${workspaceFolder}/NQueen/bin/Debug/net6.0/NQueen.dll",
        * "args": ["8"],
    * Click 'F5' or Ctrl-'F5' to run or debug the application, VS code will auto build the application.

  * Option 2:
    * goto NQueen sub-folder (cd NQueen/NQeen)
    * dotnet build  
    * goto NQueen sub-folder (cd NQueen/NQeen2)
    * dotnet build  
### Run:
  * To run 1 solution:
    * cd NQueen/NQeen or cd NQueen/Queen2
    * dotnet run N
    * Ex: dotnet run 20
  * To run all solution:
    * cd NQueen/NQeen or cd NQueen/Queen2
    * dotnet run N true
    * Ex: dotnet run 8 true
### Test:
  * Unit Test can be done for IsSafe(), and Known Solution check.
  * Compare the test result for Back Tracking & Bit Array 2 algorithms.
    The solution and total solution count should be the same if both are correct. 
### Git flow:
  * Feature branch: Local Testing
  * Master branch: Dev 
### Back Tracking Algorithm: Main Concept
  * The idea is to place queens one by one in different columns, starting from the leftmost column. When we place a queen in a column, we check for clashes with already placed queens. In the current column, if we find a row for which there is no clash, we mark this row and column as part of the solution. If we do not find such a row due to clashes, then we backtrack and return false.

  * 1 Start in the leftmost column
  * 2 If all queens are placed,
          return true
  * 3 Try all rows in the current column. 
       Do following for every tried row.
    * a) If the queen can be placed safely in this row 
       then mark this [row, column] as part of the 
       solution and recursively check if placing
       queen here leads to a solution.
    *  b) If placing the queen in [row, column] leads to
       a solution then return true.
    *  c) If placing queen doesn't lead to a solution then
       unmark this [row, column] (Backtrack) and go to 
       step (a) to try other rows.
  * 4  If all rows have been tried and nothing worked, 
        return false to trigger backtracking.

  * Time Complexity: O(N!)
  * Auxiliary Space: O(N2)

### Back Tracking Algorithm 2: Using BitArray without IsSafe()
  * Since without IsSafe() function call, the Time is faster.
  * Time Complexity: O(N!)
  * Auxiliary Space: O(N)

### Discussion
  * Test Run with 2 Algorithms without PrintBoard() function (comment out)
  * The memory usage is close. local variables are free after function call is done.
  * Solve all solution doesn't increase memory usage.  
  <pre><code>
  $ dotnet run 14 rue
  Calculating... the board size (N): 14
  Found 365596 solutions for a 14x14 board in 15.2738301 seconds.
  Memory used: 0.07575989 MB

  $ dotnet run 14 true
  Calculating... the board size (N): 14
  Found 365596 solutions for a 14x14 board in 3.3429521 seconds.
  Memory used: 0.07623291 MB
  </code></pre>
### Referece:
  - [Fun with Backtracking - The N Queen Problem](https://www.c-sharpcorner.com/article/fun-with-backtracking-the-n-queen-problem/) 
  - ["BitSet Algorithm for N-Queens Problem," by Nitin Goel, Journal of Computer Science and Information Technology, vol. 2, no. 2, 2014.](https://www.researchgate.net/publication/288797526_BitSet_Algorithm_for_N-Queens_Problem)
  - [N Queen Problem | Backtracking-3](https://www.geeksforgeeks.org/n-queen-problem-backtracking-3/)
