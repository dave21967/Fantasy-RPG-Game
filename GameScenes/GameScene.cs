using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using MyGame.Entities;
using MyGame.Window;
using MyGame.GameEntities;

namespace MyGame.GameScenes {
    public class GameScene : Scene {
        private Player player;
        private TileMap map;
        public GameScene(SceneTree tree) : base(tree) {
            player = new Player(new Vector2f(200,50));
            map = new TileMap("Assets/Tilemaps/map1.txt");
            map.OnReady += () => {
                for(int i=0;i<map.GetMapSize();i++) {
                    for(int j=0;j<map.GetLineSize(i);j++) {
                        switch(map.GetMatrix(i,j)) {
                            case '1':
                                map.AddTile(new Tile("Assets/Sprites/tileset.png", new IntRect(0,0,32,32), new Vector2f(j*32, i*32)));
                            break;
                            case '2':
                                map.AddCollider(new Tile("Assets/Sprites/tileset.png", new IntRect(32,0,32,32), new Vector2f(j*32, i*32)));
                            break;
                            case '3':
                                map.AddCollider(new Tile("Assets/Sprites/tileset.png", new IntRect(64,0,32,32), new Vector2f(j*32, i*32)));
                            break;
                            case '4':
                                map.AddCollider(new Tile("Assets/Sprites/tileset.png", new IntRect(0,32,32,32), new Vector2f(j*32, i*32)));
                            break;
                            case '5':
                                map.AddCollider(new Tile("Assets/Sprites/tileset.png", new IntRect(32,32,32,32), new Vector2f(j*32, i*32)));
                            break;
                            case '6':
                                map.AddCollider(new Tile("Assets/Sprites/tileset.png", new IntRect(64,32,32,32), new Vector2f(j*32, i*32)));
                            break;
                            case '7':
                                map.AddCollider(new Tile("Assets/Sprites/tileset.png", new IntRect(0,64,32,32), new Vector2f(j*32, i*32)));
                            break;
                            case '8':
                                map.AddCollider(new Tile("Assets/Sprites/tileset.png", new IntRect(32,64,32,32), new Vector2f(j*32, i*32)));
                            break;
                            case '9':
                                map.AddCollider(new Tile("Assets/Sprites/tileset.png", new IntRect(64,64,32,32), new Vector2f(j*32, i*32)));
                            break;
                        }
                    }
                }
            };
            map.Ready();
        }

        public override void Update(float delta) {
            player.Update(delta);
            player.Collision(map.GetColliders());
            GetTree().SetCamera(player.GetCamera());
        }

        public override void Draw(RenderWindow window) {
            map.Draw(window);
            player.Draw(window);
        }
    }
}