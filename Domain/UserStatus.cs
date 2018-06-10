using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class UserStatus
    {
        public int UserStatusId { get; set; }

        public int UserStatusNameId { get; set; }
        [ForeignKey(nameof(UserStatusNameId))]
        [Display(Name = nameof(Resources.Domain.UserStatus.UserStatusName), ResourceType = typeof(Resources.Domain.UserStatus))]
        public MultiLangString UserStatusName { get; set; }


    }
}
