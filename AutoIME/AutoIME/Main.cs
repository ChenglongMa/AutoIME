using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcadApplication = Autodesk.AutoCAD.ApplicationServices.Application;


namespace AutoIME
{
    public class Main
    {
        public const string AppName = "AutoIME";
        public static readonly Editor Editor = AcadApplication.DocumentManager.MdiActiveDocument.Editor;

        [CommandMethod("iAutoIME")]
        [CommandMethod("pvuf")]
        [CommandMethod("azAutoIME")]
        public static void Install()
        {
            Editor.WriteMessage("================<<安装开始>>================");
            Register();
            Editor.WriteMessage("================<<安装完成>>================");
        }

        [CommandMethod("uAutoIME")]
        [CommandMethod("rhfa")]
        [CommandMethod("xzAutoIME")]
        public static void Uninstall()
        {
            Editor.WriteMessage("================<<卸载开始>>================");
            UnregisterApp();
            Editor.WriteMessage("================<<卸载完成>>================");
        }


        [CommandMethod("RegisterAutoIME")]
        public static void Register()
        {
            Editor.WriteMessage("================<<注册开始>>================");
            try
            {
                Setup.Register(AppName);
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
            Editor.WriteMessage("================<<注销开始>>================");
            try
            {
                Setup.Unregister(AppName);
            }
            catch
            {
                Editor.WriteMessage("================<<注销失败>>================");
            }
            Editor.WriteMessage("================<<注销成功>>================");
        }

        [CommandMethod("SetIME")]
        public static void Config()
        {
            new ConfigForm().ShowDialog();
        }

    }
}
