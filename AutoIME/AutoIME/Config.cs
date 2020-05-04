using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoIME
{
    public class Config
    {
        public InputLanguage DefaultIME { get; set; }
        public InputLanguage TextIME { get; set; }
        public InputLanguage CommandIME { get; set; }
        private static Config config;
        private Config()
        {

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
            InputLanguage.CurrentInputLanguage = CommandIME;
        }

        public void Switch2TextIME()
        {
            InputLanguage.CurrentInputLanguage = TextIME;
        }

        public void Switch2DefaultIME()
        {
            InputLanguage.CurrentInputLanguage = DefaultIME;
        }

        public void Switch2IME(string commandName)
        {
            var txtCmds = Properties.Settings.Default.TextCommands;
            if (txtCmds.Contains(commandName.Trim().ToUpper()))
            {
                Switch2TextIME();
            }
            else
            {
                Switch2CommandIME();
            }
        }
    }
}
