using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Hubs
{
    public class Singleton
    {
        private static Singleton _instance;
        private IDrawingRepository drawingRepository;

        public Dictionary<int, Queue<string>> ListOfRooms;

        private static object syncLock = new object();

        protected Singleton()
        {
            ListOfRooms = drawingRepository.CreateRooms();
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