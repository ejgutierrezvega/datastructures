using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStructureProject.BinarySearchTree
{
    public class BinarySearchAlgorithm
    {
        public static async Task BinarySearch()
        {
            var task = new Task(() =>
            {
                /*
                BinarySearchTree<int> intTree = new BinarySearchTree<int>();
                Random r = new Random(DateTime.Now.Millisecond);
                string trace = "";

                for (int i = 0; i < 5; i++)
                {
                    int randomInt = r.Next(1, 500);
                    intTree.Insert(randomInt);
                    trace += randomInt + " ";
                }
                */

                string trace = "";
                List<string> items = new List<string>();
                items.Add("monkey");
                items.Add("zebra");
                items.Add("cat");
                items.Add("dog");
                items.Add("elephant");
                items.Add("parrot");
                items.Add("lion");
                items.Add("horse");
                items.Add("leopard");

                BinarySearchTree<string> intTree = new BinarySearchTree<string>();
                foreach (var item in items)
                {
                    intTree.Insert(item);
                    trace += item + " ";
                }

                // Find the largest value in the tree
                Console.WriteLine("Max: " + intTree.FindMax());

                // Find the smallest value in the tree
                Console.WriteLine("Min: " + intTree.FindMin());

                // Find the root of the tree
                Console.WriteLine("Root: " + intTree.Root.Element);

                // The order in which the elements were added to the tree
                Console.WriteLine("Trace: " + trace);

                // Calculate the height of the tree
                Console.WriteLine("Height: " + intTree.Height().ToString());

                // Calculate the height of the tree
                Console.WriteLine("Breadth first:");
                intTree.BreadthFirst();

                // A textual representation of the tree
                Console.WriteLine("Tree: " + intTree);

                //string input = Console.ReadLine();
                //int itemToRemove;
                //if (int.TryParse(input, out itemToRemove))
                //{
                //var found = intTree.Find(numberToRemove);
                //var found = intTree.Find(input);
                //if (found > 0) //when T is int
                //if (!string.IsNullOrEmpty(found))
                //intTree.Remove(found);
                //}

                // A textual representation of the tree
                //Console.WriteLine("Tree: " + intTree);
            });

            task.Start();
            await task;
        }

        private class TreeNode<T>
        {
            public T Element { get; set; }
            public TreeNode<T> Left { get; set; }
            public TreeNode<T> Right { get; set; }

            public TreeNode(T element)
            {
                Element = element;
            }

            public override string ToString()
            {
                string nodeString = "[" + this.Element + " ";

                //Leaf node
                if (this.Left == null && this.Right == null)
                    nodeString += " (Leaf) ";

                if (this.Left != null)
                    nodeString += "Left: " + this.Left.ToString();

                if (this.Right != null)
                    nodeString += "Right: " + this.Right.ToString();

                nodeString += "] ";

                return nodeString;
            }
        }

        private class BinarySearchTree<T>
        {
            public TreeNode<T> Root { get; set; }

            public BinarySearchTree()
            {
                this.Root = null;
            }

            public void Insert(T x)
            {
                this.Root = Insert(x, this.Root);
            }

            public void Remove(T x)
            {
                this.Root = Remove(x, this.Root);
            }

            public void RemoveMin(T x)
            {
                this.Root = RemoveMin(this.Root);
            }

            public T FindMin()
            {
                return ElementAt(FindMin(this.Root));
            }

            public T FindMax()
            {
                return ElementAt(FindMax(this.Root));
            }

            public T Find(T x)
            {
                return ElementAt(Find(x, this.Root));
            }

            public void MakeEmpty()
            {
                this.Root = null;
            }

            public bool IsEmpty()
            {
                return this.Root == null;
            }

            public int Height()
            {
                return FindHeight(this.Root);

            }

            public void BreadthFirst()
            {
                BreadthFirst(this.Root);
            }

            private T ElementAt(TreeNode<T> t)
            {
                return t == null ? default(T) : t.Element;
            }

            private TreeNode<T> Find(T x, TreeNode<T> t)
            {
                while (t != null)
                {
                    if ((x as IComparable).CompareTo(t.Element) < 0)
                        t = t.Left;
                    else if ((x as IComparable).CompareTo(t.Element) > 0)
                        t = t.Right;
                    else
                        return t;
                }
                return null;
            }

            private TreeNode<T> FindMin(TreeNode<T> t)
            {
                if (t != null)
                {
                    while (t.Left != null)
                        t = t.Left;
                }

                return t;
            }

            private TreeNode<T> FindMax(TreeNode<T> t)
            {
                if (t != null)
                {
                    while (t.Right != null)
                        t = t.Right;
                }

                return t;
            }

            protected TreeNode<T> Insert(T x, TreeNode<T> t)
            {
                if (t == null)
                    t = new TreeNode<T>(x);
                else if ((x as IComparable).CompareTo(t.Element) < 0)
                    t.Left = Insert(x, t.Left);
                else if ((x as IComparable).CompareTo(t.Element) > 0)
                    t.Right = Insert(x, t.Right);
                else
                    throw new Exception("Duplicate item");
                return t;
            }

            protected TreeNode<T> RemoveMin(TreeNode<T> t)
            {
                if (t == null)
                    throw new Exception("Item not found");
                else if (t.Left != null)
                {
                    t.Left = RemoveMin(t.Left);
                    return t;
                }
                else
                    return t.Right;
            }

            protected TreeNode<T> Remove(T x, TreeNode<T> t)
            {
                if (t == null)
                    throw new Exception("Item not found");
                else if ((x as IComparable).CompareTo(t.Element) < 0)
                    t.Left = Remove(x, t.Left);
                else if ((x as IComparable).CompareTo(t.Element) > 0)
                    t.Right = Remove(x, t.Right);
                else if (t.Left != null && t.Right != null)
                {
                    t.Element = FindMin(t.Right).Element;
                    t.Right = RemoveMin(t.Right);
                }
                else
                    t = (t.Left != null) ? t.Left : t.Right;

                return t;
            }

            protected int FindHeight(TreeNode<T> t)
            {
                if (t == null)
                    return 0;

                int left = 1 + FindHeight(t.Left);
                int right = 1 + FindHeight(t.Right);

                return Math.Max(left, right);
            }

            protected void BreadthFirst(TreeNode<T> t)
            {
                Queue<TreeNode<T>> q = new Queue<TreeNode<T>>();
                q.Enqueue(t);
                while (q.Count > 0)
                {
                    t = q.Dequeue();

                    string left = string.Empty;
                    if (t.Left != null)
                    {
                        left = $" - {t.Left.Element}(l)";
                        q.Enqueue(t.Left);
                    }

                    string right = string.Empty;
                    if (t.Right != null)
                    {
                        right = $" - {t.Right.Element}(r)";
                        q.Enqueue(t.Right);
                    }

                    Console.WriteLine($"{t.Element}{left}{right}");
                }
            }

            public override string ToString()
            {
                return this.Root.ToString();
            }
        }
    }
}
