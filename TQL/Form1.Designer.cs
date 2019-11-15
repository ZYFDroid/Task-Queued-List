namespace TQL
{
    partial class Form1
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
            this.renderTimer = new System.Windows.Forms.Timer(this.components);
            this.tblTaskContainer = new System.Windows.Forms.Panel();
            this.scrollBarArea = new System.Windows.Forms.PictureBox();
            this.dragger = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFold = new System.Windows.Forms.Button();
            this.tabPageBar = new System.Windows.Forms.Panel();
            this.btnCompleteFirst = new System.Windows.Forms.Button();
            this.lblFirst = new System.Windows.Forms.Label();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.itemTemplate = new System.Windows.Forms.Panel();
            this.tmpButton = new System.Windows.Forms.Button();
            this.tmpCompleted = new System.Windows.Forms.Label();
            this.tmpLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gcTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.scrollBarArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragger)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPageBar.SuspendLayout();
            this.itemTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // renderTimer
            // 
            this.renderTimer.Enabled = true;
            this.renderTimer.Interval = 1;
            this.renderTimer.Tick += new System.EventHandler(this.renderTimer_Tick);
            // 
            // tblTaskContainer
            // 
            this.tblTaskContainer.Location = new System.Drawing.Point(3, 60);
            this.tblTaskContainer.Name = "tblTaskContainer";
            this.tblTaskContainer.Size = new System.Drawing.Size(292, 343);
            this.tblTaskContainer.TabIndex = 0;
            this.tblTaskContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.tblTaskContainer_Paint);
            this.tblTaskContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tblTaskContainer_MouseUp);
            // 
            // scrollBarArea
            // 
            this.scrollBarArea.Location = new System.Drawing.Point(285, 60);
            this.scrollBarArea.Name = "scrollBarArea";
            this.scrollBarArea.Size = new System.Drawing.Size(13, 348);
            this.scrollBarArea.TabIndex = 0;
            this.scrollBarArea.TabStop = false;
            this.scrollBarArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollBarArea_MouseDown);
            this.scrollBarArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scrollBarArea_MouseMove);
            this.scrollBarArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollBarArea_MouseUp);
            // 
            // dragger
            // 
            this.dragger.Location = new System.Drawing.Point(3, -1);
            this.dragger.Name = "dragger";
            this.dragger.Size = new System.Drawing.Size(292, 35);
            this.dragger.TabIndex = 1;
            this.dragger.TabStop = false;
            this.dragger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseDown);
            this.dragger.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseMove);
            this.dragger.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.ContextMenuStrip = this.contextMenuStrip1;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 27);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "事件列表";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragger_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // btnFold
            // 
            this.btnFold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFold.Location = new System.Drawing.Point(263, 3);
            this.btnFold.Name = "btnFold";
            this.btnFold.Size = new System.Drawing.Size(30, 30);
            this.btnFold.TabIndex = 3;
            this.btnFold.Text = "叠";
            this.toolTip1.SetToolTip(this.btnFold, "折叠/展开面板");
            this.btnFold.UseVisualStyleBackColor = true;
            this.btnFold.Click += new System.EventHandler(this.btnExpandable_Click);
            // 
            // tabPageBar
            // 
            this.tabPageBar.Controls.Add(this.btnCompleteFirst);
            this.tabPageBar.Controls.Add(this.lblFirst);
            this.tabPageBar.Location = new System.Drawing.Point(3, 33);
            this.tabPageBar.Name = "tabPageBar";
            this.tabPageBar.Size = new System.Drawing.Size(292, 27);
            this.tabPageBar.TabIndex = 4;
            // 
            // btnCompleteFirst
            // 
            this.btnCompleteFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompleteFirst.Location = new System.Drawing.Point(270, 8);
            this.btnCompleteFirst.Name = "btnCompleteFirst";
            this.btnCompleteFirst.Size = new System.Drawing.Size(16, 16);
            this.btnCompleteFirst.TabIndex = 1;
            this.btnCompleteFirst.Text = "√";
            this.btnCompleteFirst.UseVisualStyleBackColor = true;
            this.btnCompleteFirst.Click += new System.EventHandler(this.btnCompleteFirst_Click);
            // 
            // lblFirst
            // 
            this.lblFirst.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirst.Location = new System.Drawing.Point(0, 2);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(258, 27);
            this.lblFirst.TabIndex = 0;
            this.lblFirst.Text = "Top:";
            this.lblFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelToolbar
            // 
            this.panelToolbar.Location = new System.Drawing.Point(-6, 409);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(312, 1);
            this.panelToolbar.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Location = new System.Drawing.Point(227, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷";
            this.toolTip1.SetToolTip(this.btnRefresh, "移除已完成事件");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(191, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "加";
            this.toolTip1.SetToolTip(this.btnAdd, "在列表末尾添加事件");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // itemTemplate
            // 
            this.itemTemplate.Controls.Add(this.tmpButton);
            this.itemTemplate.Controls.Add(this.tmpCompleted);
            this.itemTemplate.Controls.Add(this.tmpLabel);
            this.itemTemplate.Location = new System.Drawing.Point(3, 419);
            this.itemTemplate.Name = "itemTemplate";
            this.itemTemplate.Size = new System.Drawing.Size(283, 48);
            this.itemTemplate.TabIndex = 5;
            // 
            // tmpButton
            // 
            this.tmpButton.Location = new System.Drawing.Point(243, 6);
            this.tmpButton.Name = "tmpButton";
            this.tmpButton.Size = new System.Drawing.Size(36, 36);
            this.tmpButton.TabIndex = 1;
            this.tmpButton.Text = "√";
            this.tmpButton.UseVisualStyleBackColor = true;
            // 
            // tmpCompleted
            // 
            this.tmpCompleted.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tmpCompleted.Location = new System.Drawing.Point(170, 18);
            this.tmpCompleted.Name = "tmpCompleted";
            this.tmpCompleted.Size = new System.Drawing.Size(48, 24);
            this.tmpCompleted.TabIndex = 0;
            this.tmpCompleted.Text = "模板";
            this.tmpCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmpLabel
            // 
            this.tmpLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tmpLabel.Location = new System.Drawing.Point(6, 7);
            this.tmpLabel.Name = "tmpLabel";
            this.tmpLabel.Size = new System.Drawing.Size(212, 35);
            this.tmpLabel.TabIndex = 0;
            this.tmpLabel.Text = "模板";
            this.tmpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gcTimer
            // 
            this.gcTimer.Interval = 10000;
            this.gcTimer.Tick += new System.EventHandler(this.gcTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(298, 479);
            this.Controls.Add(this.scrollBarArea);
            this.Controls.Add(this.itemTemplate);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.tabPageBar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnFold);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dragger);
            this.Controls.Add(this.tblTaskContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scrollBarArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragger)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPageBar.ResumeLayout(false);
            this.itemTemplate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer renderTimer;
        private System.Windows.Forms.Panel tblTaskContainer;
        private System.Windows.Forms.PictureBox dragger;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnFold;
        private System.Windows.Forms.Panel tabPageBar;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel itemTemplate;
        private System.Windows.Forms.Button tmpButton;
        private System.Windows.Forms.Label tmpLabel;
        private System.Windows.Forms.PictureBox scrollBarArea;
        private System.Windows.Forms.Button btnCompleteFirst;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label tmpCompleted;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer gcTimer;
    }
}

