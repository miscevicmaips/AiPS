using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAL.Abstract
{
    public interface IDrawingRepository
    {
        Drawing GetDrawingById(int drawingId);
    }
}
