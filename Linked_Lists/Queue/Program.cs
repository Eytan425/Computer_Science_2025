using System;
using System.Runtime.CompilerServices;

class Program
{
    public static int getNum()
    {
        Console.WriteLine("Enter a number, -999 exit: ");
        return int.Parse(Console.ReadLine());
    }
    public static Queue<int> createQueue()
    {
        Queue<int> outQueue = new Queue<int>();
        int num = getNum();
        while(num!=-999)
        {
            outQueue.Insert(num);
            num = getNum();
        }
        return outQueue;
    }
    public static Queue<int> CloneQueue(Queue<int> queue)
    {
        int num;
        Queue<int> copyQueue = new Queue<int>();
        Queue<int> tempQueue = new Queue<int>();
        while(!queue.IsEmpty())
            tempQueue.Insert(queue.Remove());
        while(!tempQueue.IsEmpty())
        {
            num = tempQueue.Remove();
            queue.Insert(num);
            copyQueue.Insert(num);
        }
        return copyQueue;
    }
    public static void ShowQueue(Queue<int> queue)
    {
        int num = 0;
        if(queue.IsEmpty())
        {
            Console.WriteLine("The queue is empty!");
            return;
        }
        Queue<int> copyQueue = CloneQueue(queue);
        while(!copyQueue.IsEmpty())
        {
            num = copyQueue.Remove();
            Console.WriteLine($"{num} ");
        }
    }
    public static int GetMax(Queue<int> queue)
    {
        Queue<int> copyQueue = CloneQueue(queue);
        int max = copyQueue.Remove();
        while(!copyQueue.IsEmpty())
        {
            max = Math.Max(max, copyQueue.Remove());
        }
        return max;
    }
    public static int GetMaxRecursive(Queue<int> queue)
    {
        Queue<int> copyQueue = CloneQueue(queue);
        return GetMaxRecursive(copyQueue,copyQueue.Remove() );
    }
    public static int GetMaxRecursive(Queue<int> queue, int max)
    {
        if(queue.IsEmpty())
            return max;
        return GetMaxRecursive(queue, Math.Max(max, queue.Remove()));
    }
    //Dummy way to go over the queue without duplicating it
    //Another way to display the queue
    public static void ShowQueueDummy(Queue<int> queue)
    {
        int dummy = -1;
        int x;
        queue.Insert(dummy);
        x = queue.Remove();
        while(x!=dummy)
        {
            Console.Write($"{x} ");
            queue.Insert(x);
            x = queue.Remove();
        }
    }
    //Checks if a number is in the queue
    public static bool IsNumberInQueue(Queue<int> queue, int num)
    {
        int dummy = -1;
        int x;
        bool found = false;
        queue.Insert(dummy);
        x = queue.Remove();
        while(x!=dummy)
        {
            if(x == num)
                found=true;
            queue.Insert(x);
            x = queue.Remove();
        }
        return found;
    }

    public static void Main()
    {
        Queue<int> queue = createQueue();
        ShowQueueDummy(queue);
        Console.WriteLine(" ");
        Console.WriteLine($"The greatest number is the queue is  {GetMax(queue)}");
    }
}