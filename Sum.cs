using System.Collections.Generic;
namespace concole
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
                        return new[] { dict[nums[i]], i };
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
                    return new[] { i, dict[nums[i]] };
                }
            }

            return null;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> results = new List<IList<int>>();

            int? prev = null;
            for (int k = nums.Length - 1; k >= 2; k--)
            {
                if (nums[k] == prev)
                {
                    continue;
                }

                int i = 0;
                int j = k - 1;
                while (i < j)
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        results.Add(new[] { nums[k], nums[i], nums[j] });
                        prev = nums[k];
                        while (i + 1 < j && nums[i] == nums[i + 1])
                        {
                            i++;
                        }

                        while (j - 1 > i && nums[j] == nums[j - 1])
                        {
                            j--;
                        }

                        i++;
                        j--;
                    }

                    else if (nums[i] + nums[j] + nums[k] < 0)
                    {
                        i++;
                    }

                    else if (nums[i] + nums[j] + nums[k] > 0)
                    {
                        j--;
                    }
                }
            }

            return results;
        }
    }
}