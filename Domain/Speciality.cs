using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Speciality
    {
        public int SpecialityId { get; set; }

        [MaxLength(100)]
        public string SpecialityName { get; set; }

        [MaxLength(100)]
        public string SpecialityNameEst { get; set; }
    }
}
