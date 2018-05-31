using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Position
    {
        public int PositionId { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int PositionNameId { get; set; }
        public PositionName PositionName { get; set; }

        public bool IsMarketer { get; set; }

    }
}
