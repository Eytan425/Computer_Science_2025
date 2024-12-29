using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //Page 32
    public static int T01(int n)
    {
        if(n == 0)
            return n;
        return n + T01(n-1);    
    }
    public static int T02(int n)
    {
        if(n == 1)
            return n;
        if(n%2 == 0)
            n-=1;
        return n*T02(n-2);    
    }
    public static int T03(int n)
    {
        if(n==1)
            return n;
        return n * T03(n-1);    
    }
    public static int T04(int n)
    {
        int amount = 1;
        if(n < 10)
            return 1;
        return amount+T04( n/10);    

    }
    public static int T05(int n)
    {
        if(n < 10 && n%2==1)
            return 0;
        if((n %10)%2 == 1)
        {
            n/=10;
        }
        return n%10+T05(n/10);
    }
    public static int T06(int num)
    {
        if(num < 10)
            return num;
        return T06(num/10);    
    }
    public static int T07(int num1, int num2)
    {
        //NNum1 > Num2
        if(num1 < num2)
            return 0;
        return 1 + T07(num1-num2, num2);     
    }
    public static int T08(int num1, int num2)
    {
        if(num1 < num2)
        {
            return num1;
        }
        return T08(num1-num2, num2);        
    }
    public static bool T09(int num, int digit)
    {
        if(digit > num)
            return false;
        if(num%10 == digit)
            return true;
        return T09(num/10, digit);
    }
    public static bool T10(int x, int y)
    {
        //x needs to be a multiple of y
        if(x > y)
            return false;
        if((y-x)%2==0)
            return true;
        return T10(x,y-x);
        
    }
    //Page 33
    public static bool T11(int num)
    {
        return T11(num,2);
    }
    public static bool T11(int num, int counter)
    {
        if(counter==num)
        {
            return true;
        }
        if(num%counter==0)
        {
            return false;
        }

        return T11(num, counter+1);    
    }
    public static bool T12(int n)
    {
        if(n==0)
            return true;
        if((n%10)%2 == 0 && ((n/10)%10)%2 != 0 || (n%10)%2 != 0 && ((n/10)%10)%2 == 0)
            return false;
        return T12(n/10);    
    }
    public static bool T13(int num1, int num2)
    {
        if(num1 < 10 && num2 > 10|| num1 > 10 && num2< 10)
            return false;
        if(num1 < 10 && num2 < 10)
            return true;    
        return T13(num1/10, num2/10);
    }
    public static int T14(int n)
    {
        return T14(n, 1, 0);
    }
    public static int T14(int n, int counter, int sum)
    {
        if(n+1==counter)
            return sum;
        if(counter%2!=0)
        {
            sum += counter*2;
        }
        if(counter%2 == 0)
        {
            sum += (counter*counter);
        }
        return T14(n,counter+1, sum);
    }
    public static double T15(int n)
    {
        return T15(n,1,1,0);
    }
    public static double T15(int n, int numAt, int index ,double sum)
    {
        if(index > n)
            return sum;
        if(index%2==0)
            sum += -1*Math.Sqrt(numAt);
        if(index%2 != 0)
            sum+=numAt;
        return T15(n, numAt+2, index+1, sum);    
    }
    public static int T16(int n1, int n2)
    {
        return T16(n1,n2, 1,0);
    }
    public static int T16(int n1, int n2, int multiple, int sum)
    {
        if(multiple > n2)
            return sum;
        if(multiple%n1==0 && multiple < n2)
            sum+=multiple;
        return T16(n1,n2,multiple+1,sum);

    }
    // Calculate the nth Fibonacci number using a recursive helper function.
    public static int T17A(int n) {
        return T17A(0, 1, n, 1);
    }

    // Recursive helper function to calculate the next Fibonacci number.
    public static int T17A(int previousNumber, int currentNumber, int targetIndex, int currentIndex) {
        // Base case: If we've reached the target index, return the current Fibonacci number.
        if (currentIndex == targetIndex) {
            return previousNumber;
        }

        // Calculate the next Fibonacci number by adding the squares of the previous two numbers.
        int nextNumber = previousNumber * previousNumber + currentNumber * currentNumber;

        // Recursively call the helper function with the updated values.
        return T17A(currentNumber, nextNumber, targetIndex, currentIndex + 1);
    }
    // public static int T17B(int n)
    // {
    //     return T17B(0, 1, n, 0);
    // }

    // public static int T17B(int prev, int curr, int n, int sum)
    // {
    //     if (n == 0)
    //     {
    //         return sum;
    //     }
    //     return T17B(curr, prev + curr, n - 1, sum + curr);
    // }
    //Another way
    public static int T17B(int n)
    {
        return T17B(n,0);
    }
    public static int T17B(int n, int sum)
    {
        if(n==0)
            return sum;
        sum += T17A(n);
        return T17B(n-1, sum);
    }

    public static int T18(int[] arr, int index)
    {
        if(index < 0)
            return 0;
        return arr[index] + T18(arr, index-1);
    }
    public static int T19(int[] arr, int index)
    {
        if(index > arr.Length)
            return 0;
        return arr[index] + T19(arr, ++index);
    }
    public static int T20(int[] arr, int index)
    {
        return T20(arr,index,0);
    }
    public static int T20(int[] arr, int index,int counter)
    {
        if(index < 0)
            return counter;
        if(arr[index] > 0)
            counter++;
        return T20(arr, index-1,counter);
    }
    public static bool T21(int[] arr)
    {
        return T21(arr,0);
    }
    public static bool T21(int[] arr, int index)
    {
        if(index > arr.Length)
            return true;
        if(arr[index] >= arr[index+1])
            return false;
        return T21(arr,index+1);
    }
    public static int T22(int[] arr, int num)
    {
        return T22(arr,num,0);
    }
    public static int T22(int[] arr, int num,int counter)
    {
        if(counter > arr.Length-1)
            return -1;
        if(arr[counter] == num)
            return counter;
        return T22(arr, num,counter+1);
    }
    public static bool T23(char[] arr)
    {
        Random rnd = new Random();
        int num1 = rnd.Next(0,arr.Length);
        int num2 = rnd.Next(0,arr.Length);
        return T23(arr, num1, num2);
    }
    public static bool T23(char[] arr, int index1, int index2)
    {
        if(arr[index1] != arr[index2])
        {
            return false;
        }
        if(arr[index1] == arr[index2] && index1 != index2)
        {
            return true;
        }
        if(index1 < index2)
            return T23(arr, index1 + 1, index2- 1);
        return T23(arr, index1 - 1, index2 + 1);
    }
    public static bool T24(char[] arr)
    {
        return  T24(arr, 0,arr.Length-1);
    }
    public static bool T24(char[] arr, int firstIndex, int lastIndex)
    {
        if(arr[firstIndex] != arr[lastIndex])
            return false;
        if(arr[firstIndex] == arr[lastIndex])
            return true;
        return T24(arr, firstIndex+1, lastIndex-1);
    }
    public static bool T25(int[] arr)
    {
        return T25(arr,0);
    }
    public static bool T25(int[] arr, int index)
    {
        if(index == arr.Length)
            return false;
        if(T11(arr[index]) == true)
            return true;    
        return T25(arr, index+1);
    }
    public static bool T26(int[] arr1, int[] arr2)
    {
        return T26(arr1,arr2,0);
    }
    public static bool T26(int[] arr1, int[] arr2, int index)
    {
        if(index > arr1.Length-1)
            return true;
        if(arr1.Length!=arr2.Length)
            return false;
        if(arr1[index] != arr2[index])
            return false;

        return T26(arr1,arr2,index+1);

    }
    public static int T27(int[,] arr, int num)
    {
        return T27(arr,num,0,0,0);
    }
    public static int T27(int[,] arr, int num,int indexX, int indexY, int counter)
    {
        if(indexX > arr.GetLength(0)-1 || indexY > arr.GetLength(1)-1)
            return counter;
        if(arr[indexX,indexY] == num)
            counter++;
        return T27(arr,num,indexX+1,indexY+1,counter);
                
    }
    public static bool T28(int[,] mat, int num)
    {
        return T28(mat,num,0,0);
    }
    public static bool T28(int[,] mat, int num, int indexX, int indexY)
    {
        if(indexX > mat.GetLength(0) - 1 || indexY > mat.GetLength(1) - 1)
            return true;
        if(mat[indexX, indexY] < num)
            return false;
        return T28(mat, num, indexX + 1, indexY); 
    }
    public static bool T29(int[,] arr)
    {
        return T29(arr,0,arr.GetLength(0) - 1,0);
    }
    public static bool T29(int[,] arr, int index, int indexX, int indexY)
    {
        if(arr.GetLength(0) != arr.GetLength(1))
            return false;
        if(indexX > arr.GetLength(0)-1 || indexY > arr.GetLength(1)-1|| index > arr.GetLength(1)-1 )
            return true;
        if(arr[index, index] != 1 || arr[indexX, indexY] != 1)
            return false;

    }



    public static void Main()
{
    int[] arr1 = {11,9,6,5};
    int[] arr2 = {11,9,6,4};
    char[] array = {'d','a','b','a','d'};
    int[,] arr2D = {
        {1, 2, 3},
        {4, 5, 6},
        {7, 8, 9}
    };

    // Console.WriteLine(T26(arr1, arr2));
    Console.WriteLine(T28(arr2D, 0));
}
}