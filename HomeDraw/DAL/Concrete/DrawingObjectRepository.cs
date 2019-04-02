using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;
using Domain.Entities;

namespace DAL.Concrete
{
    public class DrawingObjectRepository : IDrawingObjectRepository
    {
        public void CreateObject(DrawingObject drawingObject)
        {
            using (var context = new HomeDrawDbContext())
            {
                context.DrawingObjects.Add(drawingObject);
                context.SaveChanges();
            }
        }
    }
}
