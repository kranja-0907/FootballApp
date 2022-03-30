
namespace Windows_Forms_Aplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbCountries = new System.Windows.Forms.ComboBox();
            this.pnlAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFavouritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMatchSorter = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPlayerSorter = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yellowCardsSorter = new System.Windows.Forms.CheckBox();
            this.goalsSorter = new System.Windows.Forms.CheckBox();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseAPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagePreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbGif = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGif)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCountries
            // 
            this.cbCountries.FormattingEnabled = true;
            resources.ApplyResources(this.cbCountries, "cbCountries");
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.SelectedIndexChanged += new System.EventHandler(this.cbCountries_SelectedIndexChanged);
            // 
            // pnlAllPlayers
            // 
            this.pnlAllPlayers.AllowDrop = true;
            resources.ApplyResources(this.pnlAllPlayers, "pnlAllPlayers");
            this.pnlAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAllPlayers.Name = "pnlAllPlayers";
            this.pnlAllPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlAllPlayers_DragDrop);
            this.pnlAllPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlAllPlayers_DragEnter);
            // 
            // pnlFavouritePlayers
            // 
            this.pnlFavouritePlayers.AllowDrop = true;
            resources.ApplyResources(this.pnlFavouritePlayers, "pnlFavouritePlayers");
            this.pnlFavouritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFavouritePlayers.Name = "pnlFavouritePlayers";
            this.pnlFavouritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlFavouritePlayers_DragDrop);
            this.pnlFavouritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlFavouritePlayers_DragEnter);
            // 
            // pnlMatchSorter
            // 
            this.pnlMatchSorter.AllowDrop = true;
            resources.ApplyResources(this.pnlMatchSorter, "pnlMatchSorter");
            this.pnlMatchSorter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMatchSorter.Name = "pnlMatchSorter";
            // 
            // pnlPlayerSorter
            // 
            this.pnlPlayerSorter.AllowDrop = true;
            resources.ApplyResources(this.pnlPlayerSorter, "pnlPlayerSorter");
            this.pnlPlayerSorter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPlayerSorter.Name = "pnlPlayerSorter";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // yellowCardsSorter
            // 
            resources.ApplyResources(this.yellowCardsSorter, "yellowCardsSorter");
            this.yellowCardsSorter.Name = "yellowCardsSorter";
            this.yellowCardsSorter.UseVisualStyleBackColor = true;
            this.yellowCardsSorter.Click += new System.EventHandler(this.yellowCardsSorter_Click);
            // 
            // goalsSorter
            // 
            resources.ApplyResources(this.goalsSorter, "goalsSorter");
            this.goalsSorter.Name = "goalsSorter";
            this.goalsSorter.UseVisualStyleBackColor = true;
            this.goalsSorter.Click += new System.EventHandler(this.goalsSorter_Click);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseAPrinterToolStripMenuItem,
            this.pagePreviewToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // chooseAPrinterToolStripMenuItem
            // 
            this.chooseAPrinterToolStripMenuItem.Name = "chooseAPrinterToolStripMenuItem";
            resources.ApplyResources(this.chooseAPrinterToolStripMenuItem, "chooseAPrinterToolStripMenuItem");
            this.chooseAPrinterToolStripMenuItem.Click += new System.EventHandler(this.chooseAPrinterToolStripMenuItem_Click);
            // 
            // pagePreviewToolStripMenuItem
            // 
            this.pagePreviewToolStripMenuItem.Name = "pagePreviewToolStripMenuItem";
            resources.ApplyResources(this.pagePreviewToolStripMenuItem, "pagePreviewToolStripMenuItem");
            this.pagePreviewToolStripMenuItem.Click += new System.EventHandler(this.pagePreviewToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            resources.ApplyResources(this.lblStatus, "lblStatus");
            // 
            // pbGif
            // 
            this.pbGif.Image = global::Windows_Forms_Aplication.Properties.Resources.gif;
            resources.ApplyResources(this.pbGif, "pbGif");
            this.pbGif.Name = "pbGif";
            this.pbGif.TabStop = false;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.pbGif);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.goalsSorter);
            this.Controls.Add(this.yellowCardsSorter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMatchSorter);
            this.Controls.Add(this.pnlPlayerSorter);
            this.Controls.Add(this.pnlFavouritePlayers);
            this.Controls.Add(this.pnlAllPlayers);
            this.Controls.Add(this.cbCountries);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbCountries;
        private System.Windows.Forms.FlowLayoutPanel pnlAllPlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlFavouritePlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlMatchSorter;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayerSorter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox yellowCardsSorter;
        private System.Windows.Forms.CheckBox goalsSorter;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseAPrinterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagePreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.PictureBox pbGif;
    }
}

