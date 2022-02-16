// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{

    /// <summary>
    /// This is the actual menu part of a MenuScreen
    /// </summary>
    public class MenuComponent : VisualComponent
    {
        string[] menuItems;
        int selectedIndex;
 
        Color normal = Color.White;
        Color hilite = Color.Yellow;
 
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
 
        Vector2 position;
        float width = 0f;
        float height = 0f;
 
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                if (selectedIndex < 0)
                    selectedIndex = 0;
                if (selectedIndex >= menuItems.Length)
                    selectedIndex = menuItems.Length - 1;
            }
        }
 
        public MenuComponent(Game game,
            string[] menuItems)
            : base(game)
        {
            this.menuItems = menuItems;
        }
 
        private void MeasureMenu()
        {
            height = 0;
            width = 0;
            foreach (string item in menuItems)
            {
                Vector2 size = spriteFont.MeasureString(item);
                if (size.X > width)
                    width = size.X;
                height += spriteFont.LineSpacing + 5;
            }
 
            position = new Vector2(
                (Resolution.GameWidth - width) / 2,
                (Resolution.GameHeight - height) / 2);
        }
 
        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            this.spriteBatch = ScreenManager.SpriteBatch;
            this.spriteFont = Art.MenuFont;
            MeasureMenu();
        }

        public new void UnloadContent()
        {

        }
 
        private bool CheckKey(Keys theKey)
        {
            return Input.WasKeyPressed(theKey);
        }
 
        public string HandleInput()
        {
            if (CheckKey(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Length)
                    selectedIndex = 0;
            }
            if (CheckKey(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = menuItems.Length - 1;
            }
            if (CheckKey(Keys.Enter))
            {
                return menuItems[selectedIndex];
            }

            return String.Empty;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 location = position;
            Color tint;

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                    tint = hilite;
                else
                    tint = normal;
                spriteBatch.DrawString(
                    spriteFont,
                    menuItems[i],
                    location,
                    tint);
                location.Y += spriteFont.LineSpacing + 5;
            }
        }
    }
}
