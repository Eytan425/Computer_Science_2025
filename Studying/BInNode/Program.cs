// using System;

// class Program
// {
//     public static int T20(BinNode<int> tree)
//     {
//         int sumNeg = 0;
//         int sumPos = 0;
//         T20(tree, ref sumNeg, ref sumPos);
//         return sumPos - sumNeg;
//     }

//     public static void T20(BinNode<int> tree, ref int sumNeg, ref int sumPos)
//     {
//         if (tree == null)
//         {
//             return;
//         }
//         if (tree.GetValue() < 0)
//             sumNeg += Math.Abs(tree.GetValue());
//         if (tree.GetValue() > 0)
//             sumPos += tree.GetValue();
//         T20(tree.GetLeft(), ref sumNeg, ref sumPos);
//         T20(tree.GetRight(), ref sumNeg, ref sumPos);
//     }
//     public static bool T25(BinNode<char> tree, char c1, char c2)
//     {
//         if (tree == null)
//             return false;
//         if (tree.GetValue() == c1)
//             if ((tree.GetLeft() != null && tree.GetLeft().GetValue() == c2) || 
//                 (tree.GetRight() != null && tree.GetRight().GetValue() == c2))
//                 return true;
//         if (tree.GetValue() == c2)
//             if ((tree.GetLeft() != null && tree.GetLeft().GetValue() == c1) || 
//                 (tree.GetRight() != null && tree.GetRight().GetValue() == c1))
//                 return true;
//         return T25(tree.GetLeft(), c1, c2) || T25(tree.GetRight(), c1, c2);
//     }
    

//     public static void NotMain()
//     {
//         // Create a sample binary tree
//         BinNode<char> root = new BinNode<char>('a');
//         root.SetLeft(new BinNode<char>('b'));
//         root.SetRight(new BinNode<char>('c'));
//         root.GetLeft().SetLeft(new BinNode<char>('d'));
//         root.GetLeft().SetRight(new BinNode<char>('e'));
//         root.GetRight().SetLeft(new BinNode<char>('f'));
//         root.GetRight().SetRight(new BinNode<char>('g'));

//         // Test the T25 function
//         bool result1 = T25(root, 'a', 'b'); // Expected output: true
//         bool result2 = T25(root, 'a', 'd'); // Expected output: false
//         bool result3 = T25(root, 'b', 'e'); // Expected output: true
//         bool result4 = T25(root, 'c', 'g'); // Expected output: true
//         bool result5 = T25(root, 'd', 'e'); // Expected output: false

//         Console.WriteLine("Result1: " + result1);
//         Console.WriteLine("Result2: " + result2);
//         Console.WriteLine("Result3: " + result3);
//         Console.WriteLine("Result4: " + result4);
//         Console.WriteLine("Result5: " + result5);
//     }
// }