namespace RoslynShoppingCartDSL.Demo {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuScripts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScriptsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScriptsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuScriptsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuScripts,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(360, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuScripts
            // 
            this.menuScripts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuScriptsNew,
            this.menuScriptsOpen,
            this.toolStripSeparator1,
            this.menuScriptsExit});
            this.menuScripts.Name = "menuScripts";
            this.menuScripts.Size = new System.Drawing.Size(54, 20);
            this.menuScripts.Text = "Scripts";
            // 
            // menuScriptsNew
            // 
            this.menuScriptsNew.Name = "menuScriptsNew";
            this.menuScriptsNew.Size = new System.Drawing.Size(152, 22);
            this.menuScriptsNew.Text = "New";
            // 
            // menuScriptsOpen
            // 
            this.menuScriptsOpen.Enabled = false;
            this.menuScriptsOpen.Name = "menuScriptsOpen";
            this.menuScriptsOpen.Size = new System.Drawing.Size(152, 22);
            this.menuScriptsOpen.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuScriptsExit
            // 
            this.menuScriptsExit.Name = "menuScriptsExit";
            this.menuScriptsExit.Size = new System.Drawing.Size(152, 22);
            this.menuScriptsExit.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 262);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Demo Roslyn Shopping Cart DSL";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuScripts;
        private System.Windows.Forms.ToolStripMenuItem menuScriptsNew;
        private System.Windows.Forms.ToolStripMenuItem menuScriptsOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuScriptsExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

