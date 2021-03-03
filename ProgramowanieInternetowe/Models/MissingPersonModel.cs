using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProgramowanieInternetowe.Models
{
    public class MissingPersonModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide gender")]
        public bool Gender { get; set; }

        [DataType(DataType.ImageUrl)]
        [DisplayName("Photo")]
        public string PhotoUrl { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }
    }
}