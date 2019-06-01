using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public ActionResult GetFile(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                byte[] data = TempData[fileGuid] as byte[];

                if (fileName == "HomeDrawExportPDF.pdf")
                {
                    return File(data, "application/pdf", fileName);

                }

                if (fileName == "HomeDrawExportPNG.png")
                {
                    return File(data, "image/png", fileName);
                }

                return new EmptyResult();

            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}