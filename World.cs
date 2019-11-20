using System;
using SadConsole.Components;
using Microsoft.Xna.Framework;
using TotD.Entities;

namespace TotD
{
    // All game state data is stored in World.
    public class World
    {
        // Map data.
        private int _mapWidth = 100;
        private int _mapHeight = 100;
        private  int _maxRooms = 100;
        private  int _minRoomSize = 4;
        private  int _maxRoomSize = 15;

        TileBase[] _mapTiles;

        public Map CurrentMap { get; set; }

        // Player data.
        public Player Player { get; set; }

        // Creates a new game world.
        public World()
        {
            // Build a map.
            CreateMap();

            // Spawn an isntance of Player.
            CreatePlayer();
        }

        // Create a new map using the Map class and a map generator.
        private void CreateMap()
        {
            _mapTiles = new TileBase[_mapWidth * _mapHeight];
            CurrentMap = new Map(_mapWidth, _mapHeight);
            MapGenerator mapGen = new MapGenerator();
            CurrentMap = mapGen.GenerateMap(_mapWidth, _mapHeight, _maxRooms, _minRoomSize, _maxRoomSize);
        }

        // Create a player using the Player class and set its starting position.
        private void CreatePlayer()
        {
            Player = new Player(Color.Yellow, Color.Transparent);

            // Place the player on the first non-movement-blocking tile on the map.
            for (int i = 0; i < CurrentMap.Tiles.Length; i++)
            {
                if (!CurrentMap.Tiles[i].IsBlockingMove)
                {
                    // Set the player's position to the index of the current map position.
                    Player.Position = SadConsole.Helpers.GetPointFromIndex(i, CurrentMap.Width);
                }
            }
            // Add the ViewPort sync component to the player entity.
            Player.Components.Add(new EntityViewSyncComponent());
        }
    }
}
