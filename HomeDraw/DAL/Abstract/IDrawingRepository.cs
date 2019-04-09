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
        void UpdateDrawing(Drawing drawing);
        void DeleteDrawing(int drawingId);

        IEnumerable<Drawing> GetAllDrawings();
    }
}
