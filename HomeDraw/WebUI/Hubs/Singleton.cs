using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Hubs
{
    public class Singleton
    {
        private static Singleton _instance;

        public Dictionary<int, Queue<string>> ListOfDrawings;

        private static object syncLock = new object();

        protected Singleton()
        {

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