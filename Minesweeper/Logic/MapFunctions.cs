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

            //fill map with blank tiles
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    tiles[x, y] = new Tile(x, y, TileType.Blank, new Bitmap(@"Textures/Grass.png"));
                }
            }

            //replace 10% of tiles with bombs
            Random r = new Random();

            for (int i = 0; i < size; i++)
            {
                int randomX = -1;
                int randomY = -1;
                do
                {
                    randomX = r.Next(0, size);
                    randomY = r.Next(0, size);
                }
                while (tiles[randomX, randomY].RealType == TileType.Bomb);

                tiles[randomX, randomY].RealType = TileType.Bomb;
                tiles[randomX, randomY].ShownImage = new Bitmap(@"Textures/Bomb.png");
            }

            return tiles;
        }
    }
}
