using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class PositionCreateEditViewModel
    {
        public Position Position { get; set; }

        public SelectList ApplicationUserSelectList { get; set; }

        public SelectList ProjectsSelectList { get; set; }

        public SelectList PositionNameSelectList { get; set; }
    }
}
