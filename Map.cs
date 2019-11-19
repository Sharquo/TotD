using System;
using Microsoft.Xna.Framework;

namespace TotD
{
    public class Map
    {
        TileBase[] _tiles;
        private int _width;
        private int _height;

        public TileBase[] Tiles { get { return _tiles; } set { _tiles = value; } }
        public int Width { get { return _width; } set { _width = value; } }
        public int Height { get { return _height; } set { _height = value; } }

        //Build a new map with a specified width and height.
        public Map(int width, int height)
        {
            _width = width;
            _height = height;
            Tiles = new TileBase[width * height];
        }

        public bool IsTileWalkable(Point location)
        {
            // Make sure the actor is not trying to move off the map limits.
            if (location.X < 0 || location.Y < 0 || location.X >= Width || location.Y >= Height)
                return false;
            return !_tiles[location.Y * Width + location.X].IsBlockingMove;
        }
    }
}