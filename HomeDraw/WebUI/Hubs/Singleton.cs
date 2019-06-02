using DAL.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Hubs
{
    public class Singleton
    {
        private static Singleton _instance;

        public Dictionary<int, Queue<string>> ListOfRooms;

        private static object syncLock = new object();

        protected Singleton()
        {
            Dictionary<int, Queue<string>> Rooms = new Dictionary<int, Queue<string>>();

            using (var context = new HomeDrawDbContext())
            {
                var drawings = (from p in context.Drawings select p);

                foreach (Drawing drawing in drawings)
                {
                    Queue<string> queue = new Queue<string>();

                    if (drawing.MasterID != null)
                    {
                        queue.Enqueue(drawing.MasterID);
                    }

                    //foreach (AppUser user in drawing.JoinedUsers)
                    //{
                    //    queue.Enqueue(user.Id);
                    //}

                    Rooms.Add(drawing.DrawingID, queue);
                }
            }

            ListOfRooms = Rooms;
        }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }

            return _instance;
        }
    }
}