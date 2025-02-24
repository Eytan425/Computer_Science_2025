using System;
using System.Reflection;

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
        
        OrderedList orderedList = new OrderedList();

        // Insert numbers into the ordered list
        orderedList.InsertNum(5);
        orderedList.InsertNum(3);
        orderedList.InsertNum(8);
        orderedList.InsertNum(1);
        orderedList.InsertNum(5); // Duplicate to test count increment

        // Print the list to verify the order and counts
        Node<NumCount> current = orderedList.GetNode();
        while (current != null)
        {
            Console.WriteLine($"Number: {current.GetValue().GetNum()}, Count: {current.GetValue().GetCount()}");
            current = current.GetNext();
        }
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
    private Node<NumCount> lst;
    public OrderedList()
    {
        lst = null;
    }
    public Node<NumCount> GetNode()
    {
        return lst;
    }
    public void SetNode(Node<NumCount> nodes)
    {
        lst = nodes;
    }
    public void InsertNum(int x)
    {
        Node<NumCount> pos = lst;
        //If the list is null, x becomes the list
        if(lst == null)
        {
            NumCount newNum = new NumCount(x,1);
            Node<NumCount> newNode = new Node<NumCount>(newNum);
            lst = newNode;
            return ;
        }
        //x is smaller than the first value
        if(x < pos.GetValue().GetNum())
        {
            NumCount newNum = new NumCount(x,1);
            Node<NumCount> newNode = new Node<NumCount>(newNum);
            newNode.SetNext(pos);
            return ;
        }
        //x is somewhere in there
        while(pos.GetNext()!=null)
        {
            if(pos.GetValue().GetNum() == x)
            {
                pos.GetValue().SetCount(pos.GetValue().GetCount() + 1);
                
            }
            if(pos.GetValue().GetNum() < x && pos.GetNext().GetValue().GetNum() > x)
            {
                NumCount newNum = new NumCount(x,1);
                Node<NumCount> newNode = new Node<NumCount>(newNum);
                pos.SetNext(newNode);
                newNode.SetNext(pos.GetNext());
                
            }
            pos = pos.GetNext();
            
        }
        
        return;

    }
}

