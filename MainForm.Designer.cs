/*
 * Created by SharpDevelop.
 * User: Owner
 * Date: 12/8/2016
 * Time: 8:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BackupMoreFiles
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.goButton = new System.Windows.Forms.Button();
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.toolsTabPage = new System.Windows.Forms.TabPage();
			this.logTabPage = new System.Windows.Forms.TabPage();
			this.outputListBox = new System.Windows.Forms.ListBox();
			this.statusTextBox = new System.Windows.Forms.TextBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.mainTabControl.SuspendLayout();
			this.toolsTabPage.SuspendLayout();
			this.logTabPage.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.goButton, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 414);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// goButton
			// 
			this.goButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.goButton.AutoSize = true;
			this.goButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.goButton.Location = new System.Drawing.Point(180, 85);
			this.goButton.Margin = new System.Windows.Forms.Padding(6);
			this.goButton.Name = "goButton";
			this.goButton.Size = new System.Drawing.Size(46, 36);
			this.goButton.TabIndex = 0;
			this.goButton.Text = "Go";
			this.goButton.UseVisualStyleBackColor = true;
			this.goButton.Click += new System.EventHandler(this.GoButtonClick);
			// 
			// mainTabControl
			// 
			this.mainTabControl.Controls.Add(this.toolsTabPage);
			this.mainTabControl.Controls.Add(this.logTabPage);
			this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTabControl.Location = new System.Drawing.Point(0, 24);
			this.mainTabControl.Margin = new System.Windows.Forms.Padding(6);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.Size = new System.Drawing.Size(426, 465);
			this.mainTabControl.TabIndex = 1;
			// 
			// toolsTabPage
			// 
			this.toolsTabPage.Controls.Add(this.tableLayoutPanel1);
			this.toolsTabPage.Location = new System.Drawing.Point(4, 35);
			this.toolsTabPage.Margin = new System.Windows.Forms.Padding(6);
			this.toolsTabPage.Name = "toolsTabPage";
			this.toolsTabPage.Padding = new System.Windows.Forms.Padding(6);
			this.toolsTabPage.Size = new System.Drawing.Size(418, 426);
			this.toolsTabPage.TabIndex = 0;
			this.toolsTabPage.Text = "Tools";
			this.toolsTabPage.UseVisualStyleBackColor = true;
			// 
			// logTabPage
			// 
			this.logTabPage.Controls.Add(this.outputListBox);
			this.logTabPage.Location = new System.Drawing.Point(4, 35);
			this.logTabPage.Margin = new System.Windows.Forms.Padding(6);
			this.logTabPage.Name = "logTabPage";
			this.logTabPage.Padding = new System.Windows.Forms.Padding(6);
			this.logTabPage.Size = new System.Drawing.Size(418, 426);
			this.logTabPage.TabIndex = 1;
			this.logTabPage.Text = "Log";
			this.logTabPage.UseVisualStyleBackColor = true;
			// 
			// outputListBox
			// 
			this.outputListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputListBox.FormattingEnabled = true;
			this.outputListBox.ItemHeight = 26;
			this.outputListBox.Location = new System.Drawing.Point(6, 6);
			this.outputListBox.Margin = new System.Windows.Forms.Padding(6);
			this.outputListBox.Name = "outputListBox";
			this.outputListBox.Size = new System.Drawing.Size(406, 394);
			this.outputListBox.TabIndex = 0;
			// 
			// statusTextBox
			// 
			this.statusTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.statusTextBox.Location = new System.Drawing.Point(0, 489);
			this.statusTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.statusTextBox.Name = "statusTextBox";
			this.statusTextBox.Size = new System.Drawing.Size(426, 33);
			this.statusTextBox.TabIndex = 2;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(426, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.saveLogToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// saveLogToolStripMenuItem
			// 
			this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
			this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.saveLogToolStripMenuItem.Text = "Save Log...";
			this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.SaveLogToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 522);
			this.Controls.Add(this.mainTabControl);
			this.Controls.Add(this.statusTextBox);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "MainForm";
			this.Text = "Backup MoreFiles";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.mainTabControl.ResumeLayout(false);
			this.toolsTabPage.ResumeLayout(false);
			this.logTabPage.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ListBox outputListBox;
		private System.Windows.Forms.TextBox statusTextBox;
		private System.Windows.Forms.TabPage toolsTabPage;
		private System.Windows.Forms.TabPage logTabPage;
		private System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.Button goButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
