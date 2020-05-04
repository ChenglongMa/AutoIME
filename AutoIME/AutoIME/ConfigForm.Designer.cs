namespace AutoIME
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEngCheck = new System.Windows.Forms.Button();
            this.btnChiCheck = new System.Windows.Forms.Button();
            this.lblEngCheck = new System.Windows.Forms.Label();
            this.lblChiCheck = new System.Windows.Forms.Label();
            this.lbxCmds = new System.Windows.Forms.ListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(30, 389);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 32);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(286, 389);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnEngCheck
            // 
            this.btnEngCheck.Location = new System.Drawing.Point(30, 24);
            this.btnEngCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEngCheck.Name = "btnEngCheck";
            this.btnEngCheck.Size = new System.Drawing.Size(291, 32);
            this.btnEngCheck.TabIndex = 0;
            this.btnEngCheck.Text = "请切换至英文输入法，然后单击该按钮";
            this.btnEngCheck.UseVisualStyleBackColor = true;
            this.btnEngCheck.Click += new System.EventHandler(this.btnEngCheck_Click);
            // 
            // btnChiCheck
            // 
            this.btnChiCheck.Location = new System.Drawing.Point(30, 73);
            this.btnChiCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChiCheck.Name = "btnChiCheck";
            this.btnChiCheck.Size = new System.Drawing.Size(291, 32);
            this.btnChiCheck.TabIndex = 0;
            this.btnChiCheck.Text = "请切换至中文输入法，然后单击该按钮";
            this.btnChiCheck.UseVisualStyleBackColor = true;
            this.btnChiCheck.Click += new System.EventHandler(this.btnChiCheck_Click);
            // 
            // lblEngCheck
            // 
            this.lblEngCheck.AutoSize = true;
            this.lblEngCheck.Font = new System.Drawing.Font("SimSun", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEngCheck.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lblEngCheck.Location = new System.Drawing.Point(322, 24);
            this.lblEngCheck.Name = "lblEngCheck";
            this.lblEngCheck.Size = new System.Drawing.Size(41, 28);
            this.lblEngCheck.TabIndex = 1;
            this.lblEngCheck.Text = "✔";
            this.lblEngCheck.Visible = false;
            // 
            // lblChiCheck
            // 
            this.lblChiCheck.AutoSize = true;
            this.lblChiCheck.Font = new System.Drawing.Font("SimSun", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChiCheck.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lblChiCheck.Location = new System.Drawing.Point(322, 73);
            this.lblChiCheck.Name = "lblChiCheck";
            this.lblChiCheck.Size = new System.Drawing.Size(41, 28);
            this.lblChiCheck.TabIndex = 1;
            this.lblChiCheck.Text = "✔";
            this.lblChiCheck.Visible = false;
            // 
            // lbxCmds
            // 
            this.lbxCmds.BackColor = System.Drawing.SystemColors.Info;
            this.lbxCmds.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbxCmds.FormattingEnabled = true;
            this.lbxCmds.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lbxCmds.ItemHeight = 15;
            this.lbxCmds.Location = new System.Drawing.Point(3, 41);
            this.lbxCmds.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.lbxCmds.Name = "lbxCmds";
            this.lbxCmds.Size = new System.Drawing.Size(279, 169);
            this.lbxCmds.TabIndex = 2;
            this.lbxCmds.SelectedIndexChanged += new System.EventHandler(this.lbxCmds_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(357, 24);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(44, 81);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "重\n置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 423);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(409, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(41, 20);
            this.status.Text = "就绪";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(30, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 241);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "需要中文输入的命令";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtCmd);
            this.flowLayoutPanel1.Controls.Add(this.lbxCmds);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 217);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // txtCmd
            // 
            this.txtCmd.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCmd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCmd.Location = new System.Drawing.Point(3, 3);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(279, 25);
            this.txtCmd.TabIndex = 6;
            this.txtCmd.TextChanged += new System.EventHandler(this.txtCmd_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(327, 167);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 37);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(327, 210);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(40, 37);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(409, 449);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblChiCheck);
            this.Controls.Add(this.lblEngCheck);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChiCheck);
            this.Controls.Add(this.btnEngCheck);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoIME 配置";
            this.TopMost = true;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEngCheck;
        private System.Windows.Forms.Button btnChiCheck;
        private System.Windows.Forms.Label lblEngCheck;
        private System.Windows.Forms.Label lblChiCheck;
        private System.Windows.Forms.ListBox lbxCmds;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}