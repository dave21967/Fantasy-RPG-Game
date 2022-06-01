using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using MyGame.Entities;

namespace MyGame.Window.GUI {
    public class Label : GameObject {
        private Text text;
        private Font font;
        private Color color;

        public Label(string data, Vector2f pos) : base("Label") {
            font = new Font("Assets/Fonts/Pixeled.ttf");
            text = new Text(data, font);
            color = Color.White;
            text.Position = pos;
        }

        public void SetFont(Font f) {
            font = f;
        }

        public void Draw(RenderWindow window) {
            if(IsVisible())
                window.Draw(text);
        }
    }
}