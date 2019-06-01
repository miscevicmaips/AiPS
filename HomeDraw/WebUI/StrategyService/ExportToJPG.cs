using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebUI.StrategyService
{
    public class ExportToJPG
    {
        public static Byte[] convertToJPG(string html)
        {
            Byte[] res = null;

            using (MemoryStream ms = new MemoryStream())
            {
                //var pdf = 

                ////pdf.Save(ms);

                //res = ms.ToArray();
            }

            return res;

        }
    }
}