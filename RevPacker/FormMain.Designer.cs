namespace RevPacker
{
  partial class FormMain
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
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.buttonCreateGro = new System.Windows.Forms.ToolStripButton();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.label1 = new System.Windows.Forms.Label();
      this.textGamePath = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.buttonRefreshDependencies = new System.Windows.Forms.Button();
      this.buttonRemoveFile = new System.Windows.Forms.Button();
      this.buttonAddFile = new System.Windows.Forms.Button();
      this.listFiles = new System.Windows.Forms.TreeView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.checkVerbose = new System.Windows.Forms.CheckBox();
      this.textDependencies = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.toolStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCreateGro});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(819, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // buttonCreateGro
      // 
      this.buttonCreateGro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonCreateGro.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreateGro.Image")));
      this.buttonCreateGro.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonCreateGro.Name = "buttonCreateGro";
      this.buttonCreateGro.Size = new System.Drawing.Size(23, 22);
      this.buttonCreateGro.Text = "Create Gro";
      this.buttonCreateGro.Click += new System.EventHandler(this.buttonCreateGro_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(12, 28);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(795, 453);
      this.tabControl1.TabIndex = 1;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.label1);
      this.tabPage1.Controls.Add(this.textGamePath);
      this.tabPage1.Controls.Add(this.button1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(787, 427);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "General";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(62, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Game path:";
      // 
      // textGamePath
      // 
      this.textGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textGamePath.Location = new System.Drawing.Point(74, 6);
      this.textGamePath.Name = "textGamePath";
      this.textGamePath.Size = new System.Drawing.Size(626, 20);
      this.textGamePath.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(706, 4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Browse...";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.buttonRefreshDependencies);
      this.tabPage2.Controls.Add(this.buttonRemoveFile);
      this.tabPage2.Controls.Add(this.buttonAddFile);
      this.tabPage2.Controls.Add(this.listFiles);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(787, 427);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Files";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // buttonRefreshDependencies
      // 
      this.buttonRefreshDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonRefreshDependencies.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefreshDependencies.Image")));
      this.buttonRefreshDependencies.Location = new System.Drawing.Point(744, 6);
      this.buttonRefreshDependencies.Name = "buttonRefreshDependencies";
      this.buttonRefreshDependencies.Size = new System.Drawing.Size(37, 27);
      this.buttonRefreshDependencies.TabIndex = 1;
      this.buttonRefreshDependencies.UseVisualStyleBackColor = true;
      this.buttonRefreshDependencies.Click += new System.EventHandler(this.buttonRefreshDependencies_Click);
      // 
      // buttonRemoveFile
      // 
      this.buttonRemoveFile.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveFile.Image")));
      this.buttonRemoveFile.Location = new System.Drawing.Point(49, 6);
      this.buttonRemoveFile.Name = "buttonRemoveFile";
      this.buttonRemoveFile.Size = new System.Drawing.Size(37, 27);
      this.buttonRemoveFile.TabIndex = 1;
      this.buttonRemoveFile.UseVisualStyleBackColor = true;
      this.buttonRemoveFile.Click += new System.EventHandler(this.buttonRemoveFile_Click);
      // 
      // buttonAddFile
      // 
      this.buttonAddFile.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddFile.Image")));
      this.buttonAddFile.Location = new System.Drawing.Point(6, 6);
      this.buttonAddFile.Name = "buttonAddFile";
      this.buttonAddFile.Size = new System.Drawing.Size(37, 27);
      this.buttonAddFile.TabIndex = 1;
      this.buttonAddFile.UseVisualStyleBackColor = true;
      this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
      // 
      // listFiles
      // 
      this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listFiles.ImageIndex = 0;
      this.listFiles.ImageList = this.imageList1;
      this.listFiles.Location = new System.Drawing.Point(6, 39);
      this.listFiles.Name = "listFiles";
      this.listFiles.SelectedImageIndex = 0;
      this.listFiles.Size = new System.Drawing.Size(775, 382);
      this.listFiles.TabIndex = 0;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "World");
      this.imageList1.Images.SetKeyName(1, "Texture");
      this.imageList1.Images.SetKeyName(2, "Sound");
      this.imageList1.Images.SetKeyName(3, "Music");
      this.imageList1.Images.SetKeyName(4, "Model");
      this.imageList1.Images.SetKeyName(5, "Page");
      this.imageList1.Images.SetKeyName(6, "zoom.png");
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.checkVerbose);
      this.tabPage3.Controls.Add(this.textDependencies);
      this.tabPage3.Controls.Add(this.label2);
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(787, 427);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Report";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // checkVerbose
      // 
      this.checkVerbose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.checkVerbose.AutoSize = true;
      this.checkVerbose.Location = new System.Drawing.Point(716, 6);
      this.checkVerbose.Name = "checkVerbose";
      this.checkVerbose.Size = new System.Drawing.Size(65, 17);
      this.checkVerbose.TabIndex = 4;
      this.checkVerbose.Text = "Verbose";
      this.checkVerbose.UseVisualStyleBackColor = true;
      this.checkVerbose.CheckedChanged += new System.EventHandler(this.checkVerbose_CheckedChanged);
      // 
      // textDependencies
      // 
      this.textDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textDependencies.Location = new System.Drawing.Point(6, 29);
      this.textDependencies.Multiline = true;
      this.textDependencies.Name = "textDependencies";
      this.textDependencies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textDependencies.Size = new System.Drawing.Size(775, 392);
      this.textDependencies.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(255, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "You can copypaste the below textual dependencies:";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(819, 493);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.toolStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Revolution Packer";
      this.Load += new System.EventHandler(this.FormMain_Load);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton buttonCreateGro;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textGamePath;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TreeView listFiles;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textDependencies;
    private System.Windows.Forms.Button buttonAddFile;
    private System.Windows.Forms.Button buttonRemoveFile;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.Button buttonRefreshDependencies;
    private System.Windows.Forms.CheckBox checkVerbose;
  }
}

