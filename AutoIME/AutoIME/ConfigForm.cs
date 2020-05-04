//using AutoIME.Properties;
using AutoIME.Properties;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AutoIME
{
    public partial class ConfigForm : Form
    {
        private readonly BindingList<string> _cmds = new BindingList<string>();
        private readonly Config _config = Config.GetConfigInstance();
        public ConfigForm()
        {
            InitializeComponent();
            foreach (var cmd in Settings.Default.TextCommands)
            {
                _cmds.Add(cmd);
            }
            lbxCmds.DataSource = _cmds;
            var engDone = !string.IsNullOrEmpty(Settings.Default.CommandIMECulture);
            SetEngIME(engDone);
            var chnDone = !string.IsNullOrEmpty(Settings.Default.TextIMECulture);
            SetChnIME(chnDone);
        }

        private void SetEngIME(bool done)
        {
            lblEngCheck.Visible = done;
            btnEngCheck.Enabled = !done;
            var txt = done ? "英文输入法已设置" : "请切换至英文输入法，然后单击该按钮";
            btnEngCheck.Text = txt;
        }

        private void SetChnIME(bool done)
        {
            lblChiCheck.Visible = done;
            btnChiCheck.Enabled = !done;
            var txt = done ? "中文输入法已设置" : "请切换至中文输入法，然后单击该按钮";
            btnChiCheck.Text = txt;
        }

        private void btnEngCheck_Click(object sender, EventArgs e)
        {
            _config.CommandIME = InputLanguage.CurrentInputLanguage;
            SetEngIME(true);
            status.Text = $"已将英文输入法设置为 {_config.CommandIME.Culture.DisplayName}";
        }

        private void btnChiCheck_Click(object sender, EventArgs e)
        {
            _config.TextIME = InputLanguage.CurrentInputLanguage;
            SetChnIME(true);
            status.Text = $"已将中文输入法设置为 {_config.TextIME.Culture.DisplayName}";

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _config.TextIME = null;
            _config.CommandIME = null;
            SetEngIME(false);
            SetChnIME(false);
            status.Text = "就绪";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var cmd = txtCmd.Text.ToUpper().Trim();
            _cmds.Add(cmd);
        }

        private void txtCmd_TextChanged(object sender, EventArgs e)
        {
            var cmd = txtCmd.Text;
            btnAdd.Enabled = !string.IsNullOrEmpty(cmd);
        }

        private void lbxCmds_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = lbxCmds.SelectedIndex >= 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var id = lbxCmds.SelectedIndex;
            _cmds.RemoveAt(id);
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            _config.ResetCommandsSettings(_cmds.ToArray());
            _config.SetIMEs();
            Close();
        }
    }
}
