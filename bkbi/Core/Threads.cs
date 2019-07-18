using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace bkbi.Core
{
    public static class Threads
    {
        public static Thread SerialThread;
        public static Thread ViewerPanelThread;
        public static Forms.ViewerPanel.ViewerPanel ViewerPanel;
    }
}
