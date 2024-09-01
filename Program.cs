namespace MajorityElemenet
{
    internal class Program
    {
        //Given an array of N integers, write a program to return an element that occurs
        //more than N/2 times in the given array.
        //You may consider that such an element always exists in the array.
        static void Main(string[] args)
        {
            int[] myArray = { 2, 2, 3, 3, 1, 2, 2 };
            Console.WriteLine(FindMajorityElement2(myArray));
        }

        //Optimized
        static int FindMajorityElement2(int[] nums)
        {
            int count = 0, element = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    element = nums[i];
                    count = 1;
                }
                else if (nums[i] == element)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
            int count1 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == element) { count1++; }
            }
            if (count1 > nums.Length / 2)
                return element;


            return -1;
        }

        //better
        static int FindMajorityElement1(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int , int> map = new Dictionary<int , int>();
            for(int i = 0; i < n; i++)
            {
                int count = 1;
                if (map.ContainsKey(nums[i]))
                {
                    //map[nums[i]] = map[nums[i]] + 1;
                    map[nums[i]] +=  1;
                }
                else
                {
                    map.Add(nums[i], count);
                }
            }

            foreach (var i in map)
            {
                if (i.Value > n / 2)
                    return i.Key;
            }


            return -1;
        }

        //brute
        static int FindMajorityElement(int[] nums)
        {
            int n = nums.Length;
            int targetNum = n / 2;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (nums[i] == nums[j])
                    { 
                        count++; 
                    }
                }
                if (count > targetNum)
                {
                    return nums[i];
                }
            }

            return -1;

        }
    }
}
