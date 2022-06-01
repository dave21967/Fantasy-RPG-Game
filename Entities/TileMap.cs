using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace MyGame.Entities {
    public class TileMap : GameObject {
        private string[] lines;
        private List<Tile> tiles;
        private List<Tile> colliders;
        public Action OnReady;

        public TileMap(string fileName) : base("TileMap") {
            lines = File.ReadAllLines(fileName);
            tiles = new List<Tile>();
            colliders = new List<Tile>();
        }

        public void Ready() {
            OnReady();
        }

        public void AddTile(Tile t) {
            tiles.Add(t);
        }

        public void AddCollider(Tile t) {
            colliders.Add(t);
        }

        public char GetMatrix(int x, int y) {
            return lines[x][y];
        }

        public int GetMapSize() {
            return lines.Length;
        }

        public int GetLineSize(int index) {
            return lines[index].Length;
        }

        public List<Tile> GetColliders() {
            return colliders;
        }

        public void Draw(RenderWindow window) {
            if(IsVisible()) {
                foreach(Tile t in tiles)
                    t.Draw(window);
                foreach(Tile coll in colliders)
                    coll.Draw(window);
            }
        }
    }
}