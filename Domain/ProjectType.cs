using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class ProjectType
    {
        public int ProjectTypeId { get; set; }

        [MaxLength(100)]
        public string ProjectTypeName { get; set; }

        [MaxLength(100)]
        public string ProjectTypeNameEst { get; set; }

        [MaxLength(300)]
        public string ProjectTypeComments { get; set; }

        [MaxLength(300)]
        public string ProjectTypeCommentsEst { get; set; }


    }
}
