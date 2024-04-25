using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Forms=System.Windows.Forms;
using System.Diagnostics;

namespace Enigma2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public sealed class GameMain : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public BaseEnigma enigma = new BaseEnigma();
        public SettingsForm formSettings;

        public static MouseState mouseOne, mouseTwo;
        public static KeyboardState keybOne, keybTwo;
        public static SpriteFont fontBase, fontMini, fontSpec, fontSpecMini;

        Color colorBack = Color.FromNonPremultiplied(55, 58, 65, 255);
        Color colorGray = Color.FromNonPremultiplied(97, 97, 97, 255);
        Texture2D textureBg, textureSymbol, textureLed, textureRotor, textureInfo, textureOut, textureBolt, textureLock, textureBack, textureText,
            texturePlug, textureActivePlug;
        Texture2D[] sliders = new Texture2D[2];
        int[] sliderPositions = new int[4];
        SoundEffect soundUp, soundDown, soundTick;

        float volume = 0.6f;
        public bool customReflector = false;
        public string reflector = "";
        bool showPlugboard = false; // TODO
        bool useM4 = false; // TODO
        bool isWait = false, isRemove = false;
        public Dictionary<char, char> replace;
        List<char> charset = new List<char>();

        const int WIDTH = 538;
        const int HEIGHT = 640;

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;
            this.Window.Title = "Enigma Simulator";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            fontBase = Content.Load<SpriteFont>("BaseFont");
            fontMini = Content.Load<SpriteFont>("MiniFont");
            fontSpec = Content.Load<SpriteFont>("SpecFont");
            fontSpecMini = Content.Load<SpriteFont>("SpecMiniFont");
            textureSymbol = Content.Load<Texture2D>("symbol");
            textureLed = Content.Load<Texture2D>("led");
            textureRotor = Content.Load<Texture2D>("rotor");
            textureInfo = Content.Load<Texture2D>("info");
            textureOut = Content.Load<Texture2D>("out");
            textureBolt = Content.Load<Texture2D>("bolt");
            textureLock = Content.Load<Texture2D>("lock");
            textureBack = Content.Load<Texture2D>("back");
            textureText = Content.Load<Texture2D>("text");
            textureBg = Content.Load<Texture2D>("bg");
            texturePlug = Content.Load<Texture2D>("plug");
            textureActivePlug = Content.Load<Texture2D>("aplug");
            sliders[0] = Content.Load<Texture2D>("slider0");
            sliders[1] = Content.Load<Texture2D>("slider1");
            soundUp = Content.Load<SoundEffect>("up");
            soundDown = Content.Load<SoundEffect>("down");
            soundTick = Content.Load<SoundEffect>("tick");

            sliderPositions[0] = 0;
            sliderPositions[1] = 0;
            sliderPositions[2] = 0;
            sliderPositions[3] = 0;

            reflector = BaseEnigma.reflectorB;
            //formSettings = new SettingsForm(this);
            replace = enigma.Replace;


            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseTwo = mouseOne;
            keybTwo = keybOne;

            mouseOne = Mouse.GetState();
            keybOne = Keyboard.GetState();

            if (isSend)
            {
                soundDown.Play(volume, 0, 0);

                int r1 = enigma.key[0], r2 = enigma.key[1], r3 = enigma.key[2];
                charSend = enigma.Encode(charCurrent, reflector);
                if (r1 != enigma.key[0])
                    sliderPositions[0] = sliderPositions[0] == 0 ? 1 : 0;
                if (r2 != enigma.key[1])
                    sliderPositions[1] = sliderPositions[1] == 0 ? 1 : 0;
                if (r3 != enigma.key[2])
                    sliderPositions[2] = sliderPositions[2] == 0 ? 1 : 0;
                /*if (message.Length == 22)
                    message = message.Remove(0, 1);*/
                message += charSend;
                isSend = false;
            }

            /*if (keybOne.IsKeyDown(Keys.Left))
                x -= 1;
            else if (keybOne.IsKeyDown(Keys.Right))
                x += 1;

            if (keybOne.IsKeyDown(Keys.Up))
                y -= 1;
            else if (keybOne.IsKeyDown(Keys.Down))
                y += 1;*/
            base.Update(gameTime);
        }


        int startX = 62;
        int startY = 468;
        int x = 0, y = 0;
        bool isSettings = true;

        public void SetSettings(Settings settings)
        {
            enigma.ring = settings.ring;
            enigma._rotors = settings.rotors;
            enigma.key = settings.key;
            enigma.Replace = replace = settings.replace;
            customReflector = settings.customReflector;
            reflector = settings.reflector;
            volume = settings.sound;
            useM4 = settings.useM4;
        }

        public void CloseSettings()
        {
            isSettings = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(colorBack);
            spriteBatch.Begin();

            spriteBatch.Draw(textureBg, Vector2.Zero, Color.White);

            if (showPlugboard)
            {
                drawPlugs();

                drawPlugboardButtonHide();

                //keybOne.GetPressedKeys
            }
            else
            {

                if (useM4)
                {
                    drawRotor(3, 120 - 60 - 27);
                    drawRotor(0, 120);
                    drawRotor(1, 120 + 60 + 27);
                    drawRotor(2, 120 + 120 + 27 + 27);
                }
                else
                {
                    drawRotor(0, 120);
                    drawRotor(1, 120 + 60 + 27);
                    drawRotor(2, 120 + 120 + 27 + 27);
                }

                spriteBatch.Draw(textureInfo, new Vector2(431, 10), Color.White);
                spriteBatch.Draw(textureOut, new Vector2(464, 99), Color.White); // 391 + (97 / 2) - 15

                drawSettings();

                drawInput();
                drawOutput();

                drawPlugboardButtonShow();

                drawText();
                //
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }

        void drawText()
        {
            spriteBatch.Draw(textureText, new Vector2(20, 20), Color.White);
            string msg = message;
            if(message.Length > 23)
                msg = message.Substring(message.Length - 22, 22);
            Vector2 tmp = fontSpecMini.MeasureString(msg);
            Vector2 position = new Vector2(40, 42);
            Rectangle pos = new Rectangle((int)position.X, (int)position.Y, (int)tmp.X, (int)tmp.Y);
            spriteBatch.DrawString(fontSpecMini, msg, position, Color.Black);
            if(pos.Contains(mouseOne.X, mouseOne.Y) && mouseOne.LeftButton == ButtonState.Pressed && mouseTwo.LeftButton == ButtonState.Released)
            {
                formSettings.Copy();
            }
        }

        void drawPlugboardButtonShow()
        {
            Rectangle position = new Rectangle(224, 620, 90, 20);
            
            if (position.Contains(mouseOne.X, mouseOne.Y) && mouseOne.LeftButton == ButtonState.Pressed && mouseTwo.LeftButton == ButtonState.Released)
            {
                showPlugboard = true;
                soundTick.Play(volume, 0, 0);
                this.Window.Title = "Enigma Simulator [Plugboard]";
                isSettings = false;
                formSettings.Hide();
                /*graphics.PreferredBackBufferHeight = HEIGHT - 400;
                graphics.ApplyChanges();*/
            }

            spriteBatch.Draw(textureBack, position, Color.White);
        }

        void drawPlugboardButtonHide()
        {
            Rectangle position = new Rectangle(314, 20, 90, 20);

            if (position.Contains(mouseOne.X + 90, mouseOne.Y + 20) && mouseOne.LeftButton == ButtonState.Pressed && mouseTwo.LeftButton == ButtonState.Released)
            {
                showPlugboard = false;
                soundTick.Play(volume, 0, 0);
                this.Window.Title = "Enigma Simulator";
                isSettings = true;
                /*graphics.PreferredBackBufferHeight = HEIGHT;
                graphics.ApplyChanges();*/
            }

            spriteBatch.Draw(textureBack, position, null, Color.White, 180 * MathHelper.Pi / 180, Vector2.Zero, SpriteEffects.None, 1);
        }

        void drawSettings()
        {
            Rectangle position = new Rectangle(425, 243, 35, 35);

            if (position.Contains(mouseOne.X, mouseOne.Y) && mouseOne.LeftButton == ButtonState.Pressed && mouseTwo.LeftButton == ButtonState.Released && isSettings)
            {
                isSettings = false;
                soundTick.Play(volume, 0, 0);
                formSettings.Show();
            }

            spriteBatch.Draw(textureBolt, new Vector2(400, 238), Color.White);
            spriteBatch.Draw(textureBolt, new Vector2(400 + 75, 238), Color.White);
            spriteBatch.Draw(textureLock, position, Color.White);
            spriteBatch.Draw(textureBolt, new Vector2(400, 278), Color.White);
            spriteBatch.Draw(textureBolt, new Vector2(400 + 75, 278), Color.White);
        }

        void drawRotor(int rotor, int xStart)
        {
            spriteBatch.Draw(textureRotor, new Vector2(xStart, 150), Color.White);
            char symbol = (char)(enigma.key[rotor] + 65);
            spriteBatch.DrawString(fontBase, symbol.ToString(), new Vector2(xStart + 18 + (symbol == 'I' ? 4 : 0), 206), Color.Black);

            Rectangle position = new Rectangle(xStart + 45 + (27 / 2), 150, 14, 116);
            Rectangle pos1 = new Rectangle(position.X, position.Y, position.Width, position.Height - 58);
            Rectangle pos2 = new Rectangle(position.X, position.Y + 58, position.Width, position.Height - 58);
            if (pos1.Contains(mouseOne.X, mouseOne.Y) && mouseOne.LeftButton == ButtonState.Pressed && mouseTwo.LeftButton == ButtonState.Released && isSettings)
            {
                enigma.BackAt(rotor);
                sliderPositions[rotor] = sliderPositions[rotor] == 0 ? 1 : 0;
                soundUp.Play(volume, 0, 0);
            }
            else if (pos2.Contains(mouseOne.X, mouseOne.Y) && mouseOne.LeftButton == ButtonState.Pressed && mouseTwo.LeftButton == ButtonState.Released && isSettings)
            {
                enigma.MoveAt(rotor);
                sliderPositions[rotor] = sliderPositions[rotor] == 0 ? 1 : 0;
                soundUp.Play(volume, 0, 0);
            }
            spriteBatch.Draw(sliders[sliderPositions[rotor]], position, Color.White);
        }

        void drawOutput()
        {
            int i = 0;
            foreach (var x in "QWERTZUIO")
            {
                drawLed(startX + 47 * i, startY - 150 - 10, x);
                i++;
            }

            i = 0;
            foreach (var x in "ASDFGHJK")
            {
                drawLed(startX + (47 / 2) + 1 + 47 * i, startY - 100 - 10, x);
                i++;
            }

            i = 0;
            foreach (var x in "PYXCVBNML")
            {
                drawLed(startX + 47 * i, startY - 50 - 10, x);
                i++;
            }
        }

        void drawInput()
        {
            int i = 0;
            foreach (var x in "QWERTZUIO")
            {
                drawButton(startX + 47 * i, startY, x);
                i++;
            }

            i = 0;
            foreach (var x in "ASDFGHJK")
            {
                drawButton(startX + (47 / 2) + 1 + 47 * i, startY + 50, x);
                i++;
            }

            i = 0;
            foreach (var x in "PYXCVBNML")
            {
                drawButton(startX + 47 * i, startY + 100, x);
                i++;
            }
        }

        bool isNumber = false;
        void drawPlugs()
        {
            int startY = HEIGHT - 410;
            int startX = 20;

            spriteBatch.DrawString(fontSpec, "Steckerbrett", new Vector2(100, 130), Color.White);
            string copy = "by A.Valko © 2015";
            Vector2 size = fontSpecMini.MeasureString(copy);
            Rectangle pos = new Rectangle((int)((WIDTH - size.X) / 2), HEIGHT - 22, (int)size.X, (int)size.Y);
            spriteBatch.DrawString(fontSpecMini, copy, new Vector2((WIDTH - size.X) / 2, HEIGHT - 22), Color.White);
            if(pos.Contains(mouseOne.X, mouseOne.Y) && mouseOne.LeftButton == ButtonState.Pressed && mouseTwo.LeftButton == ButtonState.Released)
            {
                Process.Start("https://vk.com/artemworld");
            }

            Rectangle pos1 = new Rectangle(6, 285, 18, 50), pos2 = new Rectangle(513, 285, 18, 50);
            spriteBatch.Draw(texturePlug, pos1, new Rectangle(0, 0, 18, 50), Color.White);
            spriteBatch.Draw(texturePlug, pos2, new Rectangle(0, 0, 18, 50), Color.White);

            if ((pos1.Contains(mouseOne.X, mouseOne.Y) || pos2.Contains(mouseOne.X, mouseOne.Y)) && mouseOne.LeftButton == ButtonState.Pressed && mouseTwo.LeftButton == ButtonState.Released)
                isNumber = !isNumber;

            char[] arr1, arr2, arr3;

            arr1 = "ABCDEFGHI".ToCharArray();
            arr2 = "JKLMNOPQ".ToCharArray();
            arr3 = "RSTUVWXYZ".ToCharArray();
            
            int i = 0;
            foreach (char c in arr1)
            {
                drawPlug(startX + 60 * i, startY, c);
                i++;
            }

            i = 0;
            foreach (char c in arr2)
            {
                drawPlug(startX + 31 + 60 * i, startY + 60, c);
                i++;
            }

            i = 0;
            foreach (char c in arr3)
            {
                drawPlug(startX + 60 * i, startY + 120, c);
                i++;
            }
        }

        char waitSymbol = '\0';
        void drawPlug(int x, int y, char symbol)
        {
            Rectangle position = new Rectangle(x, y, 18, 71);
            if (position.Contains(mouseOne.X, mouseOne.Y) && mouseOne.LeftButton == ButtonState.Pressed && mouseTwo.LeftButton == ButtonState.Released)
            {
                if (isWait)
                {
                    if (symbol == waitSymbol)
                        charset.Remove(symbol);
                    else if (replace.ContainsKey(symbol))
                    {
                        charset.Remove(waitSymbol);
                    }
                    else
                    {
                        replace[symbol] = waitSymbol;
                        replace[waitSymbol] = symbol;
                        charset.Remove(waitSymbol);
                        charset.Remove(symbol);
                    }

                    waitSymbol = '\0';
                    isWait = false;
                }
                else
                {
                    if (replace.ContainsKey(symbol))
                    {
                        replace.Remove(replace[symbol]);
                        replace.Remove(symbol);
                    }
                    else
                    {
                        isWait = true;
                        waitSymbol = symbol;
                        charset.Add(waitSymbol);
                    }
                }
                soundTick.Play(volume, -1, 0);
            }

            int val = BaseEnigma.code(symbol) + 1;
            string ssym = isNumber ? val.ToString() : symbol.ToString();
            int plused = isNumber ? (val < 10 ? 0 : -5) : (symbol == 'I' ? 5 : 0);

            if (isWait)
            {
                if (symbol == waitSymbol)
                    spriteBatch.DrawString(fontBase, ssym, new Vector2(x + plused, y - 4), Color.White);
                else
                    spriteBatch.DrawString(fontBase, ssym, new Vector2(x + plused, y - 4), Color.Gray);
            }
            else
                spriteBatch.DrawString(fontBase, ssym, new Vector2(x + plused, y - 4), Color.White);

            if (charset.Contains(symbol))
                spriteBatch.Draw(textureActivePlug, position, Color.White);
            else if (replace.ContainsKey(symbol))
            {
                spriteBatch.Draw(textureActivePlug, position, Color.White);
                int cval = BaseEnigma.code(replace[symbol]) + 1;
                string csym = isNumber ? cval.ToString() : replace[symbol].ToString();
                int cplused = isNumber ? (cval < 10 ? 0 : -3) : (replace[symbol] == 'I' ? 3 : 0);
                spriteBatch.DrawString(fontMini, csym, new Vector2(position.X + 5 + cplused, position.Y + 40), Color.White);
            }
            else
                spriteBatch.Draw(texturePlug, position, Color.Gray);
        }

        bool isSend = false;
        bool sended = false;
        char charCurrent = '\0';
        char charSend = '\0';
        public string message = "";

        void drawLed(int x, int y, char symbol)
        {
            Rectangle rect = new Rectangle(x, y, 37, 37);
            Color color = symbol == charSend ? Color.White : colorGray;
            spriteBatch.Draw(textureLed, rect, Color.White);
            spriteBatch.DrawString(fontBase, symbol.ToString(), new Vector2(x + 11 + (symbol == 'I' ? 4 : 0), y + 8), color);
        }

        void drawButton(int x, int y, char symbol)
        {
            Rectangle rect = new Rectangle(x, y, 37, 37);
            Color color;
            if (rect.Contains(mouseOne.X, mouseOne.Y) && mouseOne.LeftButton == ButtonState.Pressed && isSettings)
            {
                color = Color.Gray;
                if (!sended)
                {
                    charCurrent = symbol;
                    sended = true;
                    isSend = true;
                }
            }
            else
            {
                color = Color.White;
                if (charCurrent == symbol)
                {
                    charCurrent = charSend = '\0';
                    sended = false;
                    isSend = false;
                }
            }

            spriteBatch.Draw(textureSymbol, rect, color);
            spriteBatch.DrawString(fontBase, symbol.ToString(), new Vector2(x + 11 + (symbol == 'I' ? 4 : 0), y + 8), color);
        }
    }
}
