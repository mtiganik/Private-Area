using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CompanyProject
    {
        // TODO: maybe this is not needed at all
        public int CompanyProjectId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
