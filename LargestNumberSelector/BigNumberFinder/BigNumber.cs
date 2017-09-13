using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumberFinder
{
    public class BigNumber
    {
        public static int FindBiggestNumber(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }
            else
            {
                //return int.MaxValue; Original
                //return 100; version 2;
                int biggestNum = int.MinValue;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] > biggestNum)
                    {
                        biggestNum = numbers[i];
                    }
                }

                return biggestNum;
            }
        }

        public static int[] FindNumbersLargerThanN(int[] nums, int n)
        {
            //return null;
            List<int> largerThanN = new List<int>(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] > n)
                {
                    largerThanN.Add(nums[i]);
                }
            }

            return largerThanN.ToArray();
        }
    }
}
