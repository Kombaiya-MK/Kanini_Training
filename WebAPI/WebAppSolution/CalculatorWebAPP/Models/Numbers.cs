namespace CalculatorWebAPP.Models
{
    public class Numbers
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string operation { get; set; }
        public int result { get; set; }

        public Numbers()
        {
            
        }
        public Numbers(int n1 , int n2 , string opr , int res)
        {
            Number1 = n1;
            Number2 = n2;
            operation = opr;
            result = res;
        }
        public override string ToString()
        {
            return $"Number 1 : {Number1} {operation} Number 2 : {Number2} = {result}";
        }
    }
}
