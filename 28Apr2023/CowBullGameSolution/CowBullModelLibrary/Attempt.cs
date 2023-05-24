using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowBullModelLibrary 
{
    public class Attempt : IEquatable<Attempt>
    {
        public int id { get; set; }
        public string Gueword { get; set; }
        public string Givword { get; set; }
        public int AttemptNumber { get; set; }

        public Attempt()
        {
            
        }
        public Attempt(int id , string Gueword, string Givword , int no) 
        { 
            this.id = id;
            this.Gueword = Gueword;
            this.Givword = Givword;
            AttemptNumber = no;
        }

        public bool Equals(Attempt? other)
        {
            return this.id == other.id;
        }

        public override string ToString()
        {
            return $"Id : {id} \nGuess Word : {Gueword} \nGiven Word : {Givword} \nAttempt : {AttemptNumber}";
        }
    }
}
