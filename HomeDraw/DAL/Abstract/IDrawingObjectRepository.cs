using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IDrawingObjectRepository
    {
        void CreateDrawingObject(DrawingObject drawingObject);
        DrawingObject ReadDrawingObject(int drawingObjectId);
        void UpdateDrawingObject(DrawingObject drawingObject);
        void DeleteDrawingObject(int drawingObjectId);

        IEnumerable<DrawingObject> GetAllDrawingObjects();
    }
}
