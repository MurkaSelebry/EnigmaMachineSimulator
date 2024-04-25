using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Forms = System.Windows.Forms;


namespace Enigma2
{

    public class Plugboard : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Dictionary<char, char> replace = new Dictionary<char, char>();
        public static MouseState mouseOne, mouseTwo;

        public Plugboard()
        {
            Forms.Form frmXNA = (Forms.Form)Forms.Form.FromHandle(this.Window.Handle);
            frmXNA.FormClosing += (o, e) =>
            {
                frmXNA.Opacity = 0;
                e.Cancel = true;
            };
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
        }
        protected override void Draw(GameTime gameTime)
        {
        }
    }
}
