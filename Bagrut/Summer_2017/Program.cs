using System;

class Program
{
    public static bool Exists(BinNode<int> tree, int x)
    {
        if(tree == null)
            return false;
        if(tree.GetValue() == x)
            return true;
        return Exists(tree.GetLeft(), x) || Exists(tree.GetRight(), x);
    }

    public static Node<int> Check(BinNode<int> t1, BinNode<int> t2)
    {
        Node<int> first = new Node<int>(-1);
        first = Check(t1, t2, first);
        return first.GetNext();
    }

    public static Node<int> Check(BinNode<int> t1, BinNode<int> t2, Node<int> lst)
    {
        if(t1!=null)
        {
            
            if(!Exists(t2, t1.GetValue()))
            {
                Node<int> addNode = new Node<int>(t1.GetValue());
                lst.SetNext(addNode);
                lst = addNode; //Tupdates the pointer to the last node in the linked list, ensuring that subsequent nodes are correctly appended to the end of the list.
            }
            Check(t1.GetLeft(), t2, lst);
            Check(t1.GetRight(), t2, lst);
        }
        
        return lst;
    }

    static void Main(string[] args)
    {
        // Create a sample binary tree t1
        BinNode<int> t1 = new BinNode<int>(10);
        t1.SetLeft(new BinNode<int>(5));
        t1.SetRight(new BinNode<int>(15));
        t1.GetLeft().SetLeft(new BinNode<int>(3));
        t1.GetLeft().SetRight(new BinNode<int>(7));
        t1.GetRight().SetLeft(new BinNode<int>(12));
        t1.GetRight().SetRight(new BinNode<int>(18));

        // Create another sample binary tree t2
        BinNode<int> t2 = new BinNode<int>(10);
        t2.SetLeft(new BinNode<int>(5));
        t2.SetRight(new BinNode<int>(20));
        t2.GetLeft().SetLeft(new BinNode<int>(3));
        t2.GetLeft().SetRight(new BinNode<int>(7));
        t2.GetRight().SetLeft(new BinNode<int>(12));
        t2.GetRight().SetRight(new BinNode<int>(25));

        // Test the Exists method
        Console.WriteLine(Exists(t1, 7));  // Output: True
        Console.WriteLine(Exists(t1, 20)); // Output: False

        // Test the Check method
        Node<int> result = Check(t1, t2);
        while (result != null)
        {
            Console.WriteLine(result.GetValue());
            result = result.GetNext();
        }
    }
}