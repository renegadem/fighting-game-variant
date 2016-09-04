using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PlatformerGame
{
    class Screen
    {
        Image image;
        Texture texture;
        Texture bgTex;
        Sprite bg;
        Sprite platform;

        Texture charTex;
        Sprite characterPlaceholder;


        public Screen()
        {
            image = new Image(700, 100, Color.White);
            bgTex = new Texture(new Image(@"C:\Users\balzernator\Documents\visual studio 2012\Projects\not console applicatoin 1\not console applicatoin 1\assets\bg.jpg"));
            bg = new Sprite(bgTex);
            texture = new Texture(image);
            platform = new Sprite(texture);
            platform.Position = new Vector2f(50, 400);
            charTex = new Texture(new Image(50, 100, Color.Red));
            characterPlaceholder = new Sprite(charTex);
            characterPlaceholder.Position = new Vector2f(100, 300);
        }

        public void update(RenderWindow rw, long elapsed)
        {
            Console.WriteLine("updating");
            Console.WriteLine(characterPlaceholder.Position);

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                characterPlaceholder.Position = new Vector2f(characterPlaceholder.Position.X - 5, characterPlaceholder.Position.Y);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                characterPlaceholder.Position = new Vector2f(characterPlaceholder.Position.X + 5, characterPlaceholder.Position.Y);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                characterPlaceholder.Position = new Vector2f(characterPlaceholder.Position.X, characterPlaceholder.Position.Y - 5);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                characterPlaceholder.Position = new Vector2f(characterPlaceholder.Position.X, characterPlaceholder.Position.Y + 5);
            }
            //characterPlaceholder.Position = new Vector2f(characterPlaceholder.Position.X + 1, characterPlaceholder.Position.Y);
        }

        public void draw(RenderWindow rw, long elapsed)
        {
            Console.WriteLine("drawing");
            rw.Clear(Color.Black);
            rw.Draw(bg);
            rw.Draw(platform);
            rw.Draw(characterPlaceholder);
            rw.Display();
        }
    }
}
