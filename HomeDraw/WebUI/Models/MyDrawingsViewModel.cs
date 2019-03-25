using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class MyDrawingsViewModel
    {
        public IEnumerable<Drawing> MyDrawings { get; set; }
    }
}