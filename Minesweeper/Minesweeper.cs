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
        private bool emptyMap;
        private readonly MapFunctions mapFunctions = new MapFunctions();

        private Bitmap bombTexture = new Bitmap(@"Textures/bomb.png");

        public Minesweeper(int size)
        {
            Map = mapFunctions.GenerateEmptyMap(size);
            emptyMap = true;
        }


        public void TileClicked(int x, int y)
        {
            Map[x, y].ShownImage = bombTexture;

            if (emptyMap)
            {
                Map = mapFunctions.PopulateMap(Map, 1.5, new Point(x,y));
                emptyMap = false;
            }
        }
    }
}
