using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResQ.Models
{
    public class Location
    {
        [Key]
        [Required]
        public int Id { set; get; }
        public double X { set; get; }
        public double Y { set; get; }
        public string Country { set; get; }
        public string City { set; get; }
        public string Street { set; get; }
        public string House_Number { set; get; }
    }
    public class FireStation
    {
        [Key]
        [Required]
        public int Id { set; get; }
        public string FireStationName { set; get; }

        public int LocationId { set; get; }
        public Location Location { set; get; }

    }
    public class Request
    {
        [Key]
        [Required]
        public int ID { set; get; }

        public string UserId { set; get; }
        public ApplicationUser User { set; get; }

        public int LocationId { set; get; }
        public Location Location { set; get; }

        public int FireStationId { set; get; }
        public FireStation FireStation { set; get; }

        public DateTime Date { set; get; }
        public DateTime DateFinished { set; get; }
        public string Status { set; get; }

    }

    public class HelpInfo
    {
        public int ID { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Message { set; get; }
    }
}