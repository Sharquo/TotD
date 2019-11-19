using System;
using Microsoft.Xna.Framework;

namespace TotD
{
    public abstract class Actor : SadConsole.Entities.Entity
    {
        private int _health; // Current Health
        private int _maxHealth; // Maximum possible health

        public int Health { get { return _health; } set { _health = value; } }
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

        protected Actor(Color foreground, Color background, int glyph, int width = 1, int height = 1) : base(width, height)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

        // Moves the actor by positionChange tiles in any X/Y direction.
        public bool MoveBy(Point positionChange)
        {
            if (GameLoop.World.CurrentMap.IsTileWalkable(Position + positionChange))
            {
                Position += positionChange;
                return true;
            }
            else
                return false;
        }

        // Moves the Actor to newPosition location.
        public bool MoveTo(Point newPosition)
        {
            Position = newPosition;
            return true;
        }
    }
}
