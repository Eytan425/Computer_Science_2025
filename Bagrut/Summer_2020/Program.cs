using System;

class Program
{
    public static void PrintAll(BinNode<int> tree)
    {
        PrintAll(tree, 0);
    }
    public static void PrintAll(BinNode<int> tree, int num)
    {
        if (tree == null)
        {
            return ;
        }
        num = 10 * num + tree.GetValue();
        if (tree.GetLeft() == null && tree.GetRight() == null)
        {
            Console.WriteLine(num);
        }
        else
        {
            PrintAll(tree.GetLeft(), num);
            PrintAll(tree.GetRight(), num);
        }
        
    }
    public static void Main()
    {
        BinNode<int> t4 = new BinNode<int>(4);
        BinNode<int> t5 = new BinNode<int>(5);
        BinNode<int> t2 = new BinNode<int>(t4,2,t5);

        BinNode<int> t6 = new BinNode<int>(6);
        BinNode<int> t7 = new BinNode<int>(7);
        BinNode<int> t3 = new BinNode<int>(t6,3,t7);

        BinNode<int> t1 = new BinNode<int>(t2,1,t3);

        PrintAll(t1);
    }
}