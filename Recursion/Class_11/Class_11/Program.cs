using System;

class Program
{
    //Page 34 Question 21
    public static bool T21(int[] arr)
    {
        return T21(arr,0);
    }
    public static bool T21(int[] arr, int index)
    {
        if(index == arr.Length-1)
        {
            return true;
        }
        if (arr[index] > arr[index + 1]) 
        {
            return false;
        }
        return T21(arr, index + 1);
    }
    
    static int T31(String str)
    {
        return T31(str, 0, 0);
    }

    static int T31(String str, int idx, int result)
    {
        if (idx == str.Length)
            return result;
        if (str[idx] >= 'a' && str[idx] <= 'z')
            result++;
        return T31(str, idx + 1, result);
    }

    //-------------------------------------------------------

    static String T33(String s)
    {
        return T33(s,0);
    }

    static String T33(string str, int idx)
    {
        string tossefet = "";
        if(idx == str.Length)
        {
            return tossefet;
        }
        tossefet = str[idx];
        if(idx%3 == 2)
        {
            tossefet = tossefet + '*';
        }
        return tossefet + T33(str, idx + 1);
    }

    public static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 4 };
        Console.WriteLine(T21(arr));
    }
}