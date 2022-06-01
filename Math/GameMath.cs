using System;

namespace MyGame.Math {
    public class GameMath {
        public static float Lerp(float from, float to, float by) {
            return from * (1-by) + to * by;
        }
    }
}