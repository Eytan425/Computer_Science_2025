using System;
using System.Diagnostics.Metrics;

class Program
{
    //Page 32 Question 1 (פעולה מעטפת)
    public static int T01(int n)
    {
        return T01(n, 1);
    }
    public static int T01(int n, int counter)
    {
        if (counter > n)
        {
            return 0;
        }
        return counter + T01(n, counter + 1);
    }
    public static int T01A(int n)
    {
        return T01A(n, 1, 0);
    }
    public static int T01A(int n, int counter, int result)
    {
        if (counter > n)
        {
            return result;
        }
        return T01A(n, counter + 1, result + counter);
    }
    public static int T18(int[] arr, int i)
    {
        return T18(arr, i, 0);
    }
    public static int T18(int[] arr, int i, int counter)
    {
        if(counter > i)
        {
            return 0;
        }
        return arr[counter] + T18(arr, i, counter + 1);
    }
    public static int T18A(int[] arr, int i)
    {
        return T18A(arr, i, 0, 0);
    }
    public static int T18A(int[] arr, int i, int counter, int result)
    {
        if(counter > i)
        {
            return result;
        }
        return T18A(arr, i, counter + 1, result + arr[counter]);
    }
    public static void Main()
    {
        Console.WriteLine(T01A(6, 1, 0));
        Console.WriteLine(T18A([1, 2, 3, 4, 5], 4, 0, 0));
    }
}