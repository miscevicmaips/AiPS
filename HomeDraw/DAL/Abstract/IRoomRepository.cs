using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRoomRepository
    {
        void Create(Room room);

        void Delete(int roomId);

        Room GetRoomById(int roomId);

        IEnumerable<Room> GetAllRooms();
    }
}
