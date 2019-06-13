using MineSweeper.Logic;
using MineSweeper.Models;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Minesweeper
    {
        public Tile[,] Map { get; set; }
        private MapFunctions mapFunctions = new MapFunctions();

        private Bitmap bombTexture = new Bitmap(@"Textures/bomb.png");

        public Minesweeper(int size)
        {
            Map = mapFunctions.GenerateMap(size);
        }


        public void TileClicked(int x, int y)
        {
            Map[x, y].ShownImage = bombTexture;

        }
    }
}
