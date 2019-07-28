namespace WinAppsLinker
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.treeViewApps = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.checkBoxMsApps = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // treeViewApps
            // 
            this.treeViewApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewApps.ImageIndex = 0;
            this.treeViewApps.ImageList = this.imageList;
            this.treeViewApps.Location = new System.Drawing.Point(12, 36);
            this.treeViewApps.Name = "treeViewApps";
            this.treeViewApps.SelectedImageIndex = 0;
            this.treeViewApps.Size = new System.Drawing.Size(776, 402);
            this.treeViewApps.TabIndex = 0;
            this.treeViewApps.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewApps_BeforeSelect);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // checkBoxMsApps
            // 
            this.checkBoxMsApps.AutoSize = true;
            this.checkBoxMsApps.Location = new System.Drawing.Point(13, 13);
            this.checkBoxMsApps.Name = "checkBoxMsApps";
            this.checkBoxMsApps.Size = new System.Drawing.Size(133, 17);
            this.checkBoxMsApps.TabIndex = 1;
            this.checkBoxMsApps.Text = "Show all installed apps";
            this.checkBoxMsApps.UseVisualStyleBackColor = true;
            this.checkBoxMsApps.CheckedChanged += new System.EventHandler(this.CheckBoxMsApps_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxMsApps);
            this.Controls.Add(this.treeViewApps);
            this.Name = "MainForm";
            this.Text = "Apps Linker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewApps;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.CheckBox checkBoxMsApps;
    }
}

