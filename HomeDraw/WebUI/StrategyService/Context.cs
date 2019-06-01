using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.StrategyService
{
    public class Context
    {
        private Strategy _strategy;


        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface(string html)
        {
            _strategy.ExportDrawing(html);
        }
    }
}