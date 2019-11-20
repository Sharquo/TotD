using System;
using Microsoft.Xna.Framework;
using System.Linq;
using TotD.Entities;

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

        public GoRogue.MultiSpatialMap<Entity> Entities; // This keeps track of all entities on the map.
        public static GoRogue.IDGenerator IDGenerator = new GoRogue.IDGenerator(); // An IDGenerator that all Entities can access.

        //Build a new map with a specified width and height.
        public Map(int width, int height)
        {
            _width = width;
            _height = height;
            Tiles = new TileBase[width * height];
            Entities = new GoRogue.MultiSpatialMap<Entity>();
        }

        public bool IsTileWalkable(Point location)
        {
            // Make sure the actor is not trying to move off the map limits.
            if (location.X < 0 || location.Y < 0 || location.X >= Width || location.Y >= Height)
                return false;
            return !_tiles[location.Y * Width + location.X].IsBlockingMove;
        }

        // Checks whether a certain type of entity is at a specified location.
        public T GetEntityAt<T>(Point location) where T : Entity
        {
            return Entities.GetItems(location).OfType<T>().FirstOrDefault();
        }

        // Removes an Entity ffrom the MultiSpatialMap.
        public void Remove(Entity entity)
        {
            Entities.Remove(entity);

            // Link up the entity's Moved event to a new handler.
            entity.Moved -= OnEntityMoved;
        }

        // Adds an Entity to the MultiSpatialMap.
        public void Add(Entity entity)
        {
            Entities.Add(entity, entity.Position);

            entity.Moved += OnEntityMoved;
        }

        private void OnEntityMoved(object sender, Entity.EntityMovedEventArgs args)
        {
            Entities.Move(args.Entity as Entity, args.Entity.Position);
        }

    }
}