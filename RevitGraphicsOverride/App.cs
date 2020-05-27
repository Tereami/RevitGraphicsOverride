using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace RevitGraphicsOverride
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class App : IExternalApplication
    {
        public static string assemblyPath = "";
        public Result OnStartup(UIControlledApplication application)
        {
            assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            
            string tabName = "Weandrevit";
            string panelName = "Графика";
            try { application.CreateRibbonTab(tabName); } catch { }

            RibbonPanel panel = null;
            List<RibbonPanel> tryPanels = application.GetRibbonPanels(tabName).Where(i => i.Name == panelName).ToList();
            if(tryPanels.Count == 0)
            {
                panel = application.CreateRibbonPanel(tabName, panelName);
            }
            else
            {
                panel = tryPanels.First();
            }

            PushButton btn = panel.AddItem(new PushButtonData(
                "OverridesClear",
                "Переопределения",
                assemblyPath,
                "OverridesClear.Command")
                ) as PushButton;

            return Result.Succeeded;
        }

    public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

    }
}
