using System;

class Program
{
    //Print all the values in the Binary Tree using the Pre Order Method
    public static void ShowPreOrder(BinNode<int> tree)
    {
        if(tree == null)
            return ;
        Console.Write($"{tree.GetValue()} ");
        ShowPreOrder(tree.GetLeft());
        ShowPreOrder(tree.GetRight());
    }
    //Print all the values in the Binary Tree using the In Order Method
    public static void ShowInOrder(BinNode<int> tree)
    {
        if(tree == null)
            return ;
        ShowInOrder(tree.GetLeft());
        Console.Write($"{tree.GetValue()}" );
        ShowInOrder(tree.GetRight());  
    }
    //Print all the values in the Binary Tree using the Post Order Method
    public static void ShowPostOrder(BinNode<int> tree)
    {
        if(tree == null)
            return ;
        ShowPostOrder(tree.GetLeft());
        ShowPostOrder(tree.GetRight());
        Console.Write($"{tree.GetValue()} ");
    }
    //Create a Binary Tree when knowing how many leafs in the Tree
    public static BinNode<int> CreateTree()
    {
        BinNode<int> t4 = new BinNode<int>(4);
        BinNode<int> t5 = new BinNode<int>(5);
        BinNode<int> t2 = new BinNode<int>(t4,2,t5);

        BinNode<int> t6 = new BinNode<int>(6);
        BinNode<int> t7 = new BinNode<int>(7);
        BinNode<int> t3 = new BinNode<int>(t6,3,t7);

        BinNode<int> t1 = new BinNode<int>(t2,1,t3);

        return t1;
    }
    //Method that gets a tree and returns a boolean if the number is in the tree
    public static bool IsNumInTree(BinNode<int> tree, int num)
    {
        if(tree == null)
            return false;
        if(tree.GetValue() == num || IsNumInTree(tree.GetLeft(), num)|| IsNumInTree(tree.GetRight(), num))
            return true;
        
    }
    //Returns how many circles (Junctions)

    public static int CountNodes(BinNode<int> tree)
    {
        if(tree == null)
            return false;
        return 1 + CountNodes(tree.GetLeft()) + CountNodes(tree.GetRight());
    }
    
    public static void Main()
    {
        System.Console.WriteLine("Hello, World!");
    }
}