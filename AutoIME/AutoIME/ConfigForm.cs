using AutoIME.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoIME
{
    public partial class ConfigForm : Form
    {
        private readonly BindingList<string> _cmds = new BindingList<string>();
        public ConfigForm()
        {
            InitializeComponent();
            foreach (var cmd in Settings.Default.TextCommands)
            {
                _cmds.Add(cmd);
            }
            lbxCmds.DataSource = _cmds;
        }

        private void SetEngIME(bool done)
        {
            lblEngCheck.Visible = done;
            btnEngCheck.Enabled = !done;
        }

        private void SetChnIME(bool done)
        {
            lblChiCheck.Visible = done;
            btnChiCheck.Enabled = !done;
        }
        private void btnEngCheck_Click(object sender, EventArgs e)
        {
            SetEngIME(true);
            status.Text = $"已将英文输入法设置为 {InputLanguage.CurrentInputLanguage.Culture.DisplayName}";
        }

        private void btnChiCheck_Click(object sender, EventArgs e)
        {
            SetChnIME(true);
            status.Text = $"已将中文输入法设置为 {InputLanguage.CurrentInputLanguage.Culture.DisplayName}";

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
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

        private void RefreshCommandSettings()
        {
            Settings.Default.TextCommands.Clear();
            Settings.Default.TextCommands.AddRange(_cmds.ToArray());
            Settings.Default.Save();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            RefreshCommandSettings();
        }
    }
}
