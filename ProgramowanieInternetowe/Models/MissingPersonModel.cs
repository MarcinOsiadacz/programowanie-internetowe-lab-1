using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramowanieInternetowe.Models
{
    public class MissingPersonModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide gender")]
        public bool Gender { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }
    }
}