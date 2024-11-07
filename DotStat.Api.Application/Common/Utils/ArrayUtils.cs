namespace DotStat.Api.Application.Common.Utils;

public static class ArrayUtils
{
  public static T[][] ToArrays<T>(this T[,] arr)
  {
    T[][] jagged = new T[arr.GetLength(0)][];

    for (int i = 0; i < arr.GetLength(0); i++)
    {
      jagged[i] = new T[arr.GetLength(1)];
      for (int j = 0; j < arr.GetLength(1); j++)
      {
        jagged[i][j] = arr[i, j];
      }
    }

    return [.. jagged];
  }
}