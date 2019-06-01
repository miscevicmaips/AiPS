using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using TheArtOfDev.HtmlRenderer.WinForms;
using NReco.ImageGenerator;
using System.IO;

namespace WebUI.StrategyService
{
    public class ConcreteStrategyPNG : Strategy
    {
        public Byte[] ExportDrawing(string html)
        {
            var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
            var jpegBytes = htmlToImageConv.GenerateImage(html, ImageFormat.Png);

            return jpegBytes;
        }
    }
}