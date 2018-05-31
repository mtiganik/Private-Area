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
        [Display(Name = nameof(Resources.Domain.ApplicationUser.FirstName), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.ApplicationUser.LastName), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public string LastName { get; set; }

        [Display(Name = nameof(Resources.Domain.ApplicationUser.FullName), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public string FullName {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Display(Name = nameof(Resources.Domain.ApplicationUser.Address), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.ApplicationUser.Skype), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public string Skype { get; set; }

        [MaxLength(500)]
        [Display(Name = nameof(Resources.Domain.ApplicationUser.Comments), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public string Comments { get; set; }

        [Display(Name = nameof(Resources.Domain.ApplicationUser.UserName), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        [Display(Name = nameof(Resources.Domain.ApplicationUser.PhoneNumber), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        public int UserStatusId { get; set; }
        [Display(Name = nameof(Resources.Domain.ApplicationUser.UserStatus), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public virtual UserStatus UserStatus { get; set; }

        public int DepartmentId { get; set; }
        [Display(Name = nameof(Resources.Domain.ApplicationUser.Department), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public virtual Department Department { get; set; } 

        [Display(Name = nameof(Resources.Domain.ApplicationUser.Positions), ResourceType = typeof(Resources.Domain.ApplicationUser))]
        public virtual List<Position> Positions { get; set; } = new List<Position>();

        public virtual List<Contact> Contacts { get; set; }


    }

}
