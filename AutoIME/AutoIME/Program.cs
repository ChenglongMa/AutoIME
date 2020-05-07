using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AcadApplication = Autodesk.AutoCAD.ApplicationServices.Application;


namespace AutoIME
{
    public class Program : IExtensionApplication
    {
        //delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        //[DllImport("user32.dll")]
        //static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        //private const uint WINEVENT_OUTOFCONTEXT = 0;
        //private const uint EVENT_SYSTEM_FOREGROUND = 3;
        //[DllImport("user32.dll")]
        //static extern IntPtr GetForegroundWindow();

        //[DllImport("user32.dll")]
        //static extern IntPtr GetActiveWindow();

        //[DllImport("user32.dll")]
        //static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        //[DllImport("user32.dll", SetLastError = true)]
        //static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //[DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        //public static extern IntPtr GetParent(IntPtr hWnd);

        //static WinEventDelegate dele = null;


        public const string AppName = "AutoIME";
        public static Editor Editor => AcadApplication.DocumentManager.MdiActiveDocument.Editor;
        private readonly Config _config = Config.GetConfigInstance();

        [CommandMethod("iAutoIME")]
        [CommandMethod("pvuf")]
        [CommandMethod("azAutoIME")]
        public static void Install()
        {
            Editor.WriteMessage("================<<安装开始>>================\n");
            Register();
            Setup.InitialBinding();
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

        internal static void TearDown()
        {
            Config.GetConfigInstance().Switch2DefaultIME();
            //dele = null;
        }

        [CommandMethod("SetIME")]
        public static void SetIME()
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
                // TODO
            }
            catch (System.Exception e)
            {
                Editor.WriteMessage(e.Message);
            }
        }

        public void Initialize()
        {
            //dele = new WinEventDelegate(WinEventProc);
            //IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
            _config.Initialize();
            _config.Switch2CommandIME();
            Setup.InitialBinding();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;
            

            Editor.WriteMessage("================<<AutoIME 初始化完成>>================\n");
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            System.Exception e = (System.Exception)args.ExceptionObject;
            System.IO.File.AppendAllText(@"autoimeerror.txt", e.Message);
            System.IO.File.AppendAllText(@"autoimeerror.txt", e.StackTrace);
            System.IO.File.AppendAllText(@"autoimeerror.txt", "\n");
        }

        //private string GetActiveWindowTitle()
        //{
        //    const int nChars = 256;
        //    IntPtr handle = IntPtr.Zero;
        //    StringBuilder Buff = new StringBuilder(nChars);
        //    handle = GetForegroundWindow();
        //    if (GetWindowText(handle, Buff, nChars) > 0)
        //    {
        //        return Buff.ToString();
        //    }
        //    return null;
        //}

        //private void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        //{
        //    var threadID = GetWindowThreadProcessId(GetForegroundWindow(), out uint processID);
        //    var title = GetActiveWindowTitle();
        //    var lines = $"PID: {processID} TID: {threadID} Title:  {title}\n";

        //    System.IO.File.AppendAllText(@"gettitle.txt", lines);
        //}

        public void Terminate()
        {
            TearDown();

        }
    }
}
