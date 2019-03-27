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
            throw new NotImplementedException();
        }

        public void Delete(int roomId)
        {
            throw new NotImplementedException();
        }

        public Room GetRoomById(int roomId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            throw new NotImplementedException();
        }
    }
}
