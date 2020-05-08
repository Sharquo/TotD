using System;
using Microsoft.Xna.Framework;

namespace TotD.Entities
{
    // A generic monster capable of combat and interaction.
    public class Monster : Actor
    {
        public Monster (Color foreground, Color background) : base(foreground, background, 'M')
        {

        }
    }
}
