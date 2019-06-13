using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Game : Form
    {
        public Minesweeper minesweeper;


        public Game()
        {
            InitializeComponent();
            minesweeper = new Minesweeper(10);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int x = 0; x < minesweeper.Map.GetLength(0); x++)
            {
                for (int y = 0; y < minesweeper.Map.GetLength(1); y++)
                {
                    g.DrawImage(minesweeper.Map[x, y].ShownImage, x * 16, y * 16);
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
    }
}
