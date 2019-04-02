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
        public void MoveElement(int x, int y)
        {
            Clients.Others.moveElementCallback(x, y);
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

            Clients.All.drawElementCallback(elementType, elementId);
        }
    }
}