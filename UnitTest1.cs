namespace IDED_Scripting_202610_P1
{
    public class TestData
    {
        public static readonly Queue<int> queue1 = new Queue<int>(new[] { -361, 1600, 777, -49, 10404, 12345, -9409, 36, -225, 999, 7744, -1, 400 });
        public static readonly Queue<int> queue2 = new Queue<int>(new[] { 144, -5929, 25600, -81, 4356, -11025, 196, 42, -1681, 8464, -9, 3136, 7777, -36100 });
        public static readonly Queue<int> queue3 = new Queue<int>(new[] { -121, 484, -2401, 12996, -5041, 64, -1849, 1764, 1234, -29929, 1024, 5555, -9025, 256, -6561, 8888, 8464, -77 });
        public static readonly Queue<int> queue4 = new Queue<int>(new[] { 32400, -361, 7056, -225, 11664, -9801, 36, -5929, 4096, -24025, 256, -441, 1936, -1521, 7744, -49, 2023 });
        public static readonly Queue<int> queue5 = new Queue<int>(new[] { -1, 100, 7, -169, 400, 123, -625, 900, -1225, 55, 1600, -2025, 2500, 8080, -3025, 3600, -4225, 4900, -5625, 6400, -7225, 13, 8100 });

        public static readonly Queue<int>[] allQueues = { queue1, queue2, queue3, queue4, queue5 };
    }

    [TestFixture]
    public class TestSeparateElements
    {
        public static IEnumerable<TestCaseData> SeparateElementsData()
        {
            yield return new TestCaseData(
                TestData.queue1,
                new Stack<int>([-361, 1600, -49, 10404, -9409, 36, -225, 7744, -1, 400]),
                new Stack<int>([777, 12345, 999])
            ).SetName("TestSeparateElements_Queue1");

            yield return new TestCaseData(
                TestData.queue2,
                new Stack<int>([144, -5929, 25600, -81, 4356, -11025, 196, -1681, 8464, -9, 3136]),
                new Stack<int>([42, 7777, -36100])
            ).SetName("TestSeparateElements_Queue2");

            yield return new TestCaseData(
                TestData.queue3,
                new Stack<int>([-121, 484, -2401, 12996, -5041, 64, -1849, 1764, -29929, 1024, -9025, 256, -6561, 8464]),
                new Stack<int>([1234, 5555, 8888, -77])
            ).SetName("TestSeparateElements_Queue3");

            yield return new TestCaseData(
                TestData.queue4,
                new Stack<int>([32400, -361, 7056, -225, 11664, -9801, 36, -5929, 4096, -24025, 256, -441, 1936, -1521, 7744, -49]),
                new Stack<int>([2023])
            ).SetName("TestSeparateElements_Queue4");

            yield return new TestCaseData(
                TestData.queue5,
                new Stack<int>([-1, 100, -169, 400, -625, 900, -1225, 1600, -2025, 2500, -3025, 3600, -4225, 4900, -5625, 6400, -7225, 8100]),
                new Stack<int>([7, 123, 55, 8080, 13])
            ).SetName("TestSeparateElements_Queue5");
        }

        [TestCaseSource(nameof(SeparateElementsData))]
        public void SeparateElements(Queue<int> queue, Stack<int> expectedIncluded, Stack<int> expectedExcluded)
        {
            Stack<int> included = new Stack<int>();
            Stack<int> excluded = new Stack<int>();

            TestMethods.SeparateElements(queue, out included, out excluded);

            Assert.That(included, Is.EqualTo(expectedIncluded));
            Assert.That(excluded, Is.EqualTo(expectedExcluded));
        }
    }

    [TestFixture]
    public class TestGenerateSortedSeries
    {
        public static IEnumerable<TestCaseData> GenerateSortedSeriesData()
        {
            List<int> list10 = new List<int> { -81, -49, -25, -9, -1, 0, 4, 16, 36, 64, 100 };
            List<int> list12 = new List<int> { -121, -81, -49, -25, -9, -1, 0, 4, 16, 36, 64, 100, 144 };
            List<int> list15 = new List<int> { -225, -169, -121, -81, -49, -25, -9, -1, 0, 4, 16, 36, 64, 100, 144, 196 };
            List<int> list20 = new List<int> { -361, -289, -225, -169, -121, -81, -49, -25, -9, -1, 0, 4, 16, 36, 64, 100, 144, 196, 256, 324, 400 };
            List<int> list25 = new List<int> { -625, -529, -441, -361, -289, -225, -169, -121, -81, -49, -25, -9, -1, 0, 4, 16, 36, 64, 100, 144, 196, 256, 324, 400, 484, 576 };

            yield return new TestCaseData(11, list10).SetName("GenerateSortedSeries_n10");
            yield return new TestCaseData(13, list12).SetName("GenerateSortedSeries_n12");
            yield return new TestCaseData(16, list15).SetName("GenerateSortedSeries_n15");
            yield return new TestCaseData(21, list20).SetName("GenerateSortedSeries_n20");
            yield return new TestCaseData(26, list25).SetName("GenerateSortedSeries_n25");
        }

        [TestCaseSource(nameof(GenerateSortedSeriesData))]
        public void GenerateSortedSeries(int n, List<int> list)
        {
            var result = TestMethods.GenerateSortedSeries(n);
            Assert.That(result, Is.EqualTo(list));
        }
    }

    [TestFixture]
    public class TestFindNumberInSortedList
    {
        public static IEnumerable<TestCaseData> FindNumberInSortedListData()
        {
            yield return new TestCaseData(403, new List<int> { -840, 18, 92, 403, 701 });
            yield return new TestCaseData(-750, new List<int> { -5000, -750, 0, 999, 2500 });
            yield return new TestCaseData(150, new List<int> { 11, 14, 100, 120, 150 });
            yield return new TestCaseData(-30, new List<int> { -500, -400, -30, -10, -2 });
            yield return new TestCaseData(400, new List<int> { 20, 50, 100, 3000, 400 });
        }

        public static IEnumerable<TestCaseData> FindNumberInSortedListNegativeData()
        {
            yield return new TestCaseData(500, new List<int> { -840, 18, 92, 403, 701 });
            yield return new TestCaseData(-1000, new List<int> { -5000, -750, 0, 999, 2500 });
            yield return new TestCaseData(200, new List<int> { 11, 14, 100, 120, 150 });
            yield return new TestCaseData(-50, new List<int> { -500, -400, -30, -10, -2 });
            yield return new TestCaseData(1000, new List<int> { 20, 50, 100, 3000, 400 });
        }

        [TestCaseSource(nameof(FindNumberInSortedListData))]
        public void FindNumberInSortedList(int target, List<int> list) =>
            Assert.That(TestMethods.FindNumberInSortedList(target, in list), Is.True);

        [TestCaseSource(nameof(FindNumberInSortedListNegativeData))]
        public void DontFindNumberInSortedList(int target, List<int> list) =>
            Assert.That(TestMethods.FindNumberInSortedList(target, in list), Is.False);
    }

    [TestFixture()]
    public class TestFindPrime
    {
        public static IEnumerable<TestCaseData> FindPrimeData()
        {
            yield return new TestCaseData(
    11,
    new Stack<int>([15, 9, 22, 17, 4, 8, 11, 27, 6, 20]))
    .SetName("primeStack1");

            yield return new TestCaseData(
                5,
                new Stack<int>([14, 25, 19, 33, 10, 2, 21, 7, 18, 6, 5, 8]))
                .SetName("primeStack2");

            yield return new TestCaseData(
                7,
                new Stack<int>([28, 16, 13, 5, 20, 9, 2, 11, 30, 7, 18, 4]))
                .SetName("primeStack3");

            yield return new TestCaseData(
                13,
                new Stack<int>([6, 4, 9, 25, 14, 3, 18, 7, 20, 11, 13, 8, 10]))
                .SetName("primeStack4");

            yield return new TestCaseData(
                17,
                new Stack<int>([21, 8, 6, 19, 35, 4, 10, 2, 14, 9, 17, 12]))
                .SetName("primeStack5");

            yield return new TestCaseData(
                3,
                new Stack<int>([24, 11, 9, 28, 5, 2, 21, 14, 7, 18, 3, 20]))
                .SetName("primeStack6");

            yield return new TestCaseData(
                19,
                new Stack<int>([4, 27, 10, 33, 6, 13, 2, 8, 17, 20, 19, 9, 12, 15]))
                .SetName("primeStack7");

            yield return new TestCaseData(
                23,
                new Stack<int>([12, 5, 18, 7, 30, 2, 9, 14, 11, 16, 6, 23, 20]))
                .SetName("primeStack8");

            yield return new TestCaseData(
                29,
                new Stack<int>([15, 4, 21, 10, 3, 8, 19, 6, 2, 17, 12, 29, 14]))
                .SetName("primeStack9");

            yield return new TestCaseData(
                31,
                new Stack<int>([9, 20, 14, 6, 2, 11, 27, 5, 18, 4, 31, 10, 15, 8, 12]))
                .SetName("primeStack10");
        }

        [TestCaseSource(nameof(FindPrimeData))]
        public void FindPrime(int expected, Stack<int> stack)
        {
            Assert.That(TestMethods.FindPrime(in stack), Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class TestRemovePrime()
    {
        public static IEnumerable<TestCaseData> RemoveFirstPrimeData()
        {
            yield return new TestCaseData(
                new Stack<int>([2, 5, 11, 18, 23, 30, 41, 44, 59, 60]),
                new Stack<int>([2, 5, 11, 18, 23, 30, 41, 44, 60]))
                .SetName("stack1");

            yield return new TestCaseData(
                new Stack<int>([3, 7, 14, 19, 25, 29, 37, 42, 53, 68, 71]),
                new Stack<int>([3, 7, 14, 19, 25, 29, 37, 42, 53, 68]))
                .SetName("stack2");

            yield return new TestCaseData(
                new Stack<int>([5, 9, 13, 21, 27, 31, 43, 50, 67, 73, 88, 97]),
                new Stack<int>([5, 9, 13, 21, 27, 31, 43, 50, 67, 73, 88]))
                .SetName("stack3");

            yield return new TestCaseData(
                new Stack<int>([2, 4, 6, 17, 22, 35, 47, 58, 61, 79, 84]),
                new Stack<int>([2, 4, 6, 17, 22, 35, 47, 58, 61, 84]))
                .SetName("stack4");

            yield return new TestCaseData(
                new Stack<int>([3, 10, 15, 23, 28, 41, 46, 57, 83, 89, 94]),
                new Stack<int>([3, 10, 15, 23, 28, 41, 46, 57, 83, 94]))
                .SetName("stack5");

            yield return new TestCaseData(
                new Stack<int>([7, 12, 19, 24, 29, 34, 53, 62, 71, 78, 97]),
                new Stack<int>([7, 12, 19, 24, 29, 34, 53, 62, 71, 78]))
                .SetName("stack6");

            yield return new TestCaseData(
                new Stack<int>([2, 8, 11, 20, 31, 36, 43, 55, 67, 72, 101]),
                new Stack<int>([2, 8, 11, 20, 31, 36, 43, 55, 67, 72]))
                .SetName("stack7");

            yield return new TestCaseData(
                new Stack<int>([5, 14, 17, 26, 37, 48, 59, 64, 73, 86, 97]),
                new Stack<int>([5, 14, 17, 26, 37, 48, 59, 64, 73, 86]))
                .SetName("stack8");

            yield return new TestCaseData(
                new Stack<int>([3, 6, 13, 18, 29, 40, 47, 52, 71, 90, 103]),
                new Stack<int>([3, 6, 13, 18, 29, 40, 47, 52, 71, 90]))
                .SetName("stack9");

            yield return new TestCaseData(
                new Stack<int>([2, 9, 19, 27, 41, 50, 61, 70, 83, 92, 107]),
                new Stack<int>([2, 9, 19, 27, 41, 50, 61, 70, 83, 92]))
                .SetName("stack10");
        }

        [TestCaseSource(nameof(RemoveFirstPrimeData))]
        public void TestRemoveFirstPrime(Stack<int> stack, Stack<int> expected)
        {
            var result = TestMethods.RemoveFirstPrime(stack);
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class TestQueueFromStack()
    {
        public static IEnumerable<TestCaseData> QueueFromStackData()
        {
            yield return new TestCaseData(
                new Stack<int>([-5, 3, -12, 7, 0, 19, -2, 8]),
                new Queue<int>([-5, 3, -12, 7, 0, 19, -2, 8]))
                .SetName("case1");

            yield return new TestCaseData(
                new Stack<int>([10, -4, 6, -9, 15, -20, 3]),
                new Queue<int>([10, -4, 6, -9, 15, -20, 3]))
                .SetName("case2");

            yield return new TestCaseData(
                new Stack<int>([-1, -3, -5, 2, 4, 6, -8]),
                new Queue<int>([-1, -3, -5, 2, 4, 6, -8]))
                .SetName("case3");

            yield return new TestCaseData(
                new Stack<int>([100, -50, 25, -12, 6, -3, 1]),
                new Queue<int>([100, -50, 25, -12, 6, -3, 1]))
                .SetName("case4");

            yield return new TestCaseData(
                new Stack<int>([-7, 14, -21, 28, -35, 42]),
                new Queue<int>([-7, 14, -21, 28, -35, 42]))
                .SetName("case5");

            yield return new TestCaseData(
                new Stack<int>([0, -1, 1, -2, 2, -3, 3]),
                new Queue<int>([0, -1, 1, -2, 2, -3, 3]))
                .SetName("case6");

            yield return new TestCaseData(
                new Stack<int>([-100, 50, -25, 12, -6, 3]),
                new Queue<int>([-100, 50, -25, 12, -6, 3]))
                .SetName("case7");

            yield return new TestCaseData(
                new Stack<int>([9, -18, 27, -36, 45]),
                new Queue<int>([9, -18, 27, -36, 45]))
                .SetName("case8");

            yield return new TestCaseData(
                new Stack<int>([-2, 4, -8, 16, -32, 64]),
                new Queue<int>([-2, 4, -8, 16, -32, 64]))
                .SetName("case9");

            yield return new TestCaseData(
                new Stack<int>([13, -26, 39, -52, 65, -78, 91]),
                new Queue<int>([13, -26, 39, -52, 65, -78, 91]))
                .SetName("case10");
        }

        [TestCaseSource(nameof(QueueFromStackData))]
        public void QueueFromStack(Stack<int> stack, Queue<int> result)
        {
            var queue = TestMethods.QueueFromStack(stack);
            Assert.That(queue, Is.EqualTo(result));
        }
    }
}