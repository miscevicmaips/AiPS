using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebUI.Hubs
{
    public class SignalRHub : Hub
    {
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

        public void DrawElement(string elementType)
        {
            int elementId = 0;

            Clients.All.drawElementCallback(elementType, elementId);
        }
    }
}