using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Numerics;

namespace MVCProject.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int Seats_Num { get; set; }
        public int Available_Seats { get; set; }
        public int Total_Seats { get; set; }
        public TimeOnly Arrival_Time { get; set; }
        public TimeOnly Departure_Time { get; set; }
        public DateOnly Departure_Date { get; set; }


        // relation with plan

        public Plan? Plan { get; set; }



        //relation with employee
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }



        //relation with customer
        public ICollection<Ticket> Ticket { get; set; } = new HashSet<Ticket>();

    }
}
