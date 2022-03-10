using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.dto
{
    public class AppUserRequestDto
    {
        [Required]
        [StringLength(128, MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 5)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
       
    }
}
