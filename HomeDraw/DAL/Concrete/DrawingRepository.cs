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
                return context.Drawings.Where(d => d.DrawingID == drawingId).Include(dro => dro.DrawingObjects).Include(ju => ju.JoinedUsers).FirstOrDefault();
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
        
        public Dictionary<int, Queue<string>> CreateRooms()
        {
            Dictionary<int, Queue<string>> Rooms = new Dictionary<int, Queue<string>>();

            using (var context = new HomeDrawDbContext())
            {
                var drawings = (from p in context.Drawings select p);

                foreach(Drawing drawing in drawings)
                {
                    Queue<string> queue = new Queue<string>();

                    queue.Enqueue(drawing.MasterID);

                    foreach(AppUser user in drawing.JoinedUsers)
                    {
                        queue.Enqueue(user.Id);
                    }

                    Rooms.Add(drawing.DrawingID, queue);
                }
            }

            return Rooms;
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
