using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Abstract;
using Domain.Entities;
using Domain.DTO;

namespace DAL.Concrete
{
    public class DrawingObjectRepository : IDrawingObjectRepository
    {
        public int CreateDrawingObject(DrawingObjectDTO drawingObjectDTO)
        {
            using (var context = new HomeDrawDbContext())
            {
                int returnedId = 0;

                try
                {
                    DrawingObject newDrawingObject = new DrawingObject()
                    {
                        DrawingID = drawingObjectDTO.DrawingID,
                        DrawingObjectType = drawingObjectDTO.DrawingObjectType,
                        PositionLeft = drawingObjectDTO.PositionLeft,
                        PositionTop = drawingObjectDTO.PositionTop
                    };

                    context.DrawingObjects.Add(newDrawingObject);

                    context.SaveChanges();

                    returnedId = newDrawingObject.DrawingObjectID;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return returnedId;
               
            }
        }

        public DrawingObjectDTO ReadDrawingObject(int drawingObjectId)
        {
            using (var context = new HomeDrawDbContext())
            {
                DrawingObjectDTO drawingObjectDTO = null;

                try
                {
                    var foundDrawingObject = context.DrawingObjects.Find(drawingObjectId);

                    drawingObjectDTO = new DrawingObjectDTO()
                    {
                        DrawingID = foundDrawingObject.DrawingID,
                        DrawingObjectID = foundDrawingObject.DrawingObjectID,
                        DrawingObjectType = foundDrawingObject.DrawingObjectType,
                        PositionLeft = foundDrawingObject.PositionLeft,
                        PositionTop = foundDrawingObject.PositionTop
                    };
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return drawingObjectDTO;
            }
        }

        public void UpdateDrawingObject(DrawingObjectDTO drawingObjectDTO)
        {
            using (var context = new HomeDrawDbContext())
            {
                try
                {
                    var foundDrawingObject = context.DrawingObjects.Where(d => d.DrawingObjectID == drawingObjectDTO.DrawingObjectID).FirstOrDefault();

                    foundDrawingObject.DrawingID = drawingObjectDTO.DrawingID;
                    foundDrawingObject.DrawingObjectID = drawingObjectDTO.DrawingObjectID;
                    foundDrawingObject.DrawingObjectType = drawingObjectDTO.DrawingObjectType;
                    foundDrawingObject.PositionLeft = drawingObjectDTO.PositionLeft;
                    foundDrawingObject.PositionTop = drawingObjectDTO.PositionTop;

                    context.SaveChanges();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void DeleteDrawingObject(int drawingObjectId)
        {
            using (var context = new HomeDrawDbContext())
            {
                var drawingObjectToDelete = context.DrawingObjects.Find(drawingObjectId);

                context.DrawingObjects.Remove(drawingObjectToDelete);

                context.SaveChanges();
            }
        }

        public IEnumerable<DrawingObjectDTO> GetAllDrawingObjects()
        {
            using (var context = new HomeDrawDbContext())
            {
                List<DrawingObjectDTO> foundDrawingObjectsDTO = new List<DrawingObjectDTO>();

                try
                {
                    var foundDrawingObjects = context.DrawingObjects.ToList();

                    foreach(var drawingObject in foundDrawingObjects)
                    {
                        DrawingObjectDTO newDrawingObjectDTO = null;

                        newDrawingObjectDTO = new DrawingObjectDTO()
                        {
                            DrawingID = drawingObject.DrawingID,
                            DrawingObjectID = drawingObject.DrawingObjectID,
                            DrawingObjectType = drawingObject.DrawingObjectType,
                            PositionLeft = drawingObject.PositionLeft,
                            PositionTop = drawingObject.PositionTop
                        };

                        foundDrawingObjectsDTO.Add(newDrawingObjectDTO);
                    }
                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return foundDrawingObjectsDTO;
            }
        }
        
    }
}
