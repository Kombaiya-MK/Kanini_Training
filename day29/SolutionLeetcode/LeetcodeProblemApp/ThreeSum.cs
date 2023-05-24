using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeProblemApp
{
    internal class ThreeSum
    {
        public IList<IList<int>> CheckThreeSum(int[] nums)
        { 
            IList<IList<int>> solution = new List<IList<int>>();
            HashSet<string> visited = new HashSet<string>();  
            //IDictionary<List<int>,int> Map = new Dictionary<List<int>,int>();
            Array.Sort(nums);
            //int count = 0;
            for(int i = 0; i < nums.Length - 1;i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while(j<k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if(sum == 0)
                    {
                        string temp = "";
                        temp += nums[i].ToString() + " " + nums[j].ToString()+ " " + nums[k].ToString();
                        //Console.WriteLine(temp);
                        //Console.WriteLine("value of number : " + nums[i] + nums[j] + nums[k]);
                        visited.Add(temp);
                        j++;
                    }
                    else if (sum > 0)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            //Console.WriteLine(visited.Count);
            //solution.
            
            foreach (var item in visited)
            {
                IList<int> window = new List<int>();
                foreach (var i in item.Split(" "))
                {

                    //Console.WriteLine(Convert.ToInt32(i));
                    window.Add(Convert.ToInt32(i));
                }
                solution.Add(window);
                //
                //foreach (var i in item)
                //{
                //    Console.WriteLine(Convert.ToInt32(i));
                //    window.Add(Convert.ToInt32(i));
                //}
                //solution.Add(window);
                //Console.WriteLine("Inside visited");
                //Console.WriteLine("value of "+i);
            }
            return solution;
        }
    }
}
