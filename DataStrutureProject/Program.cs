using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fibonacci().GetAwaiter().GetResult();
            //SingleTonPattern().GetAwaiter().GetResult();
            //ValidateStringBrackets().GetAwaiter().GetResult();
            //BinarySearch().GetAwaiter().GetResult();
            //InitializeBubleSort().GetAwaiter().GetResult();
            MergeSort().GetAwaiter().GetResult();

            Console.ReadLine();   
        }

        static async Task Fibonacci()
        {   
            var outer = new Task(() =>
            {
                int number = 0;
                int count = 0;
                var numbers = new List<int>();
                int index = 0;

                numbers.Add(number);

                for (count = 0; count < 15; count++)
                {
                    if (index > 0)
                    {
                        number = numbers[index] + numbers[index - 1];
                    }
                    else
                        number = 1;

                    index++;
                    
                    numbers.Add(number);
                }

                Console.WriteLine(string.Join(",", numbers.ToArray()));
            });

            outer.Start();
            await outer;
        }

        static async Task SingleTonPattern()
        {
            var outer = new Task(() =>
            {
                var singleTon = Singleton.GetInstance();
                var singleTon2 = Singleton.GetInstance();

                if (singleTon == singleTon2)
                    Console.WriteLine("Same instance");
            });

            outer.Start();
            await outer;
        }

        #region BubbleSort
        static async Task InitializeBubleSort()
        {
            var items = GetListOfNumbers();
            var task = BubbleSort(items);
            task.Start();
            await task;
        }

        static ArrayList GetListOfNumbers(int size = 10)
        {
            Random r = new Random();
            var arrayList = new ArrayList();

            for (int i = 0; i < size; i++)
            {
                int randomNumber = r.Next(0, 100);
                while (arrayList.Contains(randomNumber))
                    randomNumber = r.Next(0, 100);
                arrayList.Add(randomNumber);
            }

            Console.WriteLine("Initial state: " + PrintListOfNumbers(arrayList));

            return arrayList;
        }

        static Task BubbleSort(ArrayList input)
        {
            var task = new Task(() =>
            {
                var count = input.Count;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < (count - 1); j++)
                    {
                        if ((int)input[j] > (int)input[j + 1])
                        {
                            int temp = (int)input[j];
                            input[j] = input[j + 1];
                            input[j + 1] = temp;
                        }
                    }
                    Console.WriteLine("After iteration " + i.ToString() + ": " + PrintListOfNumbers(input));
                }
            });

            return task;
        }

        static string PrintListOfNumbers(ArrayList input)
        {
            string completeNumbers = string.Empty;
            foreach (var item in input)
                completeNumbers += item.ToString() + ", ";

            return completeNumbers.Remove(completeNumbers.LastIndexOf(","));
        }
        #endregion

        static async Task ValidateStringBrackets(string input)
        {
            //Input
            //string input = "(a[]{}([{}]d))";
            var acceptedSymbols = new Dictionary<char, char>();
            acceptedSymbols.Add('(', ')');
            acceptedSymbols.Add('[', ']');
            acceptedSymbols.Add('{', '}');

            var stack = new Stack<char>();

            var output = new Task(() =>
            {
                foreach (var character in input.ToCharArray())
                {
                    if (acceptedSymbols.ContainsKey(character))
                        stack.Push(character);
                    else
                    {
                        if (acceptedSymbols.ContainsValue(character))
                        {
                            var previuosSymbol = stack.Peek();
                            var item = acceptedSymbols.FirstOrDefault(a => a.Value.Equals(character));

                            if (previuosSymbol == item.Key)
                                stack.Pop();
                        }
                    }
                }

                if (stack.Count() > 0)
                    Console.WriteLine("String format is not correct");
                else
                    Console.WriteLine("String format is correct");

            });


            output.Start();
            await output;
        }

        #region BinaryTreeSearch

        static async Task BinarySearch()
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

        class TreeNode<T>
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

        class BinarySearchTree<T>
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
        #endregion

        #region MergeSortRecursive
        protected static async Task MergeSort()
        {
            ArrayList input = GetListOfNumbers(20);
            var task = MergeSortAlgorithm(input);
            task.Start();
            await task;
        }

        private static Task MergeSortAlgorithm(ArrayList input)
        {
            var task = new Task(() =>
            {
                Console.WriteLine("Starting...");
                MergeSort(input, 0, (input.Count - 1));
                Console.WriteLine("Completed: " + PrintListOfNumbers(input));
                
            });

            return task;
        }

        private static void MergeSort(ArrayList input, int l, int r)
        {
            int mid;

            if (r > l)
            {
                mid = (r + l) / 2;
                MergeSort(input, l, mid);
                MergeSort(input, (mid + 1), r);

                DoMerge(input, l, (mid + 1), r);
            }
        }

        private static void DoMerge(ArrayList input, int left, int mid, int right)
        {
            int[] temp = new int[input.Count];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if ((int)input[left] <= (int)input[mid])
                    temp[tmp_pos++] = (int)input[left++];
                else
                    temp[tmp_pos++] = (int)input[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = (int)input[left++];

            while (mid <= right)
                temp[tmp_pos++] = (int)input[mid++];

            for (i = 0; i < num_elements; i++)
            {
                input[right] = temp[right];
                right--;
            }
        }
        #endregion
    }
}
