using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace MyGame.Window {
    public class Scene {
        private SceneTree tree;

        public Scene(SceneTree sceneTree) {
            tree = sceneTree;
        }

        public virtual void Update(float delta) {

        }

        public virtual void OnMouseButtonPressed(RenderWindow win) {

        }

        public virtual void OnMouseButtonReleased(RenderWindow win) {
            
        }

        public virtual void Draw(RenderWindow window) {
            
        }

        public SceneTree GetTree() {
            return tree;
        }
    }
}