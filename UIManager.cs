using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Controls;
using System;

namespace TotD
{
    // Creates, holds, and destroys all consoles used in the game.
    public class UIManager : ContainerConsole
    {
        public ScrollingConsole MapConsole;

        public Window MapWindow;

        public UIManager()
        {
            IsVisible = true;
            IsFocused = true;

            Parent = SadConsole.Global.CurrentScreen;
        }

        // Creates all child consoles to be managed.
        public void CreateConsoles()
        {
            MapConsole = new SadConsole.ScrollingConsole(GameLoop.World.CurrentMap.Width, GameLoop.World.CurrentMap.Height, Global.FontDefault,
                new Rectangle(0, 0, GameLoop.GameWidth, GameLoop.GameHeight), GameLoop.World.CurrentMap.Tiles);
        }

        // Creates a window that encloses a map console.
        public void CreateMapWindow(int width, int height, string title)
        {
            MapWindow = new Window(width, height);
            MapWindow.CanDrag = true;

            // Make console short enough to show the window title and borders.
            int mapConsoleWidth = width - 2;
            int mapConsoleHeight = height - 2;

            // Resize MapConsole's ViewPort to fit inside the borders.
            MapConsole.ViewPort = new Rectangle(0, 0, mapConsoleWidth, mapConsoleHeight);

            // Reposition MapConsole so it doesn't overlap with the window edges.
            MapConsole.Position = new Point(1, 1);

            // Close window button.
            Button closeButton = new Button(3, 1);
            closeButton.Position = new Point(0, 0);
            closeButton.Text = "[X]";

            // Add the close button to the list of UI elements.
            MapWindow.Add(closeButton);

            // Justify the title at the top of the window.
            MapWindow.Title = title.Align(HorizontalAlignment.Center, mapConsoleWidth);

            // Add the map viewer to the window.
            MapWindow.Children.Add(MapConsole);

            // The MapWindow becomes a child console of the UIManager.
            Children.Add(MapWindow);

            // Add the player to the MapConsole's render list.
            MapConsole.Children.Add(GameLoop.World.Player);

            MapWindow.Show();
        }

        // Initializes all windows and consoles.
        public void Init()
        {
            CreateConsoles();
            CreateMapWindow(GameLoop.GameWidth / 2, GameLoop.GameHeight / 2, "Game Map");
        }

        // This centres the viewport camera on an actor.
        public void CenterOnActor(Actor actor)
        {
            MapConsole.CenterViewPortOnPoint(actor.Position);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            // Called each logic update.
            CheckKeyboard();
            base.Update(timeElapsed);
        }

        private void CheckKeyboard()
        {
            // As an example, we'll use the F5 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }

            // Keyboard movement for the player character: North
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D8))
            {
                GameLoop.World.Player.MoveBy(new Point(0, -1));
                CenterOnActor(GameLoop.World.Player);
            }
            // Keyboard movement for the player character: Northeast
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D9))
            {
                GameLoop.World.Player.MoveBy(new Point(1, -1));
                CenterOnActor(GameLoop.World.Player);
            }
            // Keyboard movement for the player character: East
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D6))
            {
                GameLoop.World.Player.MoveBy(new Point(1, 0));
                CenterOnActor(GameLoop.World.Player);
            }
            // Keyboard movement for the player character: Southeast
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D3))
            {
                GameLoop.World.Player.MoveBy(new Point(1, 1));
                CenterOnActor(GameLoop.World.Player);
            }
            // Keyboard movement for the player character: South
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                GameLoop.World.Player.MoveBy(new Point(0, 1));
                CenterOnActor(GameLoop.World.Player);
            }
            // Keyboard movement for the player character: Southwest
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D1))
            {
                GameLoop.World.Player.MoveBy(new Point(-1, 1));
                CenterOnActor(GameLoop.World.Player);
            }
            // Keyboard movement for the player character: West
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D4))
            {
                GameLoop.World.Player.MoveBy(new Point(-1, 0));
                CenterOnActor(GameLoop.World.Player);
            }
            // Keyboard movement for the player character: Northwest
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D7))
            {
                GameLoop.World.Player.MoveBy(new Point(-1, -1));
                CenterOnActor(GameLoop.World.Player);
            }
        }
    }
}
