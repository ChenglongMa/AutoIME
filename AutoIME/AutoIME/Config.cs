using AutoIME.Properties;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace AutoIME
{
    public class Config
    {
        /// <summary>
        /// The IME before entering AutoCAD
        /// </summary>
        public InputLanguage DefaultIME { get; set; }
        public InputLanguage TextIME { get; set; }
        public InputLanguage CommandIME { get; set; }
        private static Config config;
        private Config()
        {
            // Do nothing
        }

        public static Config GetConfigInstance()
        {
            if (config == null)
            {
                config = new Config();
            }
            return config;
        }

        public void Initialize()
        {
            DefaultIME = InputLanguage.CurrentInputLanguage;
            var cmdCulture = Settings.Default.CommandIMECulture;
            if (!string.IsNullOrEmpty(cmdCulture))
            {
                CommandIME = InputLanguage.FromCulture(CultureInfo.GetCultureInfo(cmdCulture));
            }
            var txtCulture = Settings.Default.TextIMECulture;
            if (!string.IsNullOrEmpty(txtCulture))
            {
                TextIME = InputLanguage.FromCulture(CultureInfo.GetCultureInfo(txtCulture));
            }

        }

        public void Switch2CommandIME()
        {
            var cmdCulture = Settings.Default.CommandIMECulture;
            if (!string.IsNullOrEmpty(cmdCulture))
            {
                CommandIME = InputLanguage.FromCulture(CultureInfo.GetCultureInfo(cmdCulture));
                InputLanguage.CurrentInputLanguage = CommandIME;
            }
            else
            {
                Program.Editor.WriteMessage("无法切换语言，请使用'SetIME'命令设置\n");
            }
        }

        public void Switch2TextIME()
        {
            var txtCulture = Settings.Default.TextIMECulture;
            if (!string.IsNullOrEmpty(txtCulture))
            {
                TextIME = InputLanguage.FromCulture(CultureInfo.GetCultureInfo(txtCulture));
                InputLanguage.CurrentInputLanguage = TextIME;
            }
            else
            {
                Program.Editor.WriteMessage("无法切换语言，请使用'SetIME'命令设置\n");
            }

        }

        public void Switch2DefaultIME()
        {
            InputLanguage.CurrentInputLanguage = DefaultIME;
        }

        public void Switch2IME(string commandName)
        {
            var txtCmds = Settings.Default.TextCommands;
            if (txtCmds.Contains(commandName.Trim().ToUpper()))
            {
                Switch2TextIME();
            }
            else
            {
                Switch2CommandIME();
            }
        }

        public void ResetCommandsSettings(string[] commands)
        {
            Settings.Default.TextCommands.Clear();
            Settings.Default.TextCommands.AddRange(commands);
            Settings.Default.Save();
        }

        public void SetIMEs()
        {
            Settings.Default.CommandIMECulture = CommandIME.Culture.Name;
            Settings.Default.TextIMECulture = TextIME.Culture.Name;
            Settings.Default.Save();
        }
    }
}
