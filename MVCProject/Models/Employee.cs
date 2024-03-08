using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MVCProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        // relation with plan

        public ICollection<Plan> Plans { get; set; } = new List<Plan>();



        // relation with trip

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();


    }
}
