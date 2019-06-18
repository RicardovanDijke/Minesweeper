using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Models
{
    public enum TileType
    {
        Blank,
        Grass,
        Numbered,
        Bomb
    }

    public class Tile
    {
        public int X { get;  }
        public int Y { get; }

        public TileType RealType;
        public Bitmap RealImage { get; set; }

        public TileType ShownType;
        public Bitmap ShownImage { get; set; }

        public int AdjacentBombs { get; set; }

        public Tile(int x, int y, TileType type, Bitmap image)
        {
            X = x;
            Y = y;
            RealType = type;
            RealImage = image;

            ShownType = type;
            ShownImage = image;
        }
    }
}
