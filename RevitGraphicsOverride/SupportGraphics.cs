#region License
/*Данный код опубликован под лицензией Creative Commons Attribution-ShareAlike.
Разрешено использовать, распространять, изменять и брать данный код за основу для производных в коммерческих и
некоммерческих целях, при условии указания авторства и если производные лицензируются на тех же условиях.
Код поставляется "как есть". Автор не несет ответственности за возможные последствия использования.
Зуев Александр, 2020, все права защищены.
This code is listed under the Creative Commons Attribution-ShareAlike license.
You may use, redistribute, remix, tweak, and build upon this work non-commercially and commercially,
as long as you credit the author by linking back and license your new creations under the same terms.
This code is provided 'as is'. Author disclaims any implied warranty.
Zuev Aleksandr, 2020, all rigths reserved.*/
#endregion

using System.Diagnostics;
using System.Collections.Generic;
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
                message += "Полутона. ";

            if (ogs.ProjectionLineWeight != -1)
                message += "Толщина линии проекции. ";

            if (ogs.ProjectionLineColor.IsValid)
                message += "Цвет линии проекции. ";

            if (ogs.ProjectionLinePatternId.IntegerValue != invalidId)
                message += "Тип линии проекции. ";

#if R2017 || R2018
            if (ogs.IsProjectionFillPatternVisible == false)
                message += "Отключена штриховка поверхности. ";
            
            if (ogs.ProjectionFillColor.IsValid)
                message += "Цвет штриховки поверхности. ";

            if (ogs.ProjectionFillPatternId.IntegerValue != invalidId)
                message += "Штриховка поверхности. ";

            if (ogs.IsCutFillPatternVisible == false)
                message += "Отключена штриховка разреза. ";

            if (ogs.CutFillColor.IsValid)
                message += "Цвет штриховки разреза. ";

            if (ogs.CutFillPatternId.IntegerValue != invalidId)
                message += "Образец штриховки разреза. ";

#else
            if (ogs.IsSurfaceForegroundPatternVisible == false)
                message += "Отключена штриховка передней поверхности. ";
            if (ogs.IsSurfaceBackgroundPatternVisible == false)
                message += "Отключена штриховка задней поверхности. ";
 
            if(ogs.SurfaceForegroundPatternColor.IsValid)
                message += "Цвет штриховки передней поверхности. ";
            if (ogs.SurfaceBackgroundPatternColor.IsValid)
                message += "Цвет штриховки задней поверхности. ";

            if(ogs.SurfaceForegroundPatternId.IntegerValue != invalidId)
                message += "Штриховка передней поверхности. ";
            if (ogs.SurfaceBackgroundPatternId.IntegerValue != invalidId)
                message += "Штриховка задней поверхности. ";

            if (ogs.IsCutForegroundPatternVisible == false)
                message += "Отключена передняя штриховка разреза. ";
            if (ogs.IsCutBackgroundPatternVisible == false)
                message += "Отключена задняя штриховка разреза. ";

            if (ogs.CutForegroundPatternColor.IsValid)
                message += "Цвет передней штриховки разреза. ";
            if (ogs.CutBackgroundPatternColor.IsValid)
                message += "Цвет задней штриховки разреза. ";

            if (ogs.CutForegroundPatternId.IntegerValue != invalidId)
                message += "Образец передней штриховки разреза. ";
            if (ogs.CutBackgroundPatternId.IntegerValue != invalidId)
                message += "Образец передней штриховки разреза. ";
#endif

            if (ogs.Transparency != 0)
                message += "Прозрачность. ";


            if (ogs.CutLineWeight != -1)
                message += "Толщина линии разреза. ";

            if (ogs.CutLineColor.IsValid)
                message += "Цвет линии разреза. ";

            if (ogs.CutLinePatternId.IntegerValue != invalidId)
                message += "Тип линии разреза. ";
                        
            return message;
        }


        public static List<OverridenResult> getOverridenElemsOnView(Document doc, View curView)
        {
            List<OverridenResult> overridenElems = new List<OverridenResult>();
            Debug.WriteLine("Find overrides on view: " + curView.Name);

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
                    Debug.WriteLine("Overrides found for elem id: " + elem.Id.IntegerValue);
                }
            }
            Debug.WriteLine("Overriden elems found: " + overridenElems.Count);
            return overridenElems;
        }
    }
}
