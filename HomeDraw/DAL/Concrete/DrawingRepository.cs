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
    public class DrawingRepository : IDrawingRepository
    {
        public void CreateDrawing(Drawing drawing)
        {
            using (var context = new HomeDrawDbContext())
            {
                context.Drawings.Add(drawing);

                context.SaveChanges();
            }
        }

        public Drawing ReadDrawing(int drawingId)
        {
            using (var context = new HomeDrawDbContext())
            {
                return context.Drawings.Where(d => d.DrawingID == drawingId).Include(dro => dro.DrawingObjects).FirstOrDefault();
            }
        }

        public void UpdateDrawing(Drawing drawing)
        {
            using (var context = new HomeDrawDbContext())
            {
                context.Entry(drawing).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void DeleteDrawing(int drawingId)
        {
            using (var context = new HomeDrawDbContext())
            {
                var drawingToDelete = context.Drawings.Find(drawingId);

                context.Drawings.Remove(drawingToDelete);

                context.SaveChanges();
            }
        }

        public IEnumerable<Drawing> GetAllDrawings()
        {
            using (var context = new HomeDrawDbContext())
            {
                return context.Drawings.Include(dr => dr.DrawingObjects).ToList();
            }
        }
        
    }
}
