using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitGraphicsOverride
{
    public static class Extensions
    {
        public static long GetValue(this ElementId elementId)
        {
            return 0;
        }
    }
}
