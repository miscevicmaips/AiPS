using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.DTO;

namespace WebUI.Models
{
    public class PublicDrawingsViewModel
    {
        public IEnumerable<DrawingDTO> PublicDrawings { get; set; }

        public string DrawingPassword { get; set; }
    }
}