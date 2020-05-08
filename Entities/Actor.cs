using System;
using Microsoft.Xna.Framework;

namespace TotD.Entities
{
    public abstract class Actor : Entity
    {
        public int Health { get; set; } // Current health
        public int MaxHealth { get; set; } // Maximum health
        public int Attack { get; set; } // Attack strength
        public int AttackChance { get; set; } // Percent chance of successful hit
        public int Defense { get; set; } // Defensive strength
        public int DefenseChance { get; set; } // Percent chance of successfully blocking a hit
        public int Gold { get; set; } // Amount of gold carried

        protected Actor(Color foreground, Color background, int glyph, int width = 1, int height = 1) : base(foreground, background, width, height, glyph)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

        // Moves the actor by positionChange tiles in any X/Y direction.
        public bool MoveBy(Point positionChange)
        {
            // Check the current map if we can move to this new position.
            if (GameLoop.World.CurrentMap.IsTileWalkable(Position + positionChange))
            {
                // If there's a monster here do a bump attack.
                Monster monster = GameLoop.World.CurrentMap.GetEntityAt<Monster>(Position + positionChange);
                if (monster != null)
                {
                    GameLoop.CommandManager.Attack(this, monster);
                    return true;
                }

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
