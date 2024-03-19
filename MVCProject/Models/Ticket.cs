using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Ticket
    {
        public int Id { get; set; } 
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        [ForeignKey("Trip")]
        public int? TripId { get; set; }
        public int Quentity { get; set; }


        //relation with customer
        public Customer? Customer { get; set; }



        // relation with trip
        public Trip Trip { get; set; }
    }
}
