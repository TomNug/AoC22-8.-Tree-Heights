using System;
using System.Collections.Generic;


class Program {


  
  public static (bool, int) CalculateVisibilityAndScore(List<List<int>> grid, int i, int j) {
    int northScore = 0;
    int eastScore = 0;
    int southScore = 0;
    int westScore = 0;
    int blockedCount = 0;
    int height = grid[i][j];

    //Check north
    for (int n=i-1; n>=0; n--) {
      int compVal = grid[n][j];
      northScore++;
      if (compVal >= height) {
        blockedCount++;
        //Console.WriteLine("\t({0},{1}) broken north by {2}", i, j, compVal);
        break;
      }
    }

    // Check east
    for (int e=j+1; e<grid[0].Count; e++) {
      eastScore++;
      int compVal = grid[i][e];
      if (compVal >= height) {
        blockedCount++;
        //Console.WriteLine("\t({0},{1}) broken east by {2}", i, j, compVal);
        break;
      }
    }

    // Check south
    for (int s=i+1; s<grid.Count; s++) {
      southScore++;
      int compVal = grid[s][j];
      if (compVal >= height) {
        blockedCount++;
        //Console.WriteLine("\t({0},{1}) broken south by {2}", i, j, compVal);
        break;
      }
    }

    // Check west
    for (int w=j-1; w>=0; w--) {
      westScore++;
      int compVal = grid[i][w];
      if (compVal >= height) {
        blockedCount++;
        //Console.WriteLine("\t({0},{1}) broken west by {2}", i, j, compVal);
        break;
      }
    }

    // If blocked in all 4 directions, not visible
    bool visible = true;
    if (blockedCount == 4) {
      visible = false;
    }
    (bool, int) retVal = (visible, northScore * eastScore * southScore * westScore);
    return retVal;
  }

  



  // Calculates and outputs the number of visible trees and the highest tree score
  public static void CalculateTrees(List<List<int>> grid) {
    int numVisible =0;
    int maxTreeScore = 0;
    for(int i = 1; i<grid.Count-1; i++) {
      for(int j = 1; j<grid[0].Count-1; j++) {
        
        
        (bool, int) visScore = CalculateVisibilityAndScore(grid, i, j);
        bool visible = visScore.Item1;
        int treeScore = visScore.Item2;
        if (visible) {
          //Console.WriteLine("Tree {0} ({1},{2}) is visible and scores {3}", grid[i][j],i, j, treeScore);
          numVisible++;
        } else {
          //Console.WriteLine("Tree {0} ({1},{2}) is not visible and scores {3}", grid[i][j],i, j, treeScore);
        }
        
        if (treeScore>maxTreeScore) {
          maxTreeScore = treeScore;
        }
      }
    }
    // Add the border trees
    numVisible += grid.Count * 2;
    numVisible += (grid[0].Count - 2) * 2;

    Console.WriteLine("There are {0} visible trees", numVisible);
    Console.WriteLine("The highest treescore is {0}", maxTreeScore);      
  }




  
  
  // Outputs the 2D grid
  public static void DisplayGrid(List<List<int>> grid) {
    foreach(List<int> row in grid) {
      Console.WriteLine(string.Format("{0}", string.Join(", ", row)));
    }
  }




  
  public static void Main (string[] args) {
    // Read file
    string[] lines = System.IO.File.ReadAllLines(@"trees.txt");

    // Populate grid with ints from each line
    List<List<int>> grid = new List<List<int>>();
    foreach(string line in lines) {
      List<int> row = new List<int>();
      foreach (char c in line) {
        row.Add((int)Char.GetNumericValue(c));
      }
      grid.Add(row);
    }
    //DisplayGrid(grid);
    CalculateTrees(grid);
    
  }
}