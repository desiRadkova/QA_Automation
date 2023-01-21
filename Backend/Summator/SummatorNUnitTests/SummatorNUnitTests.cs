using Summator;

namespace Summator.SummatorNUnitTests
{
    public class SummatorNUitTests
    {
        public class SummaryTests
        {
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
        
    }
}