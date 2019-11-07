using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TotD
{
    class GameLoop
    {

        public const int Width = 80;
        public const int Height = 25;

        private static Player player;

        private static TileBase[] _tiles; // An array of TileBase that contains all the tiles for a map
        private const int _roomWidth = 10;
        private const int _roomHeight = 20;

        static void Main(string[] args)
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create(Width, Height);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;

            // Start the game.
            SadConsole.Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //

            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime time)
        {
            // Called each logic update.
            CheckKeyboard();
        }

        private static void Init()
        {
            // Build the room's walls then place floors.
            CreateWalls();
            CreateFloors();

            Console startingConsole = new ScrollingConsole(Width, Height, Global.FontDefault, new Rectangle(0, 0, Width, Height), _tiles);

            // Set our new console as the thing to render and process
            SadConsole.Global.CurrentScreen = startingConsole;

            startingConsole.Print(6, 5, "Hello world!", ColorAnsi.CyanBright);

            // Create an instance of the player
            CreatePlayer();

            // Add the player Entity to our only console.
            startingConsole.Children.Add(player);
        }

        // Create a player using Sadconsole's Entity class.
        private static void CreatePlayer()
        {
            player = new Player(Color.Yellow, Color.Transparent);
            player.Position = new Point(20, 10);
        }

        private static void CreateFloors()
        {
            // Create a rectangle of floors in the tile array.
            for (int x = 0; x < _roomWidth; x++)
            {
                for (int y = 0; y < _roomHeight; y++)
                {
                    // Calculates the appropriate index in the array based on the y of tile, width of map, and x of tile.                          
                    _tiles[y * Width + x] = new TileFloor();
                }
            }
        }

        private static void CreateWalls()
        {
            // Create an empty array of tiles that is equal to the map size
            _tiles = new TileBase[Width * Height];

            //Fill the entire tile array with floors
            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new TileWall();
            }
        }

        private static void CheckKeyboard()
        {
            // As an example, we'll use the F5 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }

            // Keyboard movement for the player character: North
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D8))
            {
                player.MoveBy(new Point(0, -1));
            }
            // Keyboard movement for the player character: Northeast
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D9))
            {
                player.MoveBy(new Point(1, -1));
            }
            // Keyboard movement for the player character: East
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D6))
            {
                player.MoveBy(new Point(1, 0));
            }
            // Keyboard movement for the player character: Southeast
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D3))
            {
                player.MoveBy(new Point(1, 1));
            }
            // Keyboard movement for the player character: South
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                player.MoveBy(new Point(0, 1));
            }
            // Keyboard movement for the player character: Southwest
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D1))
            {
                player.MoveBy(new Point(-1, 1));
            }
            // Keyboard movement for the player character: West
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D4))
            {
                player.MoveBy(new Point(-1, 0));
            }
            // Keyboard movement for the player character: Northwest
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D7))
            {
                player.MoveBy(new Point(-1, -1));
            }
        }

        public static bool IsTileWalkable(Point location)
        {
            // Make sure the actor is not trying to move off the map limits.
            if (location.X < 0 || location.Y < 0 || location.X >= Width || location.Y >= Height)
                return false;
            return !_tiles[location.Y * Width + location.X].IsBlockingMove;
        }
    }
}
