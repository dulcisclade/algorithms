namespace concole
{
    public static class Program
    {
        
        public static void Main(string[] args)
        {
            int[] arr = {2, 1, 3, 1, 2};
            long result = CountInversions(arr);
        }

        private static long Sort(int[] realArray, int[] tempArray, long start, long end)
        {
            long result = 0;
            if (start == end)
            {
                return 0;
            }

            //do not copy array all the time,
            //use one temp array
            long middle = start + (end - start) / 2;

            result += Sort(realArray, tempArray, start, middle);
            result += Sort(realArray, tempArray, middle + 1, end);
            result += Merge(realArray, tempArray, start, middle, end);
            return result;
        }

        private static long Merge(int[] realArray, int[] tempArray, long start, long middle, long end)
        {
            //9 8 7 6 5 4 3 2 1
            //9 8 * * * * * * *
            //* * 7 6 * * * * *
            //8 9 6 7 * * * * *
            for (long i = 0; i <= tempArray.Length; i++)
            {
                tempArray[i] = 0;
            }

            //copy just a part
            for (long i = start; i <= end; i++)
            {
                tempArray[i] = realArray[i];
            }

            long result = 0;
            var left = start;
            var right = middle + 1;

            for (var realCurrent = start; realCurrent <= end; realCurrent++)
            {
                if (left > middle)
                {
                    while (realCurrent <= end)
                    {
                        realArray[realCurrent] = tempArray[right];
                        right++;
                        realCurrent++;
                    }
                }
                else if (right > end)
                {
                    while (realCurrent <= end)
                    {
                        realArray[realCurrent] = tempArray[left];
                        left++;
                        realCurrent++;
                    }
                }

                // 1234 * <-
                //89      67
                else if (tempArray[right] < tempArray[left])
                {
                    realArray[realCurrent] = tempArray[right];
                    right++;
                    result += (middle + 1) - left;
                }
                else if (tempArray[right] >= tempArray[left])
                {
                    realArray[realCurrent] = tempArray[left];
                    left++;
                }
            }

            return result;
        }

        private static long CountInversions(int[] realArray)
        {
            var tempArray = new int[realArray.Length];
            return Sort(realArray, tempArray, 0, realArray.Length - 1);
        }
    }
}