using System;

class Program
{
    //Page 33 Question 15
    public static double T15(int n)
    {
        return T15(n, 1, 1);
    }
    //current => the number we are at (1,2,3.....). We need from 1 to n
    //mone => The index of where we are. We need to add all the negative numbers from 1 to n
    //If the index we are at is even, we square root the current and multiply by -1
    //If the index is odd, we just add the number itself

    //If n = 6 => 1 + -sqrt(3) + 5 + -sqrt(7) + 9 + -sqrt(11)
    public static double T15(int n, int current, int mone)
    {
        double tosefet = current; 
        if (mone > n)
            return 0;
        if(mone % 2 == 0)
            tosefet = (-1)* Math.Sqrt(current);
        
        return tosefet + T15(n, current+2, mone+1);

    }
    //Page 33 Question 16
    //Get 2 numbers and give all the multiples of n1 that are smaller than n2
    
    public static int T16(int n1, int n2)
    {

        return T16(n1, n2, 1);
    }
    public static int T16(int n1, int n2, int kofel)
    {
        int tosefet = n1 * kofel;
        if (n1 * kofel >= n2)
            return 0;
        return tosefet + T16(n1, n2, kofel + 1);
    }
    //Page 33 Question 17
    //0,1,1,2,5,29,........
    public static int T17PT1(int n)
    {
        return T17PT1(0,1,n, 1);
    }
    public static int T17PT1(int n1, int n2, int n, int mone)
    {
        if (mone == n)
            return n1;
        return T17PT1(n2, (n1*n1)+(n2*n2), n, mone+1);
    }
    
    public static void Main()
    {
        Console.WriteLine(T17PT2(6));
    }
}