using MineSweeper.Models;

using System;
using System.Drawing;

namespace MineSweeper.Logic
{
    public class MapFunctions
    {
        //Bitmap bomb1 = new Bitmap(@"Textures/1.png");
        //Bitmap bomb2 = new Bitmap(@"Textures/2.png");
        //Bitmap bomb3 = new Bitmap(@"Textures/3.png");
        //Bitmap bomb4 = new Bitmap(@"Textures/4.png");
        //Bitmap bomb5 = new Bitmap(@"Textures/5.png");
        //Bitmap bomb6 = new Bitmap(@"Textures/6.png");

        public Tile[,] GenerateEmptyMap(int size)
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

            return tiles;
        }

        public Tile[,] PopulateMap(Tile[,] tiles, double difficulty, Point clickedTile)
        {


            Random r = new Random();



            int size = tiles.GetLength(0);
            //replace 15% of tiles with bombs

            for (int i = 0; i < size * difficulty; i++)
            {
                int randomX;
                int randomY;
                do
                {
                    randomX = r.Next(0, size);
                    randomY = r.Next(0, size);
                }
                while (tiles[randomX, randomY].RealType == TileType.Bomb);

                tiles[randomX, randomY].RealType = TileType.Bomb;
                tiles[randomX, randomY].RealImage = new Bitmap(@"Textures/Bomb.png");
            }

            //check every tile for amount of adjacent bombs
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Tile current = tiles[x, y];

                    if (current.RealType == TileType.Bomb)
                    {
                        continue;
                    }

                    //8 directions bomb checking

                    int cX = current.X;
                    int cY = current.Y;

                    //-1,-1 top left
                    try
                    {
                        if (tiles[cX - 1, cY - 1].RealType == TileType.Bomb)
                        {
                            current.AdjacentBombs++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //ignore
                    }


                    //-1,0 left
                    try
                    {
                        if (tiles[cX - 1, cY].RealType == TileType.Bomb)
                        {
                            current.AdjacentBombs++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //ignore
                    }


                    //-1,1 bottom left
                    try
                    {
                        if (tiles[cX - 1, cY + 1].RealType == TileType.Bomb)
                        {
                            current.AdjacentBombs++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //ignore
                    }

                    //0,1 bottom
                    try
                    {
                        if (tiles[cX, cY + 1].RealType == TileType.Bomb)
                        {
                            current.AdjacentBombs++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //ignore
                    }

                    //1,1 bottom right
                    try
                    {
                        if (tiles[cX + 1, cY + 1].RealType == TileType.Bomb)
                        {
                            current.AdjacentBombs++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //ignore
                    }

                    //1,0 right
                    try
                    {
                        if (tiles[cX + 1, cY].RealType == TileType.Bomb)
                        {
                            current.AdjacentBombs++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //ignore
                    }

                    //1,-1 top right
                    try
                    {
                        if (tiles[cX + 1, cY - 1].RealType == TileType.Bomb)
                        {
                            current.AdjacentBombs++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //ignore
                    }


                    //0,-1 top
                    try
                    {
                        if (tiles[cX, cY - 1].RealType == TileType.Bomb)
                        {
                            current.AdjacentBombs++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //ignore
                    }
                }
            }

            //set the bomb numbers 
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (tiles[x, y].AdjacentBombs > 0)
                    {
                        tiles[x, y].RealType = TileType.Numbered;
                        string imagePath = @"Textures/" + tiles[x, y].AdjacentBombs + ".png";
                        Bitmap bombImage = new Bitmap(imagePath);
                        tiles[x, y].RealImage = bombImage;

                    }
                }
            }

            return tiles;
        }
    }
}
