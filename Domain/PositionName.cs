using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class PositionName
    {
        public int PositionNameId { get; set; }

        [MaxLength(200)]
        public string PositionNameEng { get; set; }

        [MaxLength(200)]
        public string PositionNameEst { get; set; }

        public virtual List<Position> Positions { get; set; } = new List<Position>();

    }
}
