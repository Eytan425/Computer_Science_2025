using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;

class Program
{

    public static int GetNum()
    {
        Console.WriteLine("Enter a number, -999 exit: ");
        return int.Parse(Console.ReadLine());
    }
    public static Queue<int> createQueue()
    {
        Queue<int> outQueue = new Queue<int>();
        int num = GetNum();
        while(num!=-999)
        {
            outQueue.Insert(num);
            num = GetNum();
        }
        return outQueue;
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
        Queue<int> copyQueue = CloneQueueGeneric(queue);
        while(!copyQueue.IsEmpty())
        {
            num = copyQueue.Remove();
            Console.WriteLine($"{num} ");
        }
    }
    //First Question
    public static int Size<T>(Queue<T> queue)
    {
        int count = 0;
        Queue<T> temp = CloneQueueGeneric(queue);
        while(!temp.IsEmpty())
        {
            temp.Remove();
            count++;
        }
        return count;
    }
    

    public static bool TwoSum(Queue<int> q, int x)
    {

        while(!q.IsEmpty())
        {
            int header = q.Remove();
            Queue<int> tempQueue = CloneQueueGeneric(q);
            while(!tempQueue.IsEmpty())
            {
                int num = tempQueue.Remove();
                if(header+num ==x)
                {
                    return true;
                }
            }
        }

        return false;
    }
    //Second question is the the NumCount file

    public static int DivideBy3(BinNode<int> tree)
    {
        return DivideBy3(tree, 0);
    }
    public static int DivideBy3(BinNode<int> tree, int count)
    {
        if (tree == null)
            return count;
        if (tree.GetValue() % 3 == 0)
            count++;
        count = DivideBy3(tree.GetLeft(), count);
        count = DivideBy3(tree.GetRight(), count);
        return count;
    }

    public static int DivideBy31(BinNode<int> tree)
    {
        return DivideBy31(tree, 0);
    }
    public static int DivideBy31(BinNode<int> tree, int count)
    {
        if (tree == null)
            return count;
        if (tree.GetValue() % 3 == 1)
            count++;
        count = DivideBy31(tree.GetLeft(), count);
        count = DivideBy31(tree.GetRight(), count);
        return count;
    }

    public static int DivideBy32(BinNode<int> tree)
    {
        return DivideBy32(tree, 0);
    }
    public static int DivideBy32(BinNode<int> tree, int count)
    {
        if (tree == null)
            return count;
        if (tree.GetValue() % 3 == 2)
            count++;
        count = DivideBy32(tree.GetLeft(), count);
        count = DivideBy32(tree.GetRight(), count);
        return count;
    }
    public static bool TreeEqual(BinNode<int> tree)
    {
        int count0 = DivideBy3(tree);
        int count1 = DivideBy31(tree);
        int count2 = DivideBy32(tree);
        return count0 == count1 && count1 == count2 && count0 == count2;
    }
    public static void Main(string[] args)
    {
        // Create a binary tree where TreeEqual will return true
        BinNode<int> root = new BinNode<int>(9);
        root.SetLeft(new BinNode<int>(7));
        root.SetRight(new BinNode<int>(10));
        root.GetLeft().SetLeft(new BinNode<int>(9));
        root.GetLeft().SetRight(new BinNode<int>(5));
        
        root.GetRight().SetRight(new BinNode<int>(11));

        // Test the TreeEqual method
        bool result = TreeEqual(root);
        Console.WriteLine($"TreeEqual result: {result}");
    }
}