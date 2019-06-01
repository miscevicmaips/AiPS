using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using PdfSharp;
using SelectPdf;

namespace WebUI.StrategyService
{
    public class ConcreteStrategyPDF : Strategy
    {
        public Byte[] ExportDrawing(string html)
        {
            Byte[] res = null;

            string htmlString = html;

            PdfPageSize pageSize = PdfPageSize.A4;

            PdfPageOrientation pdfOrientation = PdfPageOrientation.Landscape;

            HtmlToPdf converter = new HtmlToPdf();

            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;

            PdfDocument doc = converter.ConvertHtmlString(htmlString);

            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);

                res = ms.ToArray();

                doc.Close();
            }

            return res;

        }
    }
}