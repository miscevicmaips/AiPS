using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTO;

namespace DAL.Abstract
{
    public interface IDrawingRepository
    {
        int CreateDrawing(DrawingDTO drawingDTO);
        DrawingDTO ReadDrawing(int drawingId);
        DrawingDTO ReadDrawingByName(string drawingName);
        void UpdateDrawing(DrawingDTO drawingDTO);
        void DeleteDrawing(int drawingId);

        Dictionary<int, Queue<string>> CreateRooms();

        IEnumerable<DrawingDTO> GetAllDrawings();
    }
}
