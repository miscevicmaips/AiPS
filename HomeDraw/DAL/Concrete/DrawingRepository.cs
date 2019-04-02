using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;
using Domain.Entities;

namespace DAL.Concrete
{
    public class DrawingRepository : IDrawingRepository
    {
        public Drawing GetDrawingById(int drawingId)
        {
            using (var context = new HomeDrawDbContext())
            {
                Drawing drawingToReturn = new Drawing();

                drawingToReturn = context.Drawings.Find(drawingId);

                context.Entry(drawingToReturn).Reference(o => o.DrawingObjects).Load();

                return drawingToReturn;
            }
        }
    }
}
