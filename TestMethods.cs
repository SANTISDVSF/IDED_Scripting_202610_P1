namespace IDED_Scripting_202610_P1
{
    using System;
    using System.Collections.Generic;

    internal class TestMethods
    {
        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            List<int> inList = new List<int>();
            List<int> exList = new List<int>();

            Queue<int> temp = new Queue<int>();

            while (input.Count > 0)
            {
                int x = input.Dequeue();
                temp.Enqueue(x);

                if (BelongsToSeries(x))
                    inList.Add(x);
                else
                    exList.Add(x);
            }

            while (temp.Count > 0)
                input.Enqueue(temp.Dequeue());

            included = new Stack<int>(inList);
            excluded = new Stack<int>(exList);
        }

        private static bool BelongsToSeries(int x)
        {
            if (x == 0) return true;

            int ax = x < 0 ? -x : x;
            int r = (int)Math.Sqrt(ax);

            while (r * r < ax) r++;
            while (r * r > ax) r--;

            if (r * r != ax) return false;

            if (x > 0) return (r % 2 == 0); 
            return (r % 2 != 0);            
        }

        public static List<int> GenerateSortedSeries(int n)
        {
            List<int> terms = new List<int>();

            int i = 0;
            while (i < n)
            {
                int val = i * i;
                if (i % 2 != 0) val = -val; 
                terms.Add(val);
                i++;
            }

            InsertionSortAscending(terms);
            return terms;
        }

        private static void InsertionSortAscending(List<int> list)
        {
            int i = 1;
            while (i < list.Count)
            {
                int key = list[i];
                int j = i - 1;

                while (j >= 0 && list[j] > key)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = key;
                i++;
            }
        }

        public static bool FindNumberInSortedList(int target, in List<int> list)
        {
            SelectionSortDescending(list);

            int i = 0;
            while (i < list.Count)
            {
                if (list[i] == target) return true;
                i++;
            }

            return false;
        }

        private static void SelectionSortDescending(List<int> list)
        {
            int n = list.Count;
            int i = 0;

            while (i < n - 1)
            {
                int maxIndex = i;
                int j = i + 1;

                while (j < n)
                {
                    if (list[j] > list[maxIndex])
                        maxIndex = j;
                    j++;
                }

                if (maxIndex != i)
                {
                    int tmp = list[i];
                    list[i] = list[maxIndex];
                    list[maxIndex] = tmp;
                }

                i++;
            }
        }

        public static int FindPrime(in Stack<int> list)
        {
            Stack<int> temp = new Stack<int>();
            int found = 0;

            while (list.Count > 0)
            {
                int x = list.Pop();
                temp.Push(x);

                if (found == 0 && IsPrime(x))
                    found = x;
            }

            while (temp.Count > 0)
                list.Push(temp.Pop());

            return found;
        }

        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            int d = 3;
            while (d * d <= n)
            {
                if (n % d == 0) return false;
                d += 2;
            }
            return true;
        }

        public static Stack<int> RemoveFirstPrime(in Stack<int> stack)
        {
            Stack<int> tempAll = new Stack<int>();
            Stack<int> tempKept = new Stack<int>();

            bool removed = false;

            while (stack.Count > 0)
            {
                int x = stack.Pop();
                tempAll.Push(x);

                if (!removed && IsPrime(x))
                {
                    removed = true; 
                    continue;
                }

                tempKept.Push(x);
            }

            while (tempAll.Count > 0)
                stack.Push(tempAll.Pop());

            Stack<int> result = new Stack<int>();
            while (tempKept.Count > 0)
                result.Push(tempKept.Pop());

            return result;
        }

     
        public static Queue<int> QueueFromStack(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            Queue<int> q = new Queue<int>();

            while (stack.Count > 0)
                temp.Push(stack.Pop());

            while (temp.Count > 0)
            {
                int x = temp.Pop();
                q.Enqueue(x);
                stack.Push(x); 
            }

            return q;
        }
    }

}
