using MineSweeper.Logic;
using MineSweeper.Models;
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
        public Tile[,] Map { get; set; }

        private MapFunctions mapFunctions = new MapFunctions();

        private Bitmap bombTexture = new Bitmap(@"Textures/bomb.png");

        public Game()
        {
            InitializeComponent();
            Map = mapFunctions.GenerateMap(10);

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int x = 0; x < Map.GetLength(0); x++)
            {
                for (int y = 0; y < Map.GetLength(1); y++)
                {
                    g.DrawImage(Map[x, y].ShownImage, x * 16, y * 16);
                }
            }
        }

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 16;
            int y = e.Y / 16;
            Console.WriteLine(x + "," + y);

            Map[x, y].ShownImage = bombTexture;
            panel1.Refresh();

        }
    }
}
