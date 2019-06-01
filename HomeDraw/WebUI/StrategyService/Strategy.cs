using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.StrategyService
{
    public interface Strategy
    {
        void ExportDrawing(string html);
    }
}
