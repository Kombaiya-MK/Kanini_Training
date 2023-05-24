using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeProblemApp
{
    public class MajorityElement
    {
        public int FindMajorityElement(int[] nums)
        {
            IDictionary<int,int> map = new Dictionary<int,int>();
            foreach (int num in nums)
            {
                if (map.ContainsKey(num)) {
                    map[num]++;
                }
                else { map[num] = 1; }
            }

            foreach (int num in map.Keys) 
            {
                if (map[num] > (nums.Length / 2))
                    return num;
            }
            return 0;
        }
    }
}
