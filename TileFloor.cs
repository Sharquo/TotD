using System;
using Microsoft.Xna.Framework;

namespace TotD
{
    // TileFloor is based on TileBase.
    // Floor tiles to be used in maps.
    public class TileFloor : TileBase
    {
        // Default constructor.
        // Floors are set to allow movement and line of sight by default.
        public TileFloor(bool blocksMovement = false, bool blocksLoS = false) : base(Color.DarkGray, Color.Transparent, '.', blocksMovement, blocksLoS)
        {
            Name = "Floor";
        }
    }
}