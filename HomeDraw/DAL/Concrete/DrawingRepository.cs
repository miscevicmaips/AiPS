﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;

namespace DAL.Concrete
{
    public class DrawingRepository : IDrawingRepository
    {
        private HomeDrawDbContext context = new HomeDrawDbContext();
    }
}
