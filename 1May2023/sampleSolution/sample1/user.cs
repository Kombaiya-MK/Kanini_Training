using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample1
{
    public class user
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public override string ToString()
        {
            return $" Id : {id} \nName : {name} \nAge : {age}";
        }
    }
}
