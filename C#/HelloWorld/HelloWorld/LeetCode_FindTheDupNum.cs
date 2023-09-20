using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
  
    public class LeetCode_FindTheDupNum
    {
        public int FindDuplicate()
        {
            int[] nums = new int[] { 3, 1, 3, 4, 2 };
            //option 1:
            /*
             * List<int> checklist = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (checklist.Contains(nums[i]))
                {
                    return nums[i];
                }

                checklist.Add(nums[i]);
            }

            return 0; 
            */

            //option 2:
            int slow = nums[0];
            int fast = nums[0];

            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            } while (slow != fast);

            slow = nums[0];
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }

            return slow;
        }
    }
}
