using DAL.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class RoomRepository : IRoomRepository
    {
        public void Create(Room room)
        {
            using (var context = new HomeDrawDbContext())
            {
                context.Rooms.Add(room);
                context.SaveChanges();
            }
        }

        public void Delete(int roomId)
        {
            using (var context = new HomeDrawDbContext())
            {
                Room roomToDelete = new Room();
                roomToDelete = context.Rooms.Find(roomId);
                context.Rooms.Remove(roomToDelete);
                context.SaveChanges();
            }
        }

        public Room GetRoomById(int roomId)
        {
            using (var context = new HomeDrawDbContext())
            {
                Room roomToReturn = new Room();

                roomToReturn = context.Rooms.Find(roomId);

                context.Entry(roomToReturn).Reference(c => c.ContainedDrawing).Load();

                return roomToReturn;
            }
        }

        public IEnumerable<Room> GetAllRooms()
        {
            using (var context = new HomeDrawDbContext())
            {
                return context.Rooms.ToList();
            }
        }
    }
}
