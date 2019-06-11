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

        public Game()
        {
            InitializeComponent();
            Map = mapFunctions.GenerateMap(5);

        }

        private void Game_Paint(object sender, PaintEventArgs e)
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
    }
}
