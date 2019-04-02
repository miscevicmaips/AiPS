using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Abstract;
using Domain.Entities;
using Microsoft.AspNet.SignalR;

namespace WebUI.Hubs
{
    public class SignalRHub : Hub
    {
        private IDrawingObjectRepository drawingObjectRepository;

        public SignalRHub(IDrawingObjectRepository drawingObjectRepo)
        {
            drawingObjectRepository = drawingObjectRepo;
        }

        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        public void DrawCircle()
        {
            Clients.All.drawCircleCallback();
        }

        public void DrawRectangle()
        {
            Clients.All.drawRectangleCallback();
        }

        public void MoveCircleElement(int x, int y)
        {
            Clients.Others.moveCircleElementCallback(x, y);
        }

        public void MoveRectangleElement(int x, int y)
        {
            Clients.Others.moveRectangleElementCallback(x, y);
        }

        /* ================================================================== */
        public void MoveElement(int x, int y, string elementId)
        {
            Clients.Others.moveElementCallback(x, y,elementId);
        }

        public void DrawElement(string elementType, int containedDrawingId)
        {
            int? elementId = null;

            if(elementType == "bathElement")
            {
                DrawingObject newBathElement = new DrawingObject();
                newBathElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Bath;
                newBathElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newBathElement);

                elementId = newBathElement.DrawingObjectID;
            }

            if (elementType == "lavatoryElement")
            {
                DrawingObject newLavatoryElement = new DrawingObject();
                newLavatoryElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Lavatory;
                newLavatoryElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newLavatoryElement);

                elementId = newLavatoryElement.DrawingObjectID;
            }

            if (elementType == "showerElement")
            {
                DrawingObject newShowerElement = new DrawingObject();
                newShowerElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Shower;
                newShowerElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newShowerElement);

                elementId = newShowerElement.DrawingObjectID;
            }

            if (elementType == "doorElement")
            {
                DrawingObject newDoorElement = new DrawingObject();
                newDoorElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Door;
                newDoorElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newDoorElement);

                elementId = newDoorElement.DrawingObjectID;
            }

            if (elementType == "wallElement")
            {
                DrawingObject newWallElement = new DrawingObject();
                newWallElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Wall;
                newWallElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newWallElement);

                elementId = newWallElement.DrawingObjectID;
            }

            if (elementType == "windowElement")
            {
                DrawingObject newWindowElement = new DrawingObject();
                newWindowElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Window;
                newWindowElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newWindowElement);

                elementId = newWindowElement.DrawingObjectID;
            }

            if (elementType == "refrigeratorElement")
            {
                DrawingObject newRefrigeratorElement = new DrawingObject();
                newRefrigeratorElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Refrigerator;
                newRefrigeratorElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newRefrigeratorElement);

                elementId = newRefrigeratorElement.DrawingObjectID;
            }

            if (elementType == "sinkElement")
            {
                DrawingObject newSinkElement = new DrawingObject();
                newSinkElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Sink;
                newSinkElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newSinkElement);

                elementId = newSinkElement.DrawingObjectID;
            }

            if (elementType == "stoveElement")
            {
                DrawingObject newStoveElement = new DrawingObject();
                newStoveElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Stove;
                newStoveElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newStoveElement);

                elementId = newStoveElement.DrawingObjectID;
            }

            if (elementType == "sofaElement")
            {
                DrawingObject newSofaElement = new DrawingObject();
                newSofaElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Sofa;
                newSofaElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newSofaElement);

                elementId = newSofaElement.DrawingObjectID;
            }


            if (elementType == "tableElement")
            {
                DrawingObject newTableElement = new DrawingObject();
                newTableElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Table;
                newTableElement.DrawingID = containedDrawingId;
                drawingObjectRepository.CreateObject(newTableElement);

                elementId = newTableElement.DrawingObjectID;
            }

            Clients.All.drawElementCallback(elementType, elementId);
        }
    }
}