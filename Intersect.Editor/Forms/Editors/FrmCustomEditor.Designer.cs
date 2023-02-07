using System.ComponentModel;
using System.Windows.Forms;
using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors
{
    partial class FrmCustomEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomEditor));
            this.toolStrip = new DarkUI.Controls.DarkToolStrip();
            this.toolStripItemNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItemDelete = new System.Windows.Forms.ToolStripButton();
            this.grpVariableType = new DarkUI.Controls.DarkGroupBox();
            this.btnClearVariableTypeSearch = new DarkUI.Controls.DarkButton();
            this.txtVariableTypeSearch = new DarkUI.Controls.DarkTextBox();
            this.lstVariableType = new Intersect.Editor.Forms.Controls.GameObjectList();
            this.grpVariable = new DarkUI.Controls.DarkGroupBox();
            this.btnClearVariableSearch = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.txtVariableSearch = new DarkUI.Controls.DarkTextBox();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.lstVariable = new Intersect.Editor.Forms.Controls.GameObjectList();
            this.mapTypePanel = new System.Windows.Forms.Panel();
            this.mapTypeNameLbl = new System.Windows.Forms.Label();
            this.mapTypeNameTxt = new System.Windows.Forms.TextBox();
            this.mapTypePvpCombo = new System.Windows.Forms.ComboBox();
            this.mapTypePvpLbl = new System.Windows.Forms.Label();
            this.mapTypeNametagLbl = new System.Windows.Forms.Label();
            this.mapTypeNametagCombo = new System.Windows.Forms.ComboBox();
            this.mapTypeLanternLbl = new System.Windows.Forms.Label();
            this.mapTypeLanternCombo = new System.Windows.Forms.ComboBox();
            this.mapTypeItemDropCheckBox = new System.Windows.Forms.CheckBox();
            this.tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip.SuspendLayout();
            this.grpVariableType.SuspendLayout();
            this.grpVariable.SuspendLayout();
            this.mapTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.toolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripItemNew,
            this.toolStripSeparator1,
            this.toolStripItemDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip.Size = new System.Drawing.Size(646, 25);
            this.toolStrip.TabIndex = 45;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripItemNew
            // 
            this.toolStripItemNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripItemNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripItemNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItemNew.Image")));
            this.toolStripItemNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItemNew.Name = "toolStripItemNew";
            this.toolStripItemNew.Size = new System.Drawing.Size(23, 22);
            this.toolStripItemNew.Text = "New";
            this.toolStripItemNew.Click += new System.EventHandler(this.toolStripItemNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripItemDelete
            // 
            this.toolStripItemDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripItemDelete.Enabled = false;
            this.toolStripItemDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItemDelete.Image")));
            this.toolStripItemDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItemDelete.Name = "toolStripItemDelete";
            this.toolStripItemDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripItemDelete.Text = "Delete";
            this.toolStripItemDelete.Click += new System.EventHandler(this.toolStripItemDelete_Click);
            // 
            // grpVariableType
            // 
            this.grpVariableType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpVariableType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpVariableType.Controls.Add(this.btnClearVariableTypeSearch);
            this.grpVariableType.Controls.Add(this.txtVariableTypeSearch);
            this.grpVariableType.Controls.Add(this.lstVariableType);
            this.grpVariableType.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpVariableType.Location = new System.Drawing.Point(12, 28);
            this.grpVariableType.Name = "grpVariableType";
            this.grpVariableType.Size = new System.Drawing.Size(203, 482);
            this.grpVariableType.TabIndex = 1;
            this.grpVariableType.TabStop = false;
            this.grpVariableType.Text = "Variables";
            // 
            // btnClearVariableTypeSearch
            // 
            this.btnClearVariableTypeSearch.Location = new System.Drawing.Point(179, 17);
            this.btnClearVariableTypeSearch.Name = "btnClearVariableTypeSearch";
            this.btnClearVariableTypeSearch.Padding = new System.Windows.Forms.Padding(5);
            this.btnClearVariableTypeSearch.Size = new System.Drawing.Size(18, 20);
            this.btnClearVariableTypeSearch.TabIndex = 31;
            this.btnClearVariableTypeSearch.Text = "X";
            this.btnClearVariableTypeSearch.Click += new System.EventHandler(this.btnClearVariableTypeSearch_Click);
            // 
            // txtVariableTypeSearch
            // 
            this.txtVariableTypeSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtVariableTypeSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVariableTypeSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtVariableTypeSearch.Location = new System.Drawing.Point(6, 17);
            this.txtVariableTypeSearch.Name = "txtVariableTypeSearch";
            this.txtVariableTypeSearch.Size = new System.Drawing.Size(167, 20);
            this.txtVariableTypeSearch.TabIndex = 30;
            this.txtVariableTypeSearch.Text = "Search...";
            this.txtVariableTypeSearch.Click += new System.EventHandler(this.txtVariableTypeSearch_Click);
            this.txtVariableTypeSearch.TextChanged += new System.EventHandler(this.txtVariableTypeSearch_TextChanged);
            this.txtVariableTypeSearch.Enter += new System.EventHandler(this.txtVariableTypeSearch_Enter);
            this.txtVariableTypeSearch.Leave += new System.EventHandler(this.txtVariableTypeSearch_Leave);
            // 
            // lstVariableType
            // 
            this.lstVariableType.AllowDrop = true;
            this.lstVariableType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstVariableType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstVariableType.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstVariableType.HideSelection = false;
            this.lstVariableType.ImageIndex = 0;
            this.lstVariableType.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lstVariableType.Location = new System.Drawing.Point(6, 43);
            this.lstVariableType.Name = "lstVariableType";
            this.lstVariableType.SelectedImageIndex = 0;
            this.lstVariableType.Size = new System.Drawing.Size(191, 449);
            this.lstVariableType.TabIndex = 29;
            // 
            // grpVariable
            // 
            this.grpVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpVariable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpVariable.Controls.Add(this.mapTypePanel);
            this.grpVariable.Controls.Add(this.btnClearVariableSearch);
            this.grpVariable.Controls.Add(this.btnSave);
            this.grpVariable.Controls.Add(this.txtVariableSearch);
            this.grpVariable.Controls.Add(this.btnCancel);
            this.grpVariable.Controls.Add(this.lstVariable);
            this.grpVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpVariable.Location = new System.Drawing.Point(221, 28);
            this.grpVariable.Name = "grpVariable";
            this.grpVariable.Size = new System.Drawing.Size(412, 482);
            this.grpVariable.TabIndex = 32;
            this.grpVariable.TabStop = false;
            this.grpVariable.Text = "Map Type";
            // 
            // btnClearVariableSearch
            // 
            this.btnClearVariableSearch.Location = new System.Drawing.Point(179, 17);
            this.btnClearVariableSearch.Name = "btnClearVariableSearch";
            this.btnClearVariableSearch.Padding = new System.Windows.Forms.Padding(5);
            this.btnClearVariableSearch.Size = new System.Drawing.Size(18, 20);
            this.btnClearVariableSearch.TabIndex = 31;
            this.btnClearVariableSearch.Text = "X";
            this.btnClearVariableSearch.Click += new System.EventHandler(this.btnClearVariableSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(201, 448);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(101, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtVariableSearch
            // 
            this.txtVariableSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtVariableSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVariableSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtVariableSearch.Location = new System.Drawing.Point(6, 17);
            this.txtVariableSearch.Name = "txtVariableSearch";
            this.txtVariableSearch.Size = new System.Drawing.Size(167, 20);
            this.txtVariableSearch.TabIndex = 30;
            this.txtVariableSearch.Text = "Search...";
            this.txtVariableSearch.Click += new System.EventHandler(this.txtVariableSearch_Click);
            this.txtVariableSearch.TextChanged += new System.EventHandler(this.txtVariableSearch_TextChanged);
            this.txtVariableSearch.Enter += new System.EventHandler(this.txtVariableSearch_Enter);
            this.txtVariableSearch.Leave += new System.EventHandler(this.txtVariableSearch_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(308, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(98, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstVariable
            // 
            this.lstVariable.AllowDrop = true;
            this.lstVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstVariable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstVariable.HideSelection = false;
            this.lstVariable.ImageIndex = 0;
            this.lstVariable.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lstVariable.Location = new System.Drawing.Point(6, 43);
            this.lstVariable.Name = "lstVariable";
            this.lstVariable.SelectedImageIndex = 0;
            this.lstVariable.Size = new System.Drawing.Size(191, 449);
            this.lstVariable.TabIndex = 29;
            // 
            // mapTypePanel
            // 
            this.mapTypePanel.Controls.Add(this.mapTypeNameLbl);
            this.mapTypePanel.Controls.Add(this.mapTypeNameTxt);
            this.mapTypePanel.Controls.Add(this.mapTypePvpLbl);
            this.mapTypePanel.Controls.Add(this.mapTypePvpCombo);
            this.mapTypePanel.Controls.Add(this.mapTypeNametagLbl);
            this.mapTypePanel.Controls.Add(this.mapTypeNametagCombo);
            this.mapTypePanel.Controls.Add(this.mapTypeLanternLbl);
            this.mapTypePanel.Controls.Add(this.mapTypeLanternCombo);
            this.mapTypePanel.Controls.Add(this.mapTypeItemDropCheckBox);
            this.mapTypePanel.Location = new System.Drawing.Point(201, 19);
            this.mapTypePanel.Name = "mapTypePanel";
            this.mapTypePanel.Size = new System.Drawing.Size(207, 423);
            this.mapTypePanel.TabIndex = 42;
            mapTypePanel.Visible = false;
            // 
            // mapTypeNameLbl
            // 
            this.mapTypeNameLbl.AutoSize = true;
            this.mapTypeNameLbl.Location = new System.Drawing.Point(56, 6);
            this.mapTypeNameLbl.Name = "mapTypeNameLbl";
            this.mapTypeNameLbl.Size = new System.Drawing.Size(38, 13);
            this.mapTypeNameLbl.TabIndex = 32;
            this.mapTypeNameLbl.Text = "Name:";
            // 
            // mapTypeNameTxt
            // 
            this.mapTypeNameTxt.Location = new System.Drawing.Point(100, 3);
            this.mapTypeNameTxt.Name = "mapTypeNameTxt";
            this.mapTypeNameTxt.Size = new System.Drawing.Size(104, 20);
            this.mapTypeNameTxt.TabIndex = 33;
            this.mapTypeNameTxt.TextChanged += new System.EventHandler(this.mapTypeNameTxt_TextChanged);
            // 
            // mapTypePvpCombo
            // 
            this.mapTypePvpCombo.FormattingEnabled = true;
            this.mapTypePvpCombo.Location = new System.Drawing.Point(100, 29);
            this.mapTypePvpCombo.Name = "mapTypePvpCombo";
            this.mapTypePvpCombo.Size = new System.Drawing.Size(104, 21);
            this.mapTypePvpCombo.TabIndex = 35;
            this.mapTypePvpCombo.SelectedIndexChanged += new System.EventHandler(this.mapTypePvpCombo_SelectedIndexChanged);
            // 
            // mapTypePvpLbl
            // 
            this.mapTypePvpLbl.AutoSize = true;
            this.mapTypePvpLbl.Location = new System.Drawing.Point(64, 32);
            this.mapTypePvpLbl.Name = "mapTypePvpLbl";
            this.mapTypePvpLbl.Size = new System.Drawing.Size(30, 13);
            this.mapTypePvpLbl.TabIndex = 34;
            this.mapTypePvpLbl.Text = "PvP:";
            // 
            // mapTypeNametagLbl
            // 
            this.mapTypeNametagLbl.AutoSize = true;
            this.mapTypeNametagLbl.Location = new System.Drawing.Point(2, 59);
            this.mapTypeNametagLbl.Name = "mapTypeNametagLbl";
            this.mapTypeNametagLbl.Size = new System.Drawing.Size(92, 13);
            this.mapTypeNametagLbl.TabIndex = 36;
            this.mapTypeNametagLbl.Text = "Nametag Visibility:";
            // 
            // mapTypeNametagCombo
            // 
            this.mapTypeNametagCombo.FormattingEnabled = true;
            this.mapTypeNametagCombo.Location = new System.Drawing.Point(100, 56);
            this.mapTypeNametagCombo.Name = "mapTypeNametagCombo";
            this.mapTypeNametagCombo.Size = new System.Drawing.Size(104, 21);
            this.mapTypeNametagCombo.TabIndex = 37;
            this.mapTypeNametagCombo.SelectedIndexChanged += new System.EventHandler(this.mapTypeNametagCombo_SelectedIndexChanged);
            // 
            // mapTypeLanternLbl
            // 
            this.mapTypeLanternLbl.AutoSize = true;
            this.mapTypeLanternLbl.Location = new System.Drawing.Point(9, 86);
            this.mapTypeLanternLbl.Name = "mapTypeLanternLbl";
            this.mapTypeLanternLbl.Size = new System.Drawing.Size(85, 13);
            this.mapTypeLanternLbl.TabIndex = 39;
            this.mapTypeLanternLbl.Text = "Lantern Visibility:";
            // 
            // mapTypeLanternCombo
            // 
            this.mapTypeLanternCombo.FormattingEnabled = true;
            this.mapTypeLanternCombo.Location = new System.Drawing.Point(100, 83);
            this.mapTypeLanternCombo.Name = "mapTypeLanternCombo";
            this.mapTypeLanternCombo.Size = new System.Drawing.Size(104, 21);
            this.mapTypeLanternCombo.TabIndex = 38;
            this.mapTypeLanternCombo.SelectedIndexChanged += new System.EventHandler(this.mapTypeLanternCombo_SelectedIndexChanged);
            // 
            // mapTypeItemDropCheckBox
            // 
            this.mapTypeItemDropCheckBox.AutoSize = true;
            this.mapTypeItemDropCheckBox.Location = new System.Drawing.Point(87, 110);
            this.mapTypeItemDropCheckBox.Name = "mapTypeItemDropCheckBox";
            this.mapTypeItemDropCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mapTypeItemDropCheckBox.Size = new System.Drawing.Size(117, 17);
            this.mapTypeItemDropCheckBox.TabIndex = 41;
            this.mapTypeItemDropCheckBox.Text = ":Item Drop Enabled";
            this.mapTypeItemDropCheckBox.UseVisualStyleBackColor = true;
            this.mapTypeItemDropCheckBox.CheckedChanged += new System.EventHandler(this.mapTypeItemDropCheckBox_CheckedChanged);
            // 
            // FrmCustomEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(646, 517);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.grpVariableType);
            this.Controls.Add(this.grpVariable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmCustomEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmItem_FormClosed);
            this.Load += new System.EventHandler(this.frmCustomEditor_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpVariableType.ResumeLayout(false);
            this.grpVariableType.PerformLayout();
            this.grpVariable.ResumeLayout(false);
            this.grpVariable.PerformLayout();
            this.mapTypePanel.ResumeLayout(false);
            this.mapTypePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkGroupBox grpVariableType;
        private DarkButton btnClearVariableTypeSearch;
        private DarkTextBox txtVariableTypeSearch;
        private Controls.GameObjectList lstVariableType;

        private DarkGroupBox grpVariable;
        private DarkButton btnClearVariableSearch;
        private DarkTextBox txtVariableSearch;
        private Controls.GameObjectList lstVariable;

        private Panel mapTypePanel;
        private Label mapTypeNameLbl;
        private TextBox mapTypeNameTxt;
        private Label mapTypePvpLbl;
        private ComboBox mapTypePvpCombo;
        private Label mapTypeNametagLbl;
        private ComboBox mapTypeNametagCombo;
        private Label mapTypeLanternLbl;
        private ComboBox mapTypeLanternCombo;
        private CheckBox mapTypeItemDropCheckBox;

        private DarkButton btnSave;
        private DarkButton btnCancel;
        private ToolTip tooltips;
        private DarkToolStrip toolStrip;
        private ToolStripButton toolStripItemNew;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripItemDelete;

    }
}
