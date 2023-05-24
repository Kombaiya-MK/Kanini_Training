namespace LeetcodeProblemApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MajorityElement obj = new MajorityElement();
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            //Console.WriteLine(obj.FindMajorityElement(nums)); 
            //ContainsDuplicate obj1 = new ContainsDuplicate();
            //Console.WriteLine(obj1.CheckContainsDuplicate(nums));
            ThreeSum obj2 = new ThreeSum();
            
            foreach (var num in obj2.CheckThreeSum(nums))
            {
                Console.WriteLine("------------------");
                foreach (int i in num) { Console.WriteLine(i); }
            }
        }
    }
}