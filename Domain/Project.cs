using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Project
    {
        public int ProjectId { get; set; }

        [MaxLength(100)]
        public string ProjectName { get; set; }

        [MaxLength(100)]
        public string ProjectNameEst { get; set; }

        public DateTime ProjectStartDate { get; set; }

        public DateTime ProjectEndDate { get; set; }

        public int ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }

        public virtual List<Position> Positions { get; set; } = new List<Position>();
    }
}
