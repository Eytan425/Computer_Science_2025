using System;

class Program
{
    public static int GetSize(Queue<int> q)
    {
        int size = 0;
        Queue<int> tempQueue = new Queue<int>();
        while (!q.IsEmpty())
        {
            tempQueue.Insert(q.Remove());
            size++;
        }
        while (!tempQueue.IsEmpty())
        {
            q.Insert(tempQueue.Remove());
        }
        return size;
    }
    public static  bool TwoSum(Queue<int> q, int x)
    {
        int size = GetSize(q);
        for(int i = 0; i < size; i++)
        {
            int first = q.Remove();
            for(int j = 0; j < size - 1; j++)
            {
                int second = q.Remove();
                if(first + second == x)
                {
                    return true;
                }
                q.Insert(second);
            }
            q.Insert(first);
        }
        return false;
    }

    public static void Main(string[] args)
    {
        Queue<int> q = new Queue<int>();
        q.Insert(1);
        q.Insert(2);
        q.Insert(3);
        q.Insert(4);
        q.Insert(5);

        int targetSum = 2;
        bool result = TwoSum(q, targetSum);
        Console.WriteLine($"Two elements sum to {targetSum}: {result}");
    }
}
class NumCount
{
    private int num;
    private int count;

    public NumCount(int num, int count)
    {
        this.num = num;
        this.count = count;
    }
    public int GetNum()
    {
        return this.num;
    }
    public int GetCount()
    {
        return this.count;
    }
    public void SetNum(int num)
    {
        this.num = num;
    }
    public void SetCount(int count)
    {
        this.count = count;
    }

}
class OrderedList
{
    private Node<NumCount> node;
    public OrderedList()
    {
        this.node = null;
    }
    public Node<NumCount> GetNode()
    {
        return this.node;
    }
    public void SetNode(Node<NumCount> node)
    {
        this.node = node;
    }
    public void InsertNum(int x)
    {
        int count = 0;
        Node<NumCount> nodes = this.node;
        while (nodes != null)
        {
            if (nodes.GetValue().GetNum() == x)
            {
                nodes.GetValue().SetCount(nodes.GetValue().GetCount() + 1);
                count++;
            }
            nodes = nodes.GetNext();
        }
        if (count == 0)
        {
            Node<NumCount> newNode = new Node<NumCount>(new NumCount(x, 1));
            if (this.node == null)
            {
                this.node = newNode;
            }
            else
            {
                Node<NumCount> temp = this.node;
                while (temp.GetNext() != null)
                {
                    temp = temp.GetNext();
                }
                temp.SetNext(newNode);
            }
        }
    }
}