using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pickup_Point { get; set; }
        public string Description { get; set; }

        [ForeignKey("Trip")]
        public int? TripId { get; set; }

        //relation witg trip

        public Trip? Trip { get; set; }


        //relation with employee
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}
