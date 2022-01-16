using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Display(Name = "Tel Number"),StringLength(10)]
        public string TelNumber { get; set; }

        [Display(Name ="Reservation Type"),Required]
        public string ReservationType { get; set; }
   
        [DataType(DataType.Date) ,Display(Name = "Start Date"), Required , DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date),Display(Name = "End Date"), Required, DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime EndDate { get; set; }

    }
}