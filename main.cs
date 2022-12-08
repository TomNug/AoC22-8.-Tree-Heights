using System;
using System.Collections.Generic;


class Program {

  public static bool CheckTreeVisibility(List<List<int>> grid, int i, int j) {
    //Check north
    int blockedCount = 0;
    int height = grid[i][j];
    for (int n=i-1; n>=0; n--) {
      int compVal = grid[n][j];
      if (compVal >= height) {
        blockedCount++;
        Console.WriteLine("\t({0},{1}) broken north by {2}", i, j, compVal);
        break;
      }
    }
    for (int e=j+1; e<grid[0].Count; e++) {
      int compVal = grid[i][e];
      if (compVal >= height) {
        blockedCount++;
        Console.WriteLine("\t({0},{1}) broken east by {2}", i, j, compVal);
        break;
      }
    }
    for (int s=i+1; s<grid.Count; s++) {
      int compVal = grid[s][j];
      if (compVal >= height) {
        blockedCount++;
        Console.WriteLine("\t({0},{1}) broken south by {2}", i, j, compVal);
        break;
      }
    }
    for (int w=j-1; w>=0; w--) {
      int compVal = grid[i][w];
      if (compVal >= height) {
        blockedCount++;
        Console.WriteLine("\t({0},{1}) broken west by {2}", i, j, compVal);
        break;
      }
    }
    if (blockedCount == 4) {
      return false;
    } else {
      return true;
    }
  }
  
  public static int CountVisibleTrees(List<List<int>> grid) {
    int count =0;
    for(int i = 1; i<grid.Count-1; i++) {
      for(int j = 1; j<grid[0].Count-1; j++) {
        
        Console.WriteLine("Checking tree {0} ({1},{2})", grid[i][j],i, j);
        bool visible = CheckTreeVisibility(grid, i, j);
        if (visible) {
          count++;
        }
      }
    }
    count += grid.Count * 2;
    count += (grid[0].Count - 2) * 2;
    
    return count;
      
  }
  public static void DisplayGrid(List<List<int>> grid) {
    foreach(List<int> row in grid) {
      Console.WriteLine(string.Format("{0}", string.Join(", ", row)));
    }
  }
  public static void Main (string[] args) {
    string[] lines = System.IO.File.ReadAllLines(@"trees.txt");

    List<List<int>> grid = new List<List<int>>();
    foreach(string line in lines) {
      List<int> row = new List<int>();
      foreach (char c in line) {
        row.Add((int)Char.GetNumericValue(c));
      }
      grid.Add(row);
    }
    //DisplayGrid(grid);
    int numVisible = CountVisibleTrees(grid);
    Console.WriteLine("{0} visible trees", numVisible);
  }
}