using System;
using Microsoft.Xna.Framework;
using SadConsole;

namespace TotD
{ 
    public abstract class TileBase : Cell
    {

        // Movement and LoS flags
        public bool IsBlockingMove;
        public bool IsBlockingLoS;

        // Tile's name
        protected string Name;

        // Every TileBase has a Foreground Colour, Background Colour, and Glyph.
        // IsBlockingMove and IsBlockingLoS are optional, set to false by default.
        public TileBase(Color foreground, Color background, int glyph, bool blockingMove=false, bool blockingLoS=false, String name="") :
            base(foreground, background, glyph)
        {
            IsBlockingMove = blockingMove;
            IsBlockingLoS = blockingLoS;
            Name = name;
        }
    }
}
