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

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> results = new List<IList<int>>();

            int? prev = null;
            for (int k = nums.Length - 1; k >= 2; k--) //max
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

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> results = new List<IList<int>>();
            if (nums.Length < 3)
            {
                return results;
            }

            Array.Sort(nums);

            for (int k = nums.Length - 1; k >= 3; k--) //max
            {
                if (k != nums.Length - 1 && nums[k] == nums[k + 1])
                {
                    continue;
                }

                for (int l = k - 1; l >= 2; l--) //premax
                {
                    if (l != k - 1 && nums[l] == nums[l + 1])
                    {
                        continue;
                    }

                    int j = l - 1;
                    int i = 0;
                    while (i < j && i < l)
                    {
                        if (nums[k] + nums[l] + nums[j] + nums[i] == target)
                        {
                            results.Add(new[] {nums[k], nums[l], nums[j], nums[i]});
                            while (i < j && nums[i] == nums[i + 1])
                            {
                                i++;
                            }

                            while (j > i && nums[j] == nums[j - 1])
                            {
                                j--;
                            }

                            i++;
                            j--;
                        }

                        else if (nums[k] + nums[l] + nums[j] + nums[i] < target)
                        {
                            i++;
                        }

                        else if (nums[k] + nums[l] + nums[j] + nums[i] > target)
                        {
                            j--;
                        }
                    }
                }
            }

            return results;
        }
    }
}