using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace RevitGraphicsOverride
{
    public class OverridenResult
    {
        public Element elem { get; }
        public View parentView { get; }
        public OverrideGraphicSettings overrides { get; }
        public string description { get; }

        public OverridenResult(Element Elem, View ParentView, OverrideGraphicSettings Overrides, string Description)
        {
            elem = Elem;
            parentView = ParentView;
            overrides = Overrides;
            description = Description;
        }
    }
}
