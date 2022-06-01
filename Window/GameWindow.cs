using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using MyGame.Time;
using MyGame.GameScenes;

namespace MyGame.Window {
    public class GameWindow {
        private RenderWindow window;
        private Clock clock;
        private SceneTree tree;

        public GameWindow(string title, uint w, uint h) {
            window = new RenderWindow(new VideoMode(w,h), title);
            window.Closed += (sender, args) => {
                Quit();
            };
            clock = new Clock();
            tree = new SceneTree();
            tree.SetScene("main", new MainMenu(tree));
            window.MouseButtonPressed += (sender, args) => {
                tree["main"].OnMouseButtonPressed(window);
            };
            window.MouseButtonReleased += (sender, args) => {
                tree["main"].OnMouseButtonReleased(window);
            };
        }

        public void SetCamera(View camera) {
            window.SetView(camera);
        }

        public void Run() {
            tree.SetGameWindow(this);
            while(window.IsOpen) {
                GameTime.deltaTime = clock.Restart().AsMilliseconds();
                if(!tree.Pause)
                    tree["main"].Update(GameTime.deltaTime);
                window.DispatchEvents();
                window.Clear(Color.Black);
                tree["main"].Draw(window);
                window.Display();
            }
        }

        public void Quit() {
            window.Close();
        }
    }
}