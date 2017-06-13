using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class BinaryTreeSample
    {
        public bool BinaryTreeValidation()
        {
            BinarySearchTree BSearch = new BinarySearchTree();

            BinarySearchTree.Node root =
                new BinarySearchTree.Node(4,
                                          new BinarySearchTree.Node(2,
                                                    new BinarySearchTree.Node(1, null, null),
                                                    new BinarySearchTree.Node(3, null, null)),

                                          new BinarySearchTree.Node(6,
                                              new BinarySearchTree.Node(5, null, null),
                                              new BinarySearchTree.Node(7, null, null))
                                          );

            return BSearch.checkBST(root);
        }
    }
}
