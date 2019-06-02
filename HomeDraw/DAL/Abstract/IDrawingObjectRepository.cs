using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace DAL.Abstract
{
    public interface IDrawingObjectRepository
    {
        int CreateDrawingObject(DrawingObjectDTO drawingObject);
        DrawingObjectDTO ReadDrawingObject(int drawingObjectId);
        void UpdateDrawingObject(DrawingObjectDTO drawingObject);
        void DeleteDrawingObject(int drawingObjectId);

        IEnumerable<DrawingObjectDTO> GetAllDrawingObjects();
    }
}
