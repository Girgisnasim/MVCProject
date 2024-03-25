using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class TripVM
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please Choose The File")]
        public string? image { get; set; }
        [Required(ErrorMessage = "Please enter a location")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Please enter a price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter a status")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Please enter a available seats")]

        public int Available_Seats { get; set; }
        [Required(ErrorMessage = "Please enter a total seats")]
        public int Total_Seats { get; set; }
        [Required(ErrorMessage = "Please enter a arrive time")]
        public TimeOnly Arrival_Time { get; set; }
        [Required(ErrorMessage = "Please enter a departure time")]
        public TimeOnly Departure_Time { get; set; }
        [Required(ErrorMessage = "Please enter a departure date")]
        public DateOnly Departure_Date { get; set; }
    }
}
