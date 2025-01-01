using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System;
using System;
using System.Collections.Generic;


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

    public static Queue<T> CloneQueueGeneric<T>(Queue<T> queue)
    {
        T num;
        Queue<T> copyQueue = new Queue<T>();
        Queue<T> tempQueue = new Queue<T>();
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
    //Shilo malichi test
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
    public static int GetSize<T>(Queue<T> que)
    {
        int size = 0;
        Queue<T> temp = CloneQueueGeneric(que);
        while (!temp.IsEmpty())
        {
            temp.Remove();
            size++;
        }
        
        return size;
    }

    //Start of the revision for the test
    public static bool T1<T>(Queue<T> que, T num)
    {
        Queue<T> temp = CloneQueueGeneric(que);
        if(temp.IsEmpty() || GetSize(temp) == 1)
            return false;
        bool isFound = false;
        while(!temp.IsEmpty())
        {
            if(temp.Remove().Equals(num))
                isFound = true;
        }
        return isFound;
    }
    public static bool T2<T>(Queue<T> q1, Queue<T> q2)
    {
        Queue<T> temp1 = CloneQueueGeneric(q1);
        Queue<T> temp2 = CloneQueueGeneric(q2);
        if(GetSize(temp1) != GetSize(temp2))
            return false;
        while(!temp1.IsEmpty())
        {
            if(!temp1.Remove().Equals(temp2.Remove()))
                return false;
        }
        return true;
    }
    
    public static Queue<int> T3(Queue<int> que)
    {
        Queue<int> temp = CloneQueueGeneric(que);
        Queue<int> newQue = new Queue<int>();

        while (!temp.IsEmpty())
        {
            int num = temp.Remove();
            bool isDuplicate = false;

            Queue<int> checkQueue = CloneQueueGeneric(newQue);
            while (!checkQueue.IsEmpty())
            {
                if (checkQueue.Remove() == num)
                {
                    isDuplicate = true;
                    break;
                }
            }
            
            if (!isDuplicate)
            {
                newQue.Insert(num);
            }
        }

        return newQue;
    }
    public static Time T4P1(Queue<Time> time)
    {
        Queue<Time> temp = CloneQueueGeneric(time);
        Time first = temp.Head();
        Time last = new Time(0, 0, 0);
        int size = GetSize(temp); 
        int counter = 0;

        while (!temp.IsEmpty())
        {
            counter++;
            Time current = temp.Remove();
            if (counter == size)
            {
                last = current;
            }
            else
            {
                temp.Insert(current);
            }
        }

        return first.DifferenceHour(last);
    }
    public static string T4P2(Queue<Time> time)
    {
        Queue<Time> temp = CloneQueueGeneric(time);
        int place = 0, savedPlace = 0;
        double minDiff = double.MaxValue;
        while (GetSize(temp) > 1)
        {
            place++;
            Time current = temp.Remove();
            Time next = temp.Head();
            double diff = current.DifferenceHour(next).convertToSeconds();
            if(diff < minDiff)
            {
                minDiff = diff;
                savedPlace = place;
            }
        }

        return $"{savedPlace}, {savedPlace+1}";
    }
    public static int CheckHowMany<T>(Queue<T> que, T num)
    {
        Queue<T> temp = CloneQueueGeneric(que);
        int counter = 0;
        while(!temp.IsEmpty())
        {
            if(temp.Remove().Equals(num))
                counter++;
        }
        return counter;
    }
    public static bool T5(Queue<int> queue, int n)
    {
        int num = 1;
        Queue<int> temp = CloneQueueGeneric(queue);
        int counter = 0;
        while(!temp.IsEmpty())
        {
            Queue<int> temp2 = CloneQueueGeneric(temp);
            if(CheckHowMany(temp2, temp.Head()) == num)
                counter++;
            num++;
            temp.Remove();

        }
        if(counter == n)
            return true;
        return false;
    }
    public static void T6(Queue<Job> jobs, int sumTime)
    {
        Queue<Job> temp = new Queue<Job>();
        while(jobs.IsEmpty() == false)
        {
            int time = jobs.Head().getTimeForWork();
            if(time < sumTime)
            {
               Job job = jobs.Remove();
               Console.WriteLine(job.getCode());
                
            }
            else
            {
                temp.Insert(jobs.Remove());
            }
        }
        jobs = temp;
    }
    public static void T7(Queue<int> q1, Queue<int> q2)//This is what they want but I did it with numbers
    {
        Queue<int> finalQueue = new Queue<int>();
        while(!q1.IsEmpty())
        {
            finalQueue.Insert(q1.Remove());
            finalQueue.Insert(q2.Remove());
        }
        while(q2.IsEmpty() == false)
        {
            finalQueue.Insert(q2.Remove());
        }

    }

    public static Queue<int> T8(Queue<int> q1, Queue<int> q2)
    {
        Queue<int> result = new Queue<int>();

        while (!q1.IsEmpty() && !q2.IsEmpty())
        {
            if (q1.Head() <= q2.Head())
            {
                result.Insert(q1.Remove());
            }
            else
            {
                result.Insert(q2.Remove());
            }
        }

    
        while (!q1.IsEmpty())
        {
            result.Insert(q1.Remove());
        }


        while (!q2.IsEmpty())
        {
            result.Insert(q2.Remove());
        }

        while (!result.IsEmpty())
        {
            q1.Insert(result.Remove());
        }
        return q1;
    }
    

    public static void Main()
    {
        
    }
}