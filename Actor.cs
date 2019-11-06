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
    }
}
