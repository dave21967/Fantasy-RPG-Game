using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace MyGame.Entities {
    public class Tile : Entity {
        private Texture texture;
        private Sprite body;
        public Tile(string texture, Vector2f pos) : base("Tile") {
            this.texture = new Texture(texture);
            body = new Sprite(this.texture);
            body.Position = pos;
        }

        public Tile(string texture, IntRect txtRect, Vector2f pos) : base("Tile") {
            this.texture = new Texture(texture);
            body = new Sprite(this.texture);
            body.TextureRect = txtRect;
            body.Position = pos;
        }

        public Vector2f GetPosition() {
            return body.Position;
        }

        public FloatRect GetCollisionBox() {
            return body.GetGlobalBounds();
        }

        public void Draw(RenderWindow win) {
            if(IsVisible())
                win.Draw(body);
        }
    }
}