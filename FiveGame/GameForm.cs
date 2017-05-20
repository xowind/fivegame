using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiveGame
{
    public partial class fiveForm : Form
    {
        private FiveChess game;
        private PictureBox[][] chessmans;
        private int hardness=2;
        private bool AIFirst=false;
        private bool gameEnd = false;
        //private Point lastAi=new Point(-1,-1);
        //private Point lastUsr=new Point(-1,-1);
        private Stack<Point> history = new Stack<Point>();
        public fiveForm()
        {
            InitializeComponent();
            game = new FiveChess(hardness, AIFirst);
            chessmans =new PictureBox[15][];
            for(int i=0;i<15;i++)
                chessmans[i]=new PictureBox[15];
            this.gameBoard.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic).SetValue(gameBoard, true, null);

        }
        private void putChess(int x, int y, bool black)
        {
            if (chessmans[y][x]==null)
            {
                if (history.Count > 1)
                {
                    Point p = history.Pop();
                    chessCancelHint(history.Peek().Y, history.Peek().X);
                    history.Push(p);
                }
                history.Push(new Point(x, y));
                chessmans[y][x]=new PictureBox();
                chessmans[y][x].Location = new Point(x * 29 + 16, y * 29 + 16);
                chessmans[y][x].Size = new Size(29, 29);
                chessmans[y][x].BackColor = Color.Transparent;
                if (black)
                {
                    chessmans[y][x].Name = "Black";
                    chessmans[y][x].Image = global::FiveGame.Properties.Resources.Black;
                    this.HistoryLBox.Items.Add
                        (history.Count.ToString()+". Black->(" + y.ToString() + "," + x.ToString() + ") "+DateTime.Now.ToString());
                }
                else
                {
                    chessmans[y][x].Name = "White";
                    chessmans[y][x].Image = global::FiveGame.Properties.Resources.White;
                    this.HistoryLBox.Items.Add
                        (history.Count.ToString() + ". White->(" + y.ToString() + "," + x.ToString() + ") " + DateTime.Now.ToString());
                }
                chessHint(y, x);
                //if (AIFirst && black || !AIFirst && !black)
                //{
                //    if (lastAi.X >= 0)
                //        chessmans[lastAi.Y][lastAi.X].BackgroundImage =null;
                //    chessmans[y][x].BackgroundImage = global::FiveGame.Properties.Resources.AI;
                //    lastAi.X = x;
                //    lastAi.Y = y;
                //}
                //else
                //{
                //    if (lastUsr.X >= 0)
                //        chessmans[lastUsr.Y][lastUsr.X].BackgroundImage = null;
                //    chessmans[y][x].BackgroundImage = global::FiveGame.Properties.Resources.Usr;
                //    lastUsr.X = x;
                //    lastUsr.Y = y;
                //}
                this.gameBoard.Controls.Add(chessmans[y][x]);
                chessmans[y][x].Show();
            }
        }

        private void gameBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left&& !gameEnd){
                int x = (e.X - 14) / 29;
                x = x < 0 ? 0 : x;
                int y = (e.Y - 14) / 29;
                y = y < 0 ? 0 : y;
                putChess(x, y, !this.AIFirst);
                this.toolStripStatusLabel1.Text  = "电脑正在下子.....";
                this.gameBoard.MouseClick -=this.gameBoard_MouseClick;
                this.Refresh();
                int X,Y;
                int rc=game.playNext(out X, out Y, x, y);
                if (rc == -1)
                {
                    MessageBox.Show("你赢了");
                    this.gameEnd = true;
                    this.toolStripStatusLabel1.Text = "游戏结束.";
                }
                else if (rc == 1)
                {
                    putChess(X, Y, this.AIFirst);
                    MessageBox.Show("你输了");
                    this.gameEnd = true;
                    this.toolStripStatusLabel1.Text = "游戏结束.";
                }
                else
                {
                    putChess(X, Y, this.AIFirst);
                    this.toolStripStatusLabel1.Text = "等待玩家下子...";
                }
                this.gameBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameBoard_MouseClick);
            }
        }
        private void clearchess()
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    removeChess(i, j);
            //lastAi = new Point(-1, -1);
            //lastUsr = new Point(-1, -1);
            this.HistoryLBox.Items.Clear();
            this.history.Clear();
        }
        private void 新游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearchess();
            this.gameEnd = false;
            game = new FiveChess(hardness, AIFirst);
            int x, y;
            game.start(out x, out y);
            if (this.AIFirst)
                putChess(x, y, true);
            this.toolStripStatusLabel1.Text = "等待玩家下子...";
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 电脑先手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            电脑先手ToolStripMenuItem.Checked = true;
            玩家先手ToolStripMenuItem.Checked = false;
            this.AIFirst = true;
        }

        private void 玩家先手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            电脑先手ToolStripMenuItem.Checked = false;
            玩家先手ToolStripMenuItem.Checked = true;
            this.AIFirst = false;
        }

        private void 困难ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            困难ToolStripMenuItem.Checked = true;
            中等ToolStripMenuItem.Checked = false;
            简单ToolStripMenuItem.Checked = false;
            this.hardness = 3;
        }

        private void 中等ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            困难ToolStripMenuItem.Checked = false;
            中等ToolStripMenuItem.Checked = true;
            简单ToolStripMenuItem.Checked = false;
            this.hardness = 2;
        }

        private void 简单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            困难ToolStripMenuItem.Checked = false;
            中等ToolStripMenuItem.Checked = false;
            简单ToolStripMenuItem.Checked = true;
            this.hardness = 1;
        }

        private void removeChess(int i, int j)
        {
            if (chessmans[i][j] != null)
            {
                this.gameBoard.Controls.Remove(chessmans[i][j]);
                chessmans[i][j].Dispose();
                chessmans[i][j] = null;
            }
        }
        private void chessHint(int i, int j)
        {
            if (chessmans[i][j] != null)
            {
                bool black = chessmans[i][j].Name=="Black";
                if (AIFirst && black || !AIFirst && !black)
                    chessmans[i][j].BackgroundImage = global::FiveGame.Properties.Resources.AI;
                else
                    chessmans[i][j].BackgroundImage = global::FiveGame.Properties.Resources.Usr;
            }
        }

        private void chessCancelHint(int i, int j)
        {
            if (chessmans[i][j] != null)
            {
                chessmans[i][j].BackgroundImage = null;
            }
        }


        private void 悔棋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("举手不悔真君子!");
            if (history.Count >= 2 && !gameEnd)
            {
                game.rollback();
                Point p = history.Pop();
                removeChess(p.Y, p.X);
                p = history.Pop();
                removeChess(p.Y, p.X);
                p = history.Pop();
                chessHint(p.Y, p.X);
                chessHint(history.Peek().Y, history.Peek().X);
                history.Push(p);
                this.HistoryLBox.Items.RemoveAt(HistoryLBox.Items.Count - 1);
                this.HistoryLBox.Items.RemoveAt(HistoryLBox.Items.Count - 1);
            }
        }
    }
}
