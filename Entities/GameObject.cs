using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace MyGame.Entities {
    public class GameObject {
        private string name;
        private bool visible;

        public GameObject(string name) {
            this.name = name;
            visible = true;
        }

        public void SetName(string n) {
            name = n;
        }

        public string GetName() {
            return name;
        }

        public void Show() {
            visible = true;
        }

        public void Hide() {
            visible = false;
        }

        public bool IsVisible() {
            return visible;
        }
    }
}