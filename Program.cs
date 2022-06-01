using System;
using MyGame.Window;

namespace MyGame {
    public class Program {
        public static void Main(String[] args) {
            GameWindow window = new GameWindow("MyGame",1024, 608);
            window.Run();
        }
    }
}