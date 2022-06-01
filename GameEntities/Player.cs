using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using MyGame.Entities;
using MyGame.Window;

namespace MyGame.GameEntities {
    public class Player : Entity {
        private RectangleShape body;
        private Vector2f velocity;
        private View camera;
        public Player(Vector2f pos) : base("player") {
            body = new RectangleShape(new Vector2f(32, 32));
            body.Position = pos;
            velocity = new Vector2f(0,0);
            camera = new View(new FloatRect(body.Position.X, body.Position.X, 450, 250));
        }

        public View GetCamera() {
            return camera;
        }

        public FloatRect GetCollisionBox() {
            return body.GetGlobalBounds();
        }

        public void Move(float moveX, float moveY) {
            velocity = new Vector2f(moveX, moveY);
            body.Position += velocity;
        }

        public void Collision(List<Tile> colliders) {
            foreach(Tile coll in colliders) {
                if(body.GetGlobalBounds().Intersects(coll.GetCollisionBox())) {
                    if(velocity.X > 0) {
                        if(body.GetGlobalBounds().Left+body.GetGlobalBounds().Width > coll.GetCollisionBox().Left 
                        && body.GetGlobalBounds().Left < coll.GetCollisionBox().Left+coll.GetCollisionBox().Width) {
                            body.Position = new Vector2f(coll.GetPosition().X-coll.GetCollisionBox().Width, body.Position.Y);
                        }
                    }
                    else if(velocity.X < 0) {
                        if(body.GetGlobalBounds().Left > coll.GetCollisionBox().Left &&
                        body.GetGlobalBounds().Left < coll.GetCollisionBox().Left+coll.GetCollisionBox().Width) {
                            body.Position = new Vector2f(coll.GetPosition().X+body.GetGlobalBounds().Width, body.Position.Y);
                        }
                    }
                    else if(velocity.Y > 0) {
                        if(body.GetGlobalBounds().Top+body.GetGlobalBounds().Height > coll.GetCollisionBox().Top
                        && body.GetGlobalBounds().Top+body.GetGlobalBounds().Height < coll.GetCollisionBox().Top+body.GetGlobalBounds().Height) {
                            body.Position = new Vector2f(body.Position.X, coll.GetPosition().Y-coll.GetCollisionBox().Height);
                        }
                    }
                    else if(velocity.Y < 0) {
                        if(body.GetGlobalBounds().Top > coll.GetCollisionBox().Top &&
                        body.GetGlobalBounds().Top < coll.GetCollisionBox().Top+coll.GetCollisionBox().Height) {
                            body.Position = new Vector2f(body.Position.X, coll.GetPosition().Y+body.GetGlobalBounds().Height);
                        }
                    }
                }
            }
        }

        public void Update(float delta) {
            if(Input.GetKeyDown(Keyboard.Key.W))
                velocity.Y = -1f * delta;
            else if(Input.GetKeyDown(Keyboard.Key.S))
                velocity.Y = 1f * delta;
            else if(Input.GetKeyDown(Keyboard.Key.A))
                velocity.X = -1f * delta;
            else if(Input.GetKeyDown(Keyboard.Key.D))
                velocity.X = 1f * delta;
            else {
                velocity = new Vector2f(0,0);
            }
            Move(velocity.X, velocity.Y);
            camera.Center = body.Position;
        }

        public void Draw(RenderWindow window) {
            if(IsVisible())
                window.Draw(body);
        }
    }
}