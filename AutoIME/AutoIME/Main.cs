using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using AcadApplication = Autodesk.AutoCAD.ApplicationServices.Application;


namespace AutoIME
{
    public class Main
    {
        public static readonly string AppName = Assembly.GetEntryAssembly().GetName().Name;
        public static readonly Editor Editor = AcadApplication.DocumentManager.MdiActiveDocument.Editor;

        private static readonly Setup setup = new Setup();

        [CommandMethod("iAutoIME")]
        [CommandMethod("pvuf")]
        [CommandMethod("anzhuang")]
        public static void Install()
        {
            Editor.WriteMessage("================<<安装开始>>================");
        }


        [CommandMethod("RegisterAutoIME")]
        public static void Register()
        {
            Editor.WriteMessage("================<<注册开始>>================");
            try
            {
                setup.Register(AppName);
            }
            catch
            {
                Editor.WriteMessage("================<<注册失败>>================");
            }
            Editor.WriteMessage("================<<注册成功>>================");
        }

        [CommandMethod("UnregisterAutoIME")]
        public static void UnregisterApp()
        {
            Editor.WriteMessage("================<<卸载开始>>================");
            try
            {
                setup.Unregister(AppName);
            }
            catch
            {
                Editor.WriteMessage("================<<卸载失败>>================");
            }
            Editor.WriteMessage("================<<卸载成功>>================");
        }

    }
}
