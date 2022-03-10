using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.dto
{
    public class AppUserUpdateDto
    {
        [StringLength(128, MinimumLength = 5)]
        public string FirstName { get; set; }

        [StringLength(128, MinimumLength = 5)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Years { get; set; }
    }
}
