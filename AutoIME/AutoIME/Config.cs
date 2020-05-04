using AutoIME.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public void Switch2CommandIME()
        {
            var cultureName = Settings.Default.CommandIMECulture;
            CommandIME = InputLanguage.FromCulture(CultureInfo.GetCultureInfo(cultureName));
            InputLanguage.CurrentInputLanguage = CommandIME;
        }

        public void Switch2TextIME()
        {
            var cultureName = Settings.Default.TextIMECulture;
            TextIME = InputLanguage.FromCulture(CultureInfo.GetCultureInfo(cultureName));
            InputLanguage.CurrentInputLanguage = TextIME;
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
