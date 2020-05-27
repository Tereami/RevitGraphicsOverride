using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace RevitGraphicsOverride
{
    public static class SupportGraphics
    {
        public static string HaveOverrides(OverrideGraphicSettings ogs)
        {
            int invalidId = OverrideGraphicSettings.InvalidPenNumber;
            string message = "";

            if (ogs.Halftone == true)
            {
                message += "Полутона. ";
            }

            if (ogs.ProjectionLineWeight != -1)
            {
                message += "Толщина линии проекции. ";
            }

            if (ogs.ProjectionLineColor.IsValid)
            {
                message += "Цвет линии проекции. ";
            }

            if (ogs.ProjectionLinePatternId.IntegerValue != invalidId)
            {
                message += "Тип линии проекции. ";
            }

            if (ogs.IsProjectionFillPatternVisible == false)
            {
                message += "Отключена штриховка поверхности. ";
            }

            if (ogs.ProjectionFillColor.IsValid)
            {
                message += "Цвет штриховки поверхности. ";
            }

            if (ogs.ProjectionFillPatternId.IntegerValue != invalidId)
            {
                message += "Штриховка поверхности. ";
            }


            if (ogs.Transparency != 0)
            {
                message += "Прозрачность. ";
            }


            if (ogs.CutLineWeight != -1)
            {
                message += "Вес линии разреза. ";
            }

            if (ogs.CutLineColor.IsValid)
            {
                message += "Цвет линии разреза. ";
            }

            if (ogs.CutLinePatternId.IntegerValue != invalidId)
            {
                message += "Тип линии разреза. ";
            }

            if (ogs.IsCutFillPatternVisible == false)
            {
                message += "Отключена штриховка разреза. ";
            }

            if (ogs.CutFillColor.IsValid)
            {
                message += "Цвет штриховки разреза. ";
            }

            if (ogs.CutFillPatternId.IntegerValue != invalidId)
            {
                message += "Образец штриховки разреза. ";
            }

            return message;
        }


        public static List<OverridenResult> getOverridenElemsOnView(Document doc, View curView)
        {
            List<OverridenResult> overridenElems = new List<OverridenResult>();

            FilteredElementCollector col = new FilteredElementCollector(doc, curView.Id);
            foreach (Element elem in col)
            {
                if (elem.Category == null) continue;
                OverrideGraphicSettings ogs = curView.GetElementOverrides(elem.Id);

                string msg = SupportGraphics.HaveOverrides(ogs);

                if (msg != "")
                {
                    OverridenResult ores = new OverridenResult(elem, curView, ogs, msg);
                    overridenElems.Add(ores);
                }
            }

            return overridenElems;
        }
    }
}
