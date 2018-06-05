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
        [Display(Name = nameof(Resources.Domain.PositionName.PositionNameEng), ResourceType = typeof(Resources.Domain.PositionName))]
        public string PositionNameEng { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(Resources.Domain.PositionName.PositionNameEst), ResourceType = typeof(Resources.Domain.PositionName))]
        public string PositionNameEst { get; set; }

        public virtual List<Position> Positions { get; set; } = new List<Position>();

    }
}
