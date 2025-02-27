using System;
using System.ComponentModel.Design;

class Program
{
    //Print all the values in the Binary Tree using the Pre Order Method
    //The tree
    //     1
    //    / \
    //   2   3
    //  / \ / \
    // 4  5 6  7

    public static void ShowPreOrder(BinNode<int> tree)//1 2 4 5 3 6 7
    {
        // Base case: if the node is null, return
        if (tree == null)
            return;

        // Visit the root node and print its value
        Console.Write($"{tree.GetValue()} ");

        // Recursively visit the left subtree
        ShowPreOrder(tree.GetLeft());

        // Recursively visit the right subtree
        ShowPreOrder(tree.GetRight());
    }

    // In-order traversal: left, root, right
    public static void ShowInOrder(BinNode<int> tree)//4 2 5 1 6 3 7
    {
        // Base case: if the node is null, return
        if (tree == null)
            return;

        // Recursively visit the left subtree
        ShowInOrder(tree.GetLeft());

        // Visit the root node and print its value
        Console.Write($"{tree.GetValue()} ");

        // Recursively visit the right subtree
        ShowInOrder(tree.GetRight());
    }

    // Post-order traversal: left, right, root
    public static void ShowPostOrder(BinNode<int> tree)//4 5 2 6 7 3 1
    {
        // Base case: if the node is null, return
        if (tree == null)
            return;

        // Recursively visit the left subtree
        ShowPostOrder(tree.GetLeft());

        // Recursively visit the right subtree
        ShowPostOrder(tree.GetRight());

        // Visit the root node and print its value
        Console.Write($"{tree.GetValue()} ");
    }

    //רוחבית
    public static void ShowTransverseOrder(BinNode<int> tree)
    {
        BinNode<int> temp;
        Queue<BinNode<int>> queue = new Queue<BinNode<int>>();
        queue.Insert(tree);
        while(!queue.IsEmpty())
        {
            temp = queue.Remove();
            Console.Write($"{temp.GetValue()}"); //Add anything you want here instead of printing to the console
            if(temp.HasLeft())
            {
                queue.Insert(temp.GetLeft());
            }
            if(temp.HasRight())
            {
                queue.Insert(temp.GetRight());
            }
            Console.WriteLine();
        }   
        
    }
    
    //Gets the height of the tree
    public static int GetHeight(BinNode<int> tree)
    {
        if(tree == null)
            return 0;
        return 1 + Math.Max(GetHeight(tree.GetLeft()),GetHeight(tree.GetRight()));
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
        return false; // Added return statement
    }
    //Returns how many circles (Junctions)

    public static int CountNodes(BinNode<int> tree)
    {
        if(tree == null)
            return 0;
        return 1 + CountNodes(tree.GetLeft()) + CountNodes(tree.GetRight());
    }

    // The GetMaxPath function calculates the highest sum of values along any path from the root of a binary tree to its leaf nodes. It works by:

    //     1. Checking if the current node is empty: If it is, the function returns 0.
    //     2. Calculating sums: It finds the maximum path sum for both the left and right subtrees by calling itself recursively.
    //     3. Returning the maximum sum: It adds the value of the current node to the greater of the two sums from its children.
    public static int GetMaxPath(BinNode<int> tree)
    {
        if(tree == null)
            return 0;
        int sumLeft = GetMaxPath(tree.GetLeft());
        int sumRight = GetMaxPath(tree.GetRight());
        return tree.GetValue() + Math.Max(sumLeft, sumRight);
    }
    //Has exactly 2 grandchildred
    // Count the number of nodes with exactly two grandchildren in the binary tree
    public static int CountGradKids(BinNode<int> tree)
    {
        if (tree == null)
            return 0;

        int count = 0;

        // Check if the current node has exactly two grandchildren
        int grandsonsCount = CountGrandSons(tree);
        if (grandsonsCount == 2)
            count++;

        // Recursively count for left and right children
        count += CountGradKids(tree.GetLeft());
        count += CountGradKids(tree.GetRight());

        return count;
    }

    // Helper method to count the grandchildren of a specific node
    public static int CountGrandSons(BinNode<int> tree)
    {
        int count = 0;

        // Check the left child
        if (tree.HasLeft())
        {
            // Count grandchildren from the left child
            if (tree.GetLeft().HasLeft())
                count++; // Count left child's left child
            if (tree.GetLeft().HasRight())
                count++; // Count left child's right child
        }

        // Check the right child
        if (tree.HasRight())
        {
            // Count grandchildren from the right child
            if (tree.GetRight().HasLeft())
                count++; // Count right child's left child
            if (tree.GetRight().HasRight())
                count++; // Count right child's right child
        }

        return count;
    }


    //Gets int binary tree and prints the nodes that are even numbers and the kids are not odd numbers
    public static void Question(BinNode<int> tree)
    {
        if(tree == null)
            return ;
        if(Check(tree))
            Console.Write($"{tree.GetValue()}");
        Question(tree.GetRight());
        Question(tree.GetLeft());
    }
    public static bool Check(BinNode<int> tree)
    {
        // Check if the current node's value is even
        if (tree.GetValue() % 2 == 0)
        {
            // Check if the node has both left and right children
            if (tree.HasLeft() && tree.HasRight())
            {
                // Check if both children have even values
                if (tree.GetLeft().GetValue() % 2 == 1 && tree.GetRight().GetValue() % 2 == 1)
                {
                    // All conditions are met; return true
                    return true;
                }
            }
        }
        // If any condition fails, return false
        return false;
    }

    public static void Main()
    {
        // Create a simple binary tree
        BinNode<int> root = new BinNode<int>(1);
        root.SetLeft(new BinNode<int>(2));
        root.SetRight(new BinNode<int>(3));
        root.GetLeft().SetLeft(new BinNode<int>(4));
        root.GetLeft().SetRight(new BinNode<int>(5));
        root.GetRight().SetLeft(new BinNode<int>(6));
        root.GetRight().SetRight(new BinNode<int>(7));

        // This should output the count of nodes with exactly 2 grandchildren
        
    }


}
