using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using MyGame.Window;
using MyGame.GameEntities;
using MyGame.Window.GUI;
using MyGame.Entities;

namespace MyGame.GameScenes {
    public class MainMenu : Scene {
        private Label titleLbl;
        private Button playBtn;
        private Button quitBtn;
        public MainMenu(SceneTree tree) : base(tree) {
            titleLbl = new Label("Rpg Game", new Vector2f(430, 50));
            playBtn = new Button("Play", new Vector2f(430, 150));
            quitBtn = new Button("Quit", new Vector2f(430, 250));
        }

        public override void Update(float delta) {
            quitBtn.Trigger(() => {
                GetTree().Quit();
            });
            playBtn.Trigger(() => {
                GetTree().SetScene("main", new GameScene(GetTree()));
            });
        }

        public override void Draw(RenderWindow window) {
            titleLbl.Draw(window);
            playBtn.Draw(window);
            quitBtn.Draw(window);
        }
    }
}