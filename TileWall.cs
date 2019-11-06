using System;
using Microsoft.Xna.Framework;

namespace TotD
{
    //  TileWall is base on TileBase
    public class TileWall : TileBase
    {
        // Default constructor
        // Walls are set to block movement and line of sight by default.
        public TileWall(bool blocksMovement=true, bool blocksLoS=true) : base(Color.LightGray, Color.Transparent, '#', blocksMovement, blocksLoS)
        {
            Name = "Wall";
        }
    }
}
