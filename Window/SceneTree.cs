using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace MyGame.Window {
    public class SceneTree {
        private Dictionary<string, Scene> scenes;
        private GameWindow window;
        public bool Pause;

        public SceneTree() {
            scenes = new Dictionary<string, Scene>();
            Pause = false;
        }

        public void SetCamera(View view) {
            window.SetCamera(view);
        }

        public void SetGameWindow(GameWindow win) {
            window = win;
        }

        public void SetScene(string name, Scene s) {
            scenes[name] = s;
        }

        public void Quit() {
            window.Quit();
        }

        public Scene this[string name] {
            get => scenes[name];
        }
    }
}