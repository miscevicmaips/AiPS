using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Abstract;
using Domain.Entities;

namespace DAL.Concrete
{
    public class DrawingObjectRepository : IDrawingObjectRepository
    {
        public void CreateDrawingObject(DrawingObject drawingObject)
        {
            using (var context = new HomeDrawDbContext())
            {
                context.DrawingObjects.Add(drawingObject);

                context.SaveChanges();
            }
        }

        public DrawingObject ReadDrawingObject(int drawingObjectId)
        {
            using (var context = new HomeDrawDbContext())
            {
                return context.DrawingObjects.Find(drawingObjectId);
            }
        }

        public void UpdateDrawingObject(DrawingObject drawingObject)
        {
            using (var context = new HomeDrawDbContext())
            {
                context.Entry(drawingObject).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void DeleteDrawingObject(int drawingObjectId)
        {
            using (var context = new HomeDrawDbContext())
            {
                var drawingObjectToDelete = context.DrawingObjects.Find(drawingObjectId);

                context.DrawingObjects.Remove(drawingObjectToDelete);

                context.SaveChanges();
            }
        }

        public IEnumerable<DrawingObject> GetAllDrawingObjects()
        {
            using (var context = new HomeDrawDbContext())
            {
                return context.DrawingObjects.ToList();
            }
        }
        
    }
}
