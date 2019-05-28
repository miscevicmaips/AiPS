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
        void CreateDrawing(Drawing drawing);
        Drawing ReadDrawing(int drawingId);
        Drawing ReadDrawingByName(string drawingName);
        void UpdateDrawing(Drawing drawing);
        void DeleteDrawing(int drawingId);

        Dictionary<int, Queue<string>> CreateRooms();

        IEnumerable<Drawing> GetAllDrawings();
    }
}
