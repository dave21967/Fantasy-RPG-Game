using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace MyGame.Window {
    public class Input {
        public static Vector2f GetAxis(string axis) {
            Vector2f input = new Vector2f(0,0);
            if(axis == "X") {
                if(Keyboard.IsKeyPressed(Keyboard.Key.A))
                    input.X = -1f;
                else if(Keyboard.IsKeyPressed(Keyboard.Key.D))
                    input.X = 1f;
                else
                    input.X = 0f;
            }
            else if(axis == "Y") {
                if(Keyboard.IsKeyPressed(Keyboard.Key.W))
                    input.Y = -1f;
                else if(Keyboard.IsKeyPressed(Keyboard.Key.S))
                    input.Y = 1f;
                else
                    input.Y = 0f;
            }
            return input;
        }

        public static bool GetKeyDown(Keyboard.Key key) {
            return Keyboard.IsKeyPressed(key);
        }
    }
}