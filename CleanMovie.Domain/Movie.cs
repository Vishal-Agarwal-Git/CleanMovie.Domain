using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain
{
    public class Movie
    {
        //   public int MovieId { get; set; }
        //   public string MovieName { get; set; } = string.Empty;
        //   public decimal RentalCost { get; set; }
        ////   public int RentalDuration { get; set; }

        //   // Many to Many Relationship    
        ////   public IList<MovieRental> MovieRentals { get; set; }
        ///



        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        
    }
}
