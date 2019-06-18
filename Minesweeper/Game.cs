using System;

using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Game : Form
    {
        private Minesweeper minesweeper;


        public Game()
        {
            InitializeComponent();
           // minesweeper = new Minesweeper((int)nudSize.Value);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (minesweeper == null)
            {
                return;
            }
            Graphics g = e.Graphics;
            for (int x = 0; x < minesweeper.Map.GetLength(0); x++)
            {
                for (int y = 0; y < minesweeper.Map.GetLength(1); y++)
                {
                    g.DrawImage(minesweeper.Map[x, y].RealImage, x * 16, y * 16);
                }
            }
        }

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 16;
            int y = e.Y / 16;
            Console.WriteLine(x + "," + y);

            minesweeper.TileClicked(x, y);
            panel1.Refresh();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            minesweeper = new Minesweeper((int)nudSize.Value);
            panel1.Refresh();
        }
    }
}
