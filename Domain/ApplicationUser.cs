using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Skype { get; set; }

        [MaxLength(500)]
        public string Comments { get; set; }

        public int UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

    }
}
