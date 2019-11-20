using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using SadConsole.Components;
using Microsoft.Xna.Framework.Graphics;
using TotD.UserInterface;
using TotD.Commands;

namespace TotD
{
    class GameLoop
    {

        public const int GameWidth = 80;
        public const int GameHeight = 25;

        // Managers.
        public static UIManager UIManager;
        public static World World;
        public static CommandManager CommandManager;

        static void Main(string[] args)
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create("Fonts/C64.font", GameWidth, GameHeight);

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

        }

        private static void Init()
        {
            // Instantiate the UIManager.
            UIManager = new UIManager();

            // Build the world.
            World = new World();

            // Create consoles to use the World data.
            UIManager.Init();

            // Instantiate a new CommandManager.
            CommandManager = new CommandManager();
        }
    }
}
