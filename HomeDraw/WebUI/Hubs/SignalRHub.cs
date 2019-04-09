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
        private IDrawingRepository drawingRepository;

        public SignalRHub(IDrawingObjectRepository drawingObjectRepo, IDrawingRepository drawingRepo)
        {
            drawingObjectRepository = drawingObjectRepo;
            drawingRepository = drawingRepo;
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
            Clients.Others.moveElementCallback(x, y, elementId);
        }

        public void DrawElement(string elementType, int containedDrawingId)
        {
            int? elementId = null;

            Drawing drawing = drawingRepository.ReadDrawing(containedDrawingId);

            if (elementType == "bathElement")
            {
                DrawingObject newBathElement = new DrawingObject();
                newBathElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Bath;
                newBathElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newBathElement);

                drawing.DrawingObjects.Add(newBathElement);

                elementId = newBathElement.DrawingObjectID;
            }

            if (elementType == "lavatoryElement")
            {
                DrawingObject newLavatoryElement = new DrawingObject();
                newLavatoryElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Lavatory;
                newLavatoryElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newLavatoryElement);

                drawing.DrawingObjects.Add(newLavatoryElement);

                elementId = newLavatoryElement.DrawingObjectID;
            }

            if (elementType == "showerElement")
            {
                DrawingObject newShowerElement = new DrawingObject();
                newShowerElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Shower;
                newShowerElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newShowerElement);

                drawing.DrawingObjects.Add(newShowerElement);

                elementId = newShowerElement.DrawingObjectID;
            }

            if (elementType == "doorElement")
            {
                DrawingObject newDoorElement = new DrawingObject();
                newDoorElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Door;
                newDoorElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newDoorElement);

                drawing.DrawingObjects.Add(newDoorElement);

                elementId = newDoorElement.DrawingObjectID;
            }

            if (elementType == "wallElement")
            {
                DrawingObject newWallElement = new DrawingObject();
                newWallElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Wall;
                newWallElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newWallElement);

                drawing.DrawingObjects.Add(newWallElement);

                elementId = newWallElement.DrawingObjectID;
            }

            if (elementType == "windowElement")
            {
                DrawingObject newWindowElement = new DrawingObject();
                newWindowElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Window;
                newWindowElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newWindowElement);

                drawing.DrawingObjects.Add(newWindowElement);

                elementId = newWindowElement.DrawingObjectID;
            }

            if (elementType == "refrigeratorElement")
            {
                DrawingObject newRefrigeratorElement = new DrawingObject();
                newRefrigeratorElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Refrigerator;
                newRefrigeratorElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newRefrigeratorElement);

                drawing.DrawingObjects.Add(newRefrigeratorElement);

                elementId = newRefrigeratorElement.DrawingObjectID;
            }

            if (elementType == "sinkElement")
            {
                DrawingObject newSinkElement = new DrawingObject();
                newSinkElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Sink;
                newSinkElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newSinkElement);

                drawing.DrawingObjects.Add(newSinkElement);

                elementId = newSinkElement.DrawingObjectID;
            }

            if (elementType == "stoveElement")
            {
                DrawingObject newStoveElement = new DrawingObject();
                newStoveElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Stove;
                newStoveElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newStoveElement);

                drawing.DrawingObjects.Add(newStoveElement);

                elementId = newStoveElement.DrawingObjectID;
            }

            if (elementType == "sofaElement")
            {
                DrawingObject newSofaElement = new DrawingObject();
                newSofaElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Sofa;
                newSofaElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newSofaElement);

                drawing.DrawingObjects.Add(newSofaElement);

                elementId = newSofaElement.DrawingObjectID;
            }


            if (elementType == "tableElement")
            {
                DrawingObject newTableElement = new DrawingObject();
                newTableElement.DrawingObjectType = Domain.Enums.DrawingObjectTypeEnum.Table;
                newTableElement.DrawingID = drawing.DrawingID;
                drawingObjectRepository.CreateDrawingObject(newTableElement);

                drawing.DrawingObjects.Add(newTableElement);

                elementId = newTableElement.DrawingObjectID;
            }

            drawingRepository.UpdateDrawing(drawing);

            Clients.All.drawElementCallback(elementType, elementId);
        }
    }
}