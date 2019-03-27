using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class SavedDrawingsViewModel
    {
        public IEnumerable<Drawing> SavedDrawings { get; set; }
    }
}