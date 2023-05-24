using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeProblemApp
{
    public class ContainsDuplicate
    {
        public bool CheckContainsDuplicate(int[] nums)
        {
            bool status = false;
            IDictionary<int,int> Map = new Dictionary<int,int>();
            foreach(int i in nums)
            {
                if(Map.ContainsKey(i))
                    status = true;
                else
                    Map[i] = 1;
            }
            return status;
        }
    }
}
