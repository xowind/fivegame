namespace FiveGame
{
    partial class fiveForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fiveForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.悔棋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.先手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电脑先手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.玩家先手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.难度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.困难ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中等ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.简单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameBoard = new System.Windows.Forms.Panel();
            this.runingStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.HistoryLBox = new System.Windows.Forms.ListBox();
            this.mainMenu.SuspendLayout();
            this.runingStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.选项ToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(680, 25);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // 新游戏ToolStripMenuItem
            // 
            this.新游戏ToolStripMenuItem.Name = "新游戏ToolStripMenuItem";
            this.新游戏ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.新游戏ToolStripMenuItem.Text = "新游戏";
            this.新游戏ToolStripMenuItem.Click += new System.EventHandler(this.新游戏ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.悔棋ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // 悔棋ToolStripMenuItem
            // 
            this.悔棋ToolStripMenuItem.Name = "悔棋ToolStripMenuItem";
            this.悔棋ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.悔棋ToolStripMenuItem.Text = "悔棋";
            this.悔棋ToolStripMenuItem.Click += new System.EventHandler(this.悔棋ToolStripMenuItem_Click);
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.先手ToolStripMenuItem,
            this.难度ToolStripMenuItem});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // 先手ToolStripMenuItem
            // 
            this.先手ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.电脑先手ToolStripMenuItem,
            this.玩家先手ToolStripMenuItem});
            this.先手ToolStripMenuItem.Name = "先手ToolStripMenuItem";
            this.先手ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.先手ToolStripMenuItem.Text = "先手";
            // 
            // 电脑先手ToolStripMenuItem
            // 
            this.电脑先手ToolStripMenuItem.Name = "电脑先手ToolStripMenuItem";
            this.电脑先手ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.电脑先手ToolStripMenuItem.Text = "电脑先手";
            this.电脑先手ToolStripMenuItem.Click += new System.EventHandler(this.电脑先手ToolStripMenuItem_Click);
            // 
            // 玩家先手ToolStripMenuItem
            // 
            this.玩家先手ToolStripMenuItem.Checked = true;
            this.玩家先手ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.玩家先手ToolStripMenuItem.Name = "玩家先手ToolStripMenuItem";
            this.玩家先手ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.玩家先手ToolStripMenuItem.Text = "玩家先手";
            this.玩家先手ToolStripMenuItem.Click += new System.EventHandler(this.玩家先手ToolStripMenuItem_Click);
            // 
            // 难度ToolStripMenuItem
            // 
            this.难度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.困难ToolStripMenuItem,
            this.中等ToolStripMenuItem,
            this.简单ToolStripMenuItem});
            this.难度ToolStripMenuItem.Name = "难度ToolStripMenuItem";
            this.难度ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.难度ToolStripMenuItem.Text = "难度";
            // 
            // 困难ToolStripMenuItem
            // 
            this.困难ToolStripMenuItem.Name = "困难ToolStripMenuItem";
            this.困难ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.困难ToolStripMenuItem.Text = "困难";
            this.困难ToolStripMenuItem.Click += new System.EventHandler(this.困难ToolStripMenuItem_Click);
            // 
            // 中等ToolStripMenuItem
            // 
            this.中等ToolStripMenuItem.Checked = true;
            this.中等ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.中等ToolStripMenuItem.Name = "中等ToolStripMenuItem";
            this.中等ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.中等ToolStripMenuItem.Text = "中等";
            this.中等ToolStripMenuItem.Click += new System.EventHandler(this.中等ToolStripMenuItem_Click);
            // 
            // 简单ToolStripMenuItem
            // 
            this.简单ToolStripMenuItem.Name = "简单ToolStripMenuItem";
            this.简单ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.简单ToolStripMenuItem.Text = "简单";
            this.简单ToolStripMenuItem.Click += new System.EventHandler(this.简单ToolStripMenuItem_Click);
            // 
            // gameBoard
            // 
            this.gameBoard.BackgroundImage = global::FiveGame.Properties.Resources.Board;
            this.gameBoard.Location = new System.Drawing.Point(2, 28);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(464, 464);
            this.gameBoard.TabIndex = 1;
            this.gameBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameBoard_MouseClick);
            // 
            // runingStatus
            // 
            this.runingStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.runingStatus.Location = new System.Drawing.Point(0, 490);
            this.runingStatus.Name = "runingStatus";
            this.runingStatus.Size = new System.Drawing.Size(680, 22);
            this.runingStatus.TabIndex = 2;
            this.runingStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel1.Text = "等待玩家下子....";
            // 
            // HistoryLBox
            // 
            this.HistoryLBox.FormattingEnabled = true;
            this.HistoryLBox.ItemHeight = 12;
            this.HistoryLBox.Location = new System.Drawing.Point(467, 28);
            this.HistoryLBox.Name = "HistoryLBox";
            this.HistoryLBox.Size = new System.Drawing.Size(212, 460);
            this.HistoryLBox.TabIndex = 3;
            // 
            // fiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(680, 512);
            this.Controls.Add(this.HistoryLBox);
            this.Controls.Add(this.runingStatus);
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "fiveForm";
            this.Text = "五子棋";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.runingStatus.ResumeLayout(false);
            this.runingStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 悔棋ToolStripMenuItem;
        private System.Windows.Forms.Panel gameBoard;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 先手ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 电脑先手ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 玩家先手ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 难度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 困难ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中等ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 简单ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip runingStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListBox HistoryLBox;

    }
}

