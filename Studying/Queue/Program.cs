using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
    public static bool IsNumberInQueueDummy(Queue<int> queue, int num)
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
    public static bool IsNumberInQueue(Queue<int> queue, int num)
    {
        Queue<int> newQueue = CloneQueue(queue);
        bool found = false;
        while(newQueue.IsEmpty() == false)
        {
            if(newQueue.Remove() == num)
                found = true;
        }
        return found;
    }
    //A method that gets a list of queues (integer) and prints the max value of every queue in the list
    public static void PrintMax(Node<Queue<int>> first)
    {
        Queue<int> queue;
        Node<Queue<int>> pos = first;
        while(pos!=null)
        {
            queue = pos.GetValue();
            Console.WriteLine("{0} ", GetMax(queue));
            pos.GetNext();
        }
    }
    public static Queue<int> What(Queue<int>que, int n)
    {
        int x;
        if(n> 0)
        {
            x = que.Remove();
            if(x%2 == 1) que.Insert(x);
            What(que, n-1);
            if(x%2 == 0) que.Insert(x);
        }
        return  que;
    }
    public static Queue<int> MergeSortedQueues(Queue<int> que1, Queue<int> que2)
    {
        Queue<int> que3 = new Queue<int>();

        while (!que1.IsEmpty() && !que2.IsEmpty())
        {
            if (que1.Head() < que2.Head())
            {
                que3.Insert(que1.Remove());
            }
            else if (que1.Head() > que2.Head())
            {
                que3.Insert(que2.Remove());
            }
            else
            {
                
                que3.Insert(que1.Remove());
                que2.Remove();
            }
        }

        while (!que1.IsEmpty())
        {
            que3.Insert(que1.Remove());
        }

        while (!que2.IsEmpty())
        {
            que3.Insert(que2.Remove());
        }

        return que3;
    }




    public static void Main()
    {
        Queue<int> queue1 = createQueue();
        ShowQueueDummy(queue1);
        Queue<int> queue2 = createQueue();
        
        
        ShowQueueDummy(queue2);
        Console.WriteLine(" ");
        ShowQueueDummy(MergeSortedQueues(queue1,queue2));
        
    }
}