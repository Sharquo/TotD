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

            // Spawn an instance of Player.
            CreatePlayer();

            // SPawn a bunch of monsters.
            CreateMonsters();
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
            Player.Components.Add(new EntityViewSyncComponent());

            // Place the player on the first non-movement-blocking tile on the map.
            for (int i = 0; i < CurrentMap.Tiles.Length; i++)
            {
                if (!CurrentMap.Tiles[i].IsBlockingMove)
                {
                    // Set the player's position to the index of the current map position.
                    Player.Position = SadConsole.Helpers.GetPointFromIndex(i, CurrentMap.Width);
                    break;
                }
            }

            CurrentMap.Add(Player);
        }

        // Create some random monsters with random attack and defense values and drop them all over the map in random places.
        private void CreateMonsters()
        {
            // The number of monsters to create.
            int numMonsters = 10;

            // random position generator
            Random rndNum = new Random();

            // Create several monsters and pick a random position on the map to place them.
            // Check if the placement spot is blocking and if it is, try a new position.
            for (int i = 0; i < numMonsters; i++)
            {
                int monsterPosition = 0;
                Monster newMonster = new Monster(Color.Blue, Color.Transparent);
                newMonster.Components.Add(new EntityViewSyncComponent());
                while (CurrentMap.Tiles[monsterPosition].IsBlockingMove)
                {
                    monsterPosition = rndNum.Next(0, CurrentMap.Width * CurrentMap.Height);
                }

                // Plug in some magic numbers for attack and defense values
                newMonster.Defense = rndNum.Next(0, 10);
                newMonster.DefenseChance = rndNum.Next(0, 50);
                newMonster.Attack = rndNum.Next(0, 10);
                newMonster.AttackChance = rndNum.Next(0, 50);
                newMonster.Name = "a common troll";

                // Set the monster's new position
                // Note: this fancy math will be replaced by a new helper method
                // in the next revision of SadConsole
                newMonster.Position = new Point(monsterPosition % CurrentMap.Width, monsterPosition / CurrentMap.Width);
                CurrentMap.Add(newMonster);
            }
        }

    }
}
