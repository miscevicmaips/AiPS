using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DAL.Abstract;
using Domain.Entities;
using Microsoft.AspNet.SignalR;

namespace WebUI.Hubs
{
    public class SignalRHub : Hub
    {
        private IDrawingObjectRepository drawingObjectRepository;
        private IDrawingRepository drawingRepository;

        public SignalRHub(IDrawingObjectRepository drawingObjectRepo, IDrawingRepository drawingRepo)
        {
            drawingObjectRepository = drawingObjectRepo;
            drawingRepository = drawingRepo;
        }

        public void MoveElement(int x, int y, string elementId)
        {
            Clients.Others.moveElementCallback(x, y, elementId);
        }

        public void UpdateElement(int x, int y, int elementId)
        {
            DrawingObject elementToUpdate = drawingObjectRepository.ReadDrawingObject(elementId);

            elementToUpdate.PositionLeft = x;
            elementToUpdate.PositionTop = y;

            drawingObjectRepository.UpdateDrawingObject(elementToUpdate);
        }

        public void DrawElement(string elementType, int containedDrawingId)
        {
            int? elementId = null;

            Drawing drawing = drawingRepository.ReadDrawing(containedDrawingId);

            DrawingObject newElement = new DrawingObject();

            if (elementType == "bathElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Bath;
            }

            if (elementType == "lavatoryElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Lavatory;
            }

            if (elementType == "showerElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Shower;
            }

            if (elementType == "doorElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Door;
            }

            if (elementType == "wallElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Wall;
            }

            if (elementType == "windowElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Window;
            }

            if (elementType == "refrigeratorElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Refrigerator;

            }

            if (elementType == "sinkElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Sink;
            }

            if (elementType == "stoveElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Stove;
            }

            if (elementType == "sofaElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Sofa;
            }


            if (elementType == "tableElement")
            {
                newElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Table;
            }

            newElement.DrawingID = drawing.DrawingID;

            drawingObjectRepository.CreateDrawingObject(newElement);

            drawing.DrawingObjects.Add(newElement);

            elementId = newElement.DrawingObjectID;

            drawingRepository.UpdateDrawing(drawing);

            Clients.Group(containedDrawingId.ToString()).drawElementCallback(elementType, elementId);
        }

        public void EnqueueUser(int drawingId, string userId)
        {
            Singleton rooms = Singleton.GetInstance();

            // If ListOfRooms contains this drawing -> check if queue is empty.
            if (rooms.ListOfRooms.ContainsKey(drawingId))
            {
                // If queue is empty -> set first enqueued user to master
                // If queue is empty -> update drawing master id in database
                if (rooms.ListOfRooms[drawingId].Count == 0)
                {
                    Drawing updateMasterDrawing = drawingRepository.ReadDrawing(drawingId);

                    updateMasterDrawing.MasterID = userId;

                    drawingRepository.UpdateDrawing(updateMasterDrawing);

                    rooms.ListOfRooms[drawingId].Enqueue(userId);
                }
                // If queue is not empty -> add the user to the queue
                else
                {
                    rooms.ListOfRooms[drawingId].Enqueue(userId);

                }

            }
        }

        public void DequeueUser(int drawingId, string userId)
        {
            Singleton rooms = Singleton.GetInstance();

            if(rooms.ListOfRooms.ContainsKey(drawingId))
            {
                if(!rooms.ListOfRooms[drawingId].Contains(userId))
                {
                    string masterId = rooms.ListOfRooms[drawingId].ElementAt(0);

                    // If the current user is also the master -> leave queue
                    if (userId == masterId)
                    {
                        rooms.ListOfRooms[drawingId].Dequeue();

                        if (rooms.ListOfRooms[drawingId].Count != 0)
                        {
                            Drawing drawingToUpdateMaster = drawingRepository.ReadDrawing(drawingId);

                            drawingToUpdateMaster.MasterID = rooms.ListOfRooms[drawingId].ElementAt(0);

                            drawingRepository.UpdateDrawing(drawingToUpdateMaster);
                        }
                        else
                        {
                            Drawing drawingToUpdateMaster = drawingRepository.ReadDrawing(drawingId);

                            drawingToUpdateMaster.MasterID = null;

                            drawingRepository.UpdateDrawing(drawingToUpdateMaster);

                        }

                    }

                    // If the current user is not the master -> delete him from queue
                    if (userId != masterId)
                    {
                        Array temporaryIdArray = Array.CreateInstance(typeof(string), rooms.ListOfRooms[drawingId].Count());

                        temporaryIdArray = rooms.ListOfRooms[drawingId].ToArray();

                        rooms.ListOfRooms[drawingId].Clear();

                        foreach (string id in temporaryIdArray)
                        {
                            if (id != userId)
                            {
                                rooms.ListOfRooms[drawingId].Enqueue(id);
                            }
                        }

                    }
                }

            }
        }

        public void SetInterface()
        {

        }

        public Task Join(string groupName, string userId)
        {
            Singleton rooms = Singleton.GetInstance();

            int drawingId = Int32.Parse(groupName);

            EnqueueUser(drawingId, userId);

            if(rooms.ListOfRooms[drawingId].ElementAt(0) == userId)
            {
                Clients.Caller.setMasterInterface();
            }
            else
            {
                Clients.Caller.setNormalInterface();
            }

            return Groups.Add(Context.ConnectionId, groupName);
        }

        public Task Leave(string groupName, string userId)
        {
            Singleton rooms = Singleton.GetInstance();

            int drawingId = Int32.Parse(groupName);

            DequeueUser(drawingId, userId);

            return Groups.Remove(Context.ConnectionId, groupName);
        }

        //Clients.Caller.amImaster("I AM MASTER!");
        //Clients.Caller.amImaster("I AM NOT A MASTER!");
    }
}