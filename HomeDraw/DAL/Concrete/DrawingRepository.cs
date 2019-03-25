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
                Drawing drawing = context.Drawings.Find(drawingId);

                return drawing;
            }
        }

        public IEnumerable<Drawing> GetMyDrawings(string myId)
        {
            using (var context = new HomeDrawDbContext())
            {
                return context.Drawings.Where(c => c.CreatorID == myId).ToList();
            }
        }
    }
}
