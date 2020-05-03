using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AcadDocument = Autodesk.AutoCAD.ApplicationServices.Document;
using AcadWindows = Autodesk.AutoCAD.Windows;

namespace AutoIME
{
    class Setup
    {
        private readonly Config _config = Config.GetConfigInstance();
        private RegistryKey GetRootKey()
        {
            // Get Registry key
            var rootKey = HostApplicationServices.Current.MachineRegistryProductRootKey;
            var regAcadProdKey = Registry.CurrentUser.OpenSubKey(rootKey);
            return regAcadProdKey.OpenSubKey("Applications", true);
        }

        public void Register(string appName)
        {
            // Get Registry key

            var regAcadAppKey = GetRootKey();

            // Check if `appName` exists
            var subKeys = regAcadAppKey.GetSubKeyNames();
            if (subKeys.Contains(appName))
            {
                regAcadAppKey.DeleteSubKeyTree(appName);
            }

            // Get dll location
            var sAssemblyPath = Assembly.GetExecutingAssembly().Location;
            // Register key
            var regAppAddInKey = regAcadAppKey.CreateSubKey(appName);
            regAppAddInKey.SetValue("DESCRIPTION", appName, Microsoft.Win32.RegistryValueKind.String);
            regAppAddInKey.SetValue("LOADCTRLS", 14, Microsoft.Win32.RegistryValueKind.DWord);
            regAppAddInKey.SetValue("LOADER", sAssemblyPath, Microsoft.Win32.RegistryValueKind.String);
            regAppAddInKey.SetValue("MANAGED", 1, Microsoft.Win32.RegistryValueKind.DWord);
            regAcadAppKey.Close();
        }

        public void Unregister(string appName)
        {
            var regAcadProdKey = GetRootKey();
            var regAcadAppKey = regAcadProdKey.OpenSubKey("Applications", true);
            regAcadAppKey.DeleteSubKeyTree(appName);
            regAcadAppKey.Close();
        }

        public void BindCommandToDoc(AcadDocument doc)
        {
            doc.CommandWillStart += new CommandEventHandler(CommandWillStart);
            doc.CommandEnded += new CommandEventHandler(CommandEnded);
            doc.CommandCancelled += new CommandEventHandler(CommandCancelled);
            doc.CommandFailed += new CommandEventHandler(CommandFailed);
        }

        private void CommandFailed(object sender, CommandEventArgs e)
        {
            _config.Switch2CommandIME();
        }

        private void CommandCancelled(object sender, CommandEventArgs e)
        {
            _config.Switch2CommandIME();
        }

        private void CommandEnded(object sender, CommandEventArgs e)
        {
            _config.Switch2CommandIME();
        }

        private void CommandWillStart(object sender, CommandEventArgs e)
        {
            var cmdName = e.GlobalCommandName;
            _config.Switch2IME(cmdName);
        }
    }
}
