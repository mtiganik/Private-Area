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
        public string UserStatusName { get; set; }

        [MaxLength(100)]
        public string UserStatusNameEst { get; set; }


    }
}
