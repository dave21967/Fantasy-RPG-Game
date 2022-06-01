using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using MyGame.Entities;

namespace MyGame.Window.GUI {
    public class Button : GameObject {
        private Text txt;
        private Font font;
        private Color color;
        private Color hoverColor;
        private bool clicked;
        public Button(string data, Vector2f pos) : base("Button") {
            font = new Font("Assets/Fonts/Pixeled.ttf");
            txt = new Text(data, font);
            txt.Position = pos;
            color = Color.White;
            hoverColor = Color.Red;
            clicked = false;
        }

        public void SetColor(Color c) {
            color = c;
        }

        public void SetHoverColor(Color hc) {
            hoverColor = hc;
        }

        public void Trigger(Action callBack) {
            if(clicked)
                callBack();
        }

        public void Draw(RenderWindow window) {
            if(IsVisible()) {
                Vector2i mousePos = Mouse.GetPosition(window);
                if(txt.GetGlobalBounds().Contains(mousePos.X, mousePos.Y))
                    txt.FillColor = hoverColor;
                else
                    txt.FillColor = color;
                if(txt.GetGlobalBounds().Contains(mousePos.X, mousePos.Y) && Mouse.IsButtonPressed(Mouse.Button.Left))
                    clicked = true;
                else
                    clicked = false;
                window.Draw(txt);
            }
        }
    }
}