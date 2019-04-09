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

        public void MoveElement(int x, int y, string elementId)
        {
            Clients.Others.moveElementCallback(x, y, elementId);
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

            Clients.All.drawElementCallback(elementType, elementId);
        }
    }
}