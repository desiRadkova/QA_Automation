using Summator;

namespace Summator.SummatorNUnitTests
{
    public class SummatorNUitTests
    {

        public class SummaryTests
        {        
            int i = 0;
        

        [SetUp]
        public void StartCallMethods()
        {
            i = i + 1;

            Console.WriteLine("Test call Summary Tests: " + i);
        }
            [Test]
            public void Test1_Sum_TwoPositiveNumbers()
            {
                var nums = new int[] { 1, 2 };
                var actual = Summator.Sum(nums);
                var expected = 3;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test2_Sum_TwoNegativeNumbers()
            {
                var nums = new int[] { -1, -99 };
                var actual = Summator.Sum(nums);
                var expected = -100;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test3_Sum_TwoOneNumber()
            {
                var nums = new int[] { 4};
                var actual = Summator.Sum(nums);
                var expected = 4;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test4_Sum_ZeroNumber()
            {
                var nums = new int[] { };
                var actual = Summator.Sum(nums);
                var expected = 0;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test5_Sum_BigNumbers()
            {
                var nums = new int[] { 2000000000, 2000000000, 2000000000, 2000000000};
                var actual = Summator.Sum(nums);
                var expected = 8000000000;
                Assert.AreEqual(expected, actual);
            }
        }
        public class Average
        {
            int i = 0;


            [SetUp]
            public void StartCallMethods()
            {
                i = i + 1;

                Console.WriteLine("Test call Average Tests: " + i);
            }

            [Test]
            public void Test6_Avg_Number()
            {
                var nums = new int[] { 3, 7, 2 };
                var actual = Summator.Average(nums);
                var expected = 4;
                Assert.AreEqual(expected, actual);
            }
        }
       public class Multiply
        {
            int i = 0;


            [SetUp]
            public void StartCallMethods()
            {
                i = i + 1;

                Console.WriteLine("Test call Multiply Tests: " + i);
            }

            [Test]
            public void Test7_Multiply_Number()
            {
                var nums = new int[] { 3, 2 };
                var actual = Summator.Multiply(nums);
                var expected = 6;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test8_Multiply_ZeroNumber()
            {
                var nums = new int[] { 0 };
                var actual = Summator.Multiply(nums);
                var expected = 0;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test9_Multiply_ZeroArrElemes()
            {
                var nums = new int[] { };
                var actual = Summator.Multiply(nums);
                var expected = 0;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test10_Multiply_NegativeNumbers()
            {
                var nums = new int[] { -4, -5};
                var actual = Summator.Multiply(nums);
                var expected = 20;
                Assert.AreEqual(expected, actual);
            }
        }
       public class Division
        {
            int i = 0;


            [SetUp]
            public void StartCallMethods()
            {
                i = i + 1;

                Console.WriteLine("Test call Division Tests: " + i);
            }

            [Test]
            public void Test11_Division_TwoNumbers()
            {
                var nums = new int[] { 4, 2 };
                var actual = Summator.Division(nums);
                var expected = 2;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test12_Division_ByZeroNumbers()
            {
                var nums = new int[] { 0, 2 };
                var actual = Summator.Division(nums);
                var expected = 0;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test13_Division_ByZero()
            {
                var nums = new int[] { };
                var actual = Summator.Division(nums);
                string empty = null;
                var expected = empty;
                ;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test14_Division_NegativeNumbers()
            {
                var nums = new int[] { -8, -5 };
                var actual = Summator.Division(nums);
                var expected = 1.6;
                Assert.AreEqual(expected, actual);
            }
        }
        public class DivisionWithReminder
        {
            int i = 0;


            [SetUp]
            public void StartCallMethods()
            {
                i = i + 1;

                Console.WriteLine("Test call Division With Reminder Tests: " + i);
            }

            [Test]
            public void Test15_DivisionWithRemander_TwoNumbers()
            {
                var nums = new int[] { 68, 5 };
                var actual = Summator.DivisionWithRemander(nums);
                var expected = 3;
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void Test16_DivisionWithRemander_NegatoveNumbers()
            {
                var nums = new int[] { -76, -4 };
                var actual = Summator.DivisionWithRemander(nums);
                var expected = 0;
                Assert.AreEqual(expected, actual);
            }
        }
        [TestCase(new int[] { 10, 15},25)]
        [TestCase(new int[] { -10, -15 }, -25)]
        [TestCase(new int[] { 10, 0 }, 10)]
        [TestCase(new int[] { 2000000000, 2000000000, 2000000000, 2000000000 }, 8000000000)]
        [TestCase(new int[] { }, 0)]
        public void TestSuitSum(int[] values,long expected)
        {
            var actual = Summator.Sum(values);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 2 },4)]
        [TestCase(new int[] { -3, -7, -2 }, -4)]
        public void TestSuitAvarage(int[] values, double expected)
        {
            var actual = Summator.Average(values);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {25,2 },12.5)]
        [TestCase(new int[] { -25,2},-12.5)]
        public void TestSuitDivision(int[] value, double expected)
        {
            var actual = Summator.Division(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 25, 8}, 200)]
        [TestCase(new int[] { -65, 0}, 0)]
        [TestCase(new int[] { -98,-34},3332)]
        [TestCase(new int[] { 20, -6}, -120)]
        public void TestSuitMultiply(int[] value, int expected)
        {
            var actual = Summator.Multiply(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 85,4},1)]
        [TestCase(new int[] { -65, -2},-1)]
        public void TestSuitDivisionWithRemander(int[] value, int expected)
        {
            var actual = Summator.DivisionWithRemander(value); 
            Assert.AreEqual(expected, actual);
        }
    }
}