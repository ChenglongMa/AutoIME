using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using AutoIME.Properties;
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
            Editor.WriteMessage("================<<安装开始>>================\n");
            Register();
            Setup.BindCommandToDoc(AcadApplication.DocumentManager.MdiActiveDocument);
            Editor.WriteMessage("================<<安装完成>>================\n");
        }

        [CommandMethod("uAutoIME")]
        [CommandMethod("rhfa")]
        [CommandMethod("xzAutoIME")]
        public static void Uninstall()
        {
            Editor.WriteMessage("================<<卸载开始>>================\n");
            UnregisterApp();
            Setup.UnbindCommandToDoc(AcadApplication.DocumentManager.MdiActiveDocument);
            Editor.WriteMessage("================<<卸载完成>>================\n");
        }


        [CommandMethod("RegisterAutoIME")]
        public static void Register()
        {
            Editor.WriteMessage("================<<注册开始>>================\n");
            try
            {
                Setup.Register(AppName);
            }
            catch
            {
                Editor.WriteMessage("================<<注册失败>>================\n");
            }
            Editor.WriteMessage("================<<注册成功>>================\n");
        }

        [CommandMethod("UnregisterAutoIME")]
        public static void UnregisterApp()
        {
            Editor.WriteMessage("================<<注销开始>>================\n");
            try
            {
                Setup.Unregister(AppName);
            }
            catch
            {
                Editor.WriteMessage("================<<注销失败>>================\n");
            }
            Editor.WriteMessage("================<<注销成功>>================\n");
        }

        [CommandMethod("SetIME")]
        public static void Config()
        {
            try
            {
                if (new ConfigForm().ShowDialog() == DialogResult.OK)
                {
                    Editor.WriteMessage("================<<设置完成>>================\n");
                }
                else
                {
                    Editor.WriteMessage("================<<设置取消>>================\n");
                }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception e)
            {
                Editor.WriteMessage("CAD Runtime error: \n");
                Editor.WriteMessage(e.Message);
            }
            catch (System.Exception e)
            {
                Editor.WriteMessage(e.Message);
            }
        }

    }
}
