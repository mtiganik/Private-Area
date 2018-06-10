using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class PositionName
    {
        public int PositionNameId { get; set; }

        public int PositionNameNameId { get; set; }

        [ForeignKey(nameof(PositionNameNameId))]
        [Display(Name = nameof(Resources.Domain.PositionName.PositionNameName), ResourceType = typeof(Resources.Domain.PositionName))]
        public MultiLangString PositionNameName { get; set; }

        public virtual List<Position> Positions { get; set; } = new List<Position>();

    }
}
