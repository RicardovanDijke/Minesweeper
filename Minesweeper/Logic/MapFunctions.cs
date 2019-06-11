using MineSweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MineSweeper.Logic
{
    public class MapFunctions
    {
        public Tile[,] GenerateMap(int size)
        {
            Tile[,] tiles = new Tile[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    tiles[x, y] = new Tile(x, y, TileType.Blank, new Bitmap(@"Textures/Grass.png"));
                }
            }

            return tiles;
        }
    }
}
