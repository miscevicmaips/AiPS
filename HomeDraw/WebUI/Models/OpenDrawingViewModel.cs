using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class OpenDrawingViewModel
    {
        public Drawing Drawing { get; set; }

        public string SavedDrawingName { get; set; }
    }
}