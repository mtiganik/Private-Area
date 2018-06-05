using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class UserStatus
    {
        public int UserStatusId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.UserStatus.UserStatusName), ResourceType = typeof(Resources.Domain.UserStatus))]
        public string UserStatusName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Resources.Domain.UserStatus.UserStatusNameEst), ResourceType = typeof(Resources.Domain.UserStatus))]
        public string UserStatusNameEst { get; set; }


    }
}
