using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Program
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    if (nums[i] * 2 == target)
                    {
                        return new[] {dict[nums[i]], i};
                    }
                }
                else
                {
                    dict.Add(target - nums[i], i);
                }
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]) && i != dict[nums[i]])
                {
                    return new[] {i, dict[nums[i]]};
                }
            }

            return null;
        }
    }
}