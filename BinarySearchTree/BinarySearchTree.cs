using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public class BinarySearchTree
    {
        static List<int> lstValues = new List<int>();

        public class Node
        {
            public int data;
            public Node left;
            public Node right;
            
            public Node(int data, Node left, Node right)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }
        }

        //it search an invalid value for current root.
        //A node with smaller value on left side or greater value on right side will classify the tree like non binary
        bool ThereIsInvalidValue(Node n, int rootValue, bool bLeft) {

            bool result = false;

            if (n.left != null) {
                if (((n.left.data > rootValue) && (bLeft)) ||
                    ((n.left.data < rootValue) && (!bLeft))) {
                    result = true;
                }
                else {
                    result = ThereIsInvalidValue(n.left, rootValue, bLeft);
                }
            }

            if ((n.right != null) && (result == false)) {
                if (((n.right.data > rootValue) && (bLeft)) ||
                    ((n.left.data < rootValue) && (!bLeft))) {
                    result = true;
                }
                else {
                    result = ThereIsInvalidValue(n.right, rootValue, bLeft);
                }
            }

            return result;
        }

        //duplicate values is not allowed, so we must verify that
        bool CheckOutTreeValues(Node n)
        {
            if (lstValues.IndexOf(n.data) >= 0) {
                return false;
            }
            else {
                if (n.data != 0) {
                    lstValues.Add(n.data);
                }

                return true;
            }
        }

        public bool checkBST(Node root)
        {
            if (!CheckOutTreeValues(root)) {
                return false;
            }
            else {
                if (root.left != null) {

                    if (ThereIsInvalidValue(root.left, root.data, true)) {
                        return false;
                    }

                    if (root.left.data != 0) {
                        if (!checkBST(root.left)) {
                            return false;
                        }
                    }
                }

                if (root.right != null) {

                    if (ThereIsInvalidValue(root.right, root.data, false)) {
                        return false;
                    }

                    if (root.right.data != 0) {
                        if (!checkBST(root.right))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }
    }
}
