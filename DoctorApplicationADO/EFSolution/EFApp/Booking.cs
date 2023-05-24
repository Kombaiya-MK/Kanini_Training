using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFApp
{
    public class Booking
    {
        [Key]
        public int BookingNumber { get; set; }

        public Movie Movie { get; set; }
        
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public DateTime BookingDate { get; set; }
    }

}
