using System;
using Microsoft.Xna.Framework;
using TotD.Entities;

namespace TotD.Commands
{
    // Contains all ggeneric actions performed on entities and tiles.
    class CommandManager
    {
        public CommandManager()
        {

        }

        // Move the actor BY +/- X&Y coordinates, returns false if unable to move.

        public bool MoveActorBy(Actor actor, Point position)
        {
            return actor.MoveBy(position);
        }

    }
}
