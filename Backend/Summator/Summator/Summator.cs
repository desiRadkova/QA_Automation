using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Summator
{
    public static class Summator
    {
        public static long Sum(int[] arr)
        {
        //checked //This finds the reason why something has strange values
        //{
            long sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        //}
    }
        public static double Average(int[] arr)
        {
            //checked //This finds the reason why something has strange values
            //{
            double res = 0.0;

            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i];
            }
            res = res/ arr.Length;
            return res;
            //}
        }
        public static int Multiply(int[] arr)
        {
            checked //This finds the reason why something has strange values
            {
                int res = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                res *= arr[i];
            }
            

            return res;
            }
        }
        public static double Division(int[] arr)
        {
            //checked //This finds the reason why something has strange values
            //{
                double res = 0.0, numbA = 0.0, numbB = 0.0;

                for (int i = 0; i < arr.Length; i++)
                {
                    //res /= arr[i];
                    if (i == 0 && arr.Length != 0)
                    {
                        numbA = arr[i];
                }
                else
                {
                    numbB = arr[i];
                }
                }
            res = numbA / numbB;

                return res;
            //}
        }
        public static double DivisionWithRemander(int[] arr)
        {
            //checked //This finds the reason why something has strange values
            //{
            double res = 0.0, numbA = 0.0, numbB = 0.0;

            for (int i = 0; i < arr.Length; i++)
            {
                //res /= arr[i];
                if (i == 0 && arr.Length != 0)
                {
                    numbA = arr[i];
                }
                else
                {
                    numbB = arr[i];
                }
            }
            res = numbA % numbB;

            return res;
            //}
        }
        //public static void Test_SumTwoNumbers()
        //{
        //    if (Sum(new int[] { 1, 2 }) != 3)
        //    {
        //        throw new Exception("1 + 2 != 3");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Test_SumTwoNumbers: Test Pass!");
        //    }
        //}
    }
}
