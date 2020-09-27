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

using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitGraphicsOverride
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            Dictionary<string, List<OverridenResult>> resultsOnSheets = new Dictionary<string, List<OverridenResult>>();

            Form1 form1 = new Form1();
            form1.ShowDialog();
            if (form1.DialogResult != System.Windows.Forms.DialogResult.OK) return Result.Cancelled;

            if(form1.searchAllProject == false)
            {
                View curView = uidoc.ActiveView;

                string title = curView.Name;
                string sheetNumber = curView.get_Parameter(BuiltInParameter.VIEWER_SHEET_NUMBER).AsString();
                if (sheetNumber != "---")
                {
                    string sheetName = curView.get_Parameter(BuiltInParameter.VIEWPORT_SHEET_NAME).AsString();
                    title = "Лист: " + sheetNumber + " - " + sheetName + "; " + curView.Name;
                }

                List< OverridenResult> overridenElems = SupportGraphics.getOverridenElemsOnView(doc, curView);
                resultsOnSheets.Add(title, overridenElems);
            }
            else
            {

                List<ViewSheet> sheets = new FilteredElementCollector(doc)
                    .OfClass(typeof(ViewSheet))
                    .Cast<ViewSheet>()
                    .OrderBy(i => i.SheetNumber)
                    .ToList();

                foreach(ViewSheet sheet in sheets)
                {
                    List<View> viewsOnSheet = sheet.GetAllPlacedViews().Select(i => doc.GetElement(i) as View).ToList();

                    foreach(View curView in viewsOnSheet)
                    {
                        List<OverridenResult> overridenElemsCurSheet = SupportGraphics.getOverridenElemsOnView(doc, curView);
                        if (overridenElemsCurSheet.Count == 0) continue;
                        string title = sheet.Title + "; " + curView.Name;
                        resultsOnSheets.Add(title, overridenElemsCurSheet); 
                    }
                }
            }

            if(resultsOnSheets.Count == 0)
            {
                TaskDialog.Show("Отчет", "Элементы с переопределением графики не обнаружены!");
                return Result.Cancelled;
            }

            if(form1.selectElems)
            {
                List<ElementId> ids = new List<ElementId>();
                foreach(var kvp in resultsOnSheets)
                {
                    List<OverridenResult> ress = kvp.Value;
                    List<ElementId> curIds = ress.Select(i => i.Elem.Id).ToList();
                    ids.AddRange(curIds);
                }
                    
                uidoc.Selection.SetElementIds(ids);
            }

            if(form1.showResults)
            {
                Form2 form2 = new Form2(resultsOnSheets);
                form2.ShowDialog();

                if(form2.DialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    ElementId idToSelect = new ElementId(form2.idToSelect);
                    View overrideView = doc.GetElement(new ElementId(form2.idViewToOpen)) as View;
                    uidoc.ActiveView = overrideView;
                    uidoc.Selection.SetElementIds(new List<ElementId> { idToSelect });
                }
            }

            return Result.Succeeded;
        }
    }
}
