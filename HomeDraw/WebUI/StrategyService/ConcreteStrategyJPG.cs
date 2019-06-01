using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.StrategyService
{
    public class ConcreteStrategyJPG : Strategy
    {
        public void ExportDrawing(string html)
        {
            Console.WriteLine("Called ConcreteStrategyJPG");
        }
    }
}