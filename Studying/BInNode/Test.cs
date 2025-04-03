using System;
using System.Runtime.InteropServices;

class Program
{
    public static bool HasRightRight(BinNode<string> tree) //External Function
    {
        if (tree.HasRight())
        {
            if (tree.GetRight().GetRight() != null)
                return true;
        }
        return false;
    }

    public static bool HasRightLeft(BinNode<string> tree) //External Function
    {
        if (tree.HasRight())
        {
            if (tree.GetRight().GetLeft() != null)
                return true;
        }
        return false;
    }

    public static bool HasLeftLeft(BinNode<string> tree) //External Function
    {
        if (tree.HasLeft())
        {
            if (tree.GetLeft().GetLeft() != null)
                return true;
        }
        return false;
    }

    public static bool HasLeftRight(BinNode<string> tree) // External Function
    {
        if (tree.HasLeft())
        {
            if (tree.GetLeft().GetRight() != null)
                return true;
        }
        return false;
    }
    public static int Help(BinNode<string> tree, string name) //External Function
    {
       int count = 0;
       if (tree == null) { return 0; }
       if (tree.GetValue() == name)
       {
           if (HasLeftLeft(tree))
           {
               if (tree.GetLeft().GetLeft().GetValue() == name)
                   count++;
           }
           if (HasLeftRight(tree))
           {
               if (tree.GetLeft().GetRight().GetValue() == name)
                   count++;
           }
           if (HasRightLeft(tree))
           {
               if (tree.GetRight().GetLeft().GetValue() == name)
                   count++;
           }
           if (HasRightRight(tree))
           {
               if (tree.GetRight().GetRight().GetValue() == name)
                   count++;
           }
       }
       count += Help(tree.GetLeft(), name);
       count+= Help(tree.GetRight(), name);
       return count;
    }
    public static bool Question2(BinNode<string> tree, string name)
    {
        int counter = Help(tree,name);
        if(counter >= 2)
            return true;
        return false;
    }
    public static int ReturnCounter(BinNode<string> tree, string name)
    {
        int counter = Help(tree, name);
        return counter;
    }

    public static void Main()
    {
        // Create a sample binary tree
        BinNode<string> root = new BinNode<string>("a");
        root.SetLeft(new BinNode<string>("b"));
        root.SetRight(new BinNode<string>("c"));
        root.GetLeft().SetLeft(new BinNode<string>("a"));
        root.GetLeft().SetRight(new BinNode<string>("d"));
        root.GetRight().SetLeft(new BinNode<string>("a"));
        root.GetRight().SetRight(new BinNode<string>("e"));
        root.GetLeft().GetLeft().SetLeft(new BinNode<string>("a"));
        root.GetLeft().GetLeft().SetRight(new BinNode<string>("a"));
        root.GetRight().GetLeft().SetLeft(new BinNode<string>("a"));
        root.GetRight().GetLeft().SetRight(new BinNode<string>("a"));

        // Test the ReturnCounter function
        Console.WriteLine(ReturnCounter(root, "a")); // 2
        Console.WriteLine(ReturnCounter(root, "b")); //0
        Console.WriteLine(ReturnCounter(root, "c")); //0
        Console.WriteLine(ReturnCounter(root, "d")); //0
        Console.WriteLine(ReturnCounter(root, "e")); //0

        //Test the Question2 function
        Console.WriteLine(Question2(root, "a")); // Expected output: true (at least 2 grandsons with "a")
        Console.WriteLine(Question2(root, "b")); // Expected output: false (no grandsons with "b")
        Console.WriteLine(Question2(root, "c")); // Expected output: false (no grandsons with "c")
        Console.WriteLine(Question2(root, "d")); // Expected output: false (no grandsons with "d")
        Console.WriteLine(Question2(root, "e")); // Expected output: false (no grandsons with "e")
    }
    
}