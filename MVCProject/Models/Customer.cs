using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace MVCProject.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public char Gender { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }


        //relation with trip
        public ICollection<Ticket> Ticket { get; set; } = new List<Ticket>();
    }
}
