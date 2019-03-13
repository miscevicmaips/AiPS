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

        public void MoveUniversalElement(int x, int y, string id)
        {
            Clients.Others.moveUniversalElementCallback(x, y, id);
        }
    }
}