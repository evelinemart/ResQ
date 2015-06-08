using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResQ.Models
{
    public class ProcesRequest
    {
        public int RequestID { set; get; }
        public string FireStationID { set; get; }
    }
    public class JsonFireStation
    {
        public string FireStationName { set; get; }
        public double X { set; get; }
        public double Y { set; get; }
    }
    public class AddFire
    {
        [Required(ErrorMessage="Поле Email обязательно")]
        [Display(Name="Email")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Поле X обязательно")]
        [Display(Name = "X")]
        public double X { set; get; }
        [Required(ErrorMessage = "Поле Y обязательно")]
        [Display(Name = "Y")]
        public double Y { set; get; }
        [Required(ErrorMessage = "Поле Country обязательно")]
        [Display(Name = "Country")]
        public string Country { set; get; }
        [Required(ErrorMessage = "Поле City обязательно")]
        [Display(Name = "City")]
        public string City { set; get; }
        [Required(ErrorMessage = "Поле HouseNumber обязательно")]
        [Display(Name = "HouseNumber")]
        public string HouseNumber { set; get; }
        [Required(ErrorMessage = "Поле Street обязательно")]
        [Display(Name = "Street")]
        public string Street { set; get; }
    }
}