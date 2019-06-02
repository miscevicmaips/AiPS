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
    public class DrawingRepository : IDrawingRepository
    {
        public int CreateDrawing(DrawingDTO drawingDTO)
        {
            using (var context = new HomeDrawDbContext())
            {
                int returnedId = 0;

                try
                {
                    Drawing drawing = new Drawing()
                    {
                        DrawingID = drawingDTO.DrawingID,
                        Name = drawingDTO.Name,
                        Password = drawingDTO.Password,
                        MasterID = drawingDTO.MasterID
                    };

                    context.Drawings.Add(drawing);

                    context.SaveChanges();

                    returnedId = drawing.DrawingID;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return returnedId;
            }
        }

        public DrawingDTO ReadDrawing(int drawingId)
        {
            using (var context = new HomeDrawDbContext())
            {
                DrawingDTO drawingDto = null;

                try
                {
                    var foundDrawing = context.Drawings.Where(d => d.DrawingID == drawingId).Include(dro => dro.DrawingObjects).FirstOrDefault();

                    drawingDto = new DrawingDTO()
                    {
                        DrawingID = foundDrawing.DrawingID,
                        Name = foundDrawing.Name,
                        Password = foundDrawing.Password,
                        MasterID = foundDrawing.MasterID,
                    };

                    drawingDto.DrawingObjects = new List<DrawingObjectDTO>();

                    foreach (var drawingObject in foundDrawing.DrawingObjects)
                    {
                        DrawingObjectDTO drawingObjectDTO = null;

                        drawingObjectDTO = new DrawingObjectDTO()
                        {
                            DrawingID = drawingObject.DrawingID,
                            DrawingObjectID = drawingObject.DrawingObjectID,
                            DrawingObjectType = drawingObject.DrawingObjectType,
                            PositionLeft = drawingObject.PositionLeft,
                            PositionTop = drawingObject.PositionTop
                        };

                        drawingDto.DrawingObjects.Add(drawingObjectDTO);
                    }

                } 
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return drawingDto;
            }
        }

        public DrawingDTO ReadDrawingByName(string drawingName)
        {
            using (var context = new HomeDrawDbContext())
            {
                DrawingDTO drawingDto = null;

                try
                {
                    var foundDrawing = context.Drawings.Where(d => d.Name == drawingName).Include(dro => dro.DrawingObjects).FirstOrDefault();

                    drawingDto = new DrawingDTO()
                    {
                        DrawingID = foundDrawing.DrawingID,
                        Name = foundDrawing.Name,
                        Password = foundDrawing.Password,
                        MasterID = foundDrawing.MasterID,
                    };

                    drawingDto.DrawingObjects = new List<DrawingObjectDTO>();

                    foreach (var drawingObject in foundDrawing.DrawingObjects)
                    {
                        DrawingObjectDTO drawingObjectDTO = null;

                        drawingObjectDTO = new DrawingObjectDTO()
                        {
                            DrawingID = drawingObject.DrawingID,
                            DrawingObjectID = drawingObject.DrawingObjectID,
                            DrawingObjectType = drawingObject.DrawingObjectType,
                            PositionLeft = drawingObject.PositionLeft,
                            PositionTop = drawingObject.PositionTop
                        };

                        drawingDto.DrawingObjects.Add(drawingObjectDTO);
                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return drawingDto;

            }
        }

        public void UpdateDrawing(DrawingDTO drawingDTO)
        {
            using (var context = new HomeDrawDbContext())
            {
                try
                {
                    var foundDrawing = context.Drawings.Where(d => d.DrawingID == drawingDTO.DrawingID).Include(dro => dro.DrawingObjects).FirstOrDefault();

                    foundDrawing.Name = drawingDTO.Name;
                    foundDrawing.Password = drawingDTO.Password;
                    foundDrawing.MasterID = drawingDTO.MasterID;

                    foundDrawing.DrawingObjects.Clear();

                    foreach(DrawingObjectDTO drawingObjectDTO in drawingDTO.DrawingObjects)
                    {
                        var existingDrawingObject = context.DrawingObjects.SingleOrDefault(dro => dro.DrawingObjectID == drawingObjectDTO.DrawingObjectID) ?? context.DrawingObjects.Add(new DrawingObject
                        {
                            DrawingID = drawingObjectDTO.DrawingID,
                            DrawingObjectType = drawingObjectDTO.DrawingObjectType,
                            DrawingObjectID = drawingObjectDTO.DrawingObjectID,
                            PositionLeft = drawingObjectDTO.PositionLeft,
                            PositionTop = drawingObjectDTO.PositionTop
                        });

                        foundDrawing.DrawingObjects.Add(existingDrawingObject);
                    }

                    context.SaveChanges();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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

                foreach (Drawing drawing in drawings)
                {
                    Queue<string> queue = new Queue<string>();

                    queue.Enqueue(drawing.MasterID);

                    //foreach (AppUser user in drawing.JoinedUsers)
                    //{
                    //    queue.Enqueue(user.Id);
                    //}

                    Rooms.Add(drawing.DrawingID, queue);
                }
            }

            return Rooms;
        }

        public IEnumerable<DrawingDTO> GetAllDrawings()
        {
            using (var context = new HomeDrawDbContext())
            {
                List<DrawingDTO> foundDrawingsDTO = new List<DrawingDTO>();

                try
                {

                    List<Drawing> foundDrawings = context.Drawings.Include(dr => dr.DrawingObjects).ToList();

                    foreach (var drawing in foundDrawings)
                    {
                        DrawingDTO newDrawingDTO = null;

                        newDrawingDTO = new DrawingDTO()
                        {
                            DrawingID = drawing.DrawingID,
                            Name = drawing.Name,
                            Password = drawing.Password,
                            MasterID = drawing.MasterID,
                        };

                        foreach (var drawingObject in drawing.DrawingObjects)
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

                            newDrawingDTO.DrawingObjects.Add(newDrawingObjectDTO);
                        }

                        foundDrawingsDTO.Add(newDrawingDTO);
                    }

                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return foundDrawingsDTO;
            }
        }
    }
}
