using System;
using System.Globalization;
using System.Runtime.CompilerServices;

class Program
{
    public static int ToNumber(Queue<int> q)
    {
        int num = 0, multy = 1;
        while(!q.IsEmpty())
        {
            num = num +  (q.Remove()*multy);
            multy *=10; 
        }
        return num;
    }
    public static int BigNumber(Node<Queue<int>> lst)
    {
        int max = int.MinValue;
        int number = 0;
        Node<Queue<int>> pos = lst;
        while(pos!=null)
        {
            number = ToNumber(pos.GetValue());
            if(number >= max)
                number = max;
            pos = pos.GetNext();
        }
        return number;
    }
    public static bool Order(BinNode<Range> tree)
    {
        if(tree == null)
            return true;
        if(tree.GetLeft()!=null)
        {
            if(tree.GetValue().GetLow() != tree.GetLeft().GetValue().GetLow() || tree.GetValue().GetHigh() < tree.GetLeft().GetValue().GetHigh())
                return false;
            
        }
        if(tree.GetRight() != null)
        {
            if(tree.GetValue().GetLow() > tree.GetRight().GetValue().GetLow() || tree.GetValue().GetHigh() != tree.GetRight().GetValue().GetHigh())
                return false;
        }
        if(tree.GetRight() != null && tree.GetLeft()!=null)
        {
            if(tree.GetLeft().GetValue().GetHigh() >= tree.GetRight().GetValue().GetLow())
                return false;
        }
        
        return Order(tree.GetLeft()) && Order(tree.GetRight());
         
    }
    
    public static void Main()
    {
        // Create a sample tree
        BinNode<Range> leftChild = new BinNode<Range>(new Range(3, 3));
        BinNode<Range> rightChild = new BinNode<Range>(new Range(2, 4));
        BinNode<Range> root = new BinNode<Range>( leftChild, new Range(1, 4), rightChild);

        // Test the Order method
        bool result = Order(root);
        Console.WriteLine("Is the tree ordered? " + result);
    }
}