using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    class HUDComponent : VisualComponent
    {
        Texture2D Hotbar;
        Texture2D ActiveHotbar;

        Color hilite = Color.Goldenrod;
        Color normal = Color.White;

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Vector2 position;
        float width = 0f;
        float height = 0f;

        public HUDComponent(Game game)
            : base(game)
        {
            position = new Vector2(0, 0);
        }

        private void MeasureHotbar()
        {
            //height = 0;
            //width = 0;
            //foreach (string item in menuItems)
            //{
            //    Vector2 size = spriteFont.MeasureString(item);
            //    if (size.X > width)
            //        width = size.X;
            //    height += spriteFont.LineSpacing + 5;
            //}

            //position = new Vector2(
            //    (Resolution.GameWidth - width) / 2,
            //    (Resolution.GameHeight - height) / 2);
        }

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            this.spriteBatch = ScreenManager.SpriteBatch;
            this.spriteFont = Art.MenuFont;
            this.Hotbar = Art.Hotbar;
            this.ActiveHotbar = Art.ActiveHotbar;
            MeasureHotbar();
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
            throw new Exception(message: "HUDComponent.HandleInput just received Input for the game, this should NEVER happen. Redirect input to GameplayScreen, and from there to LevelManager.");
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 location = position;
            Color tint;
            Item ActiveItem = Player.Instance.GetActiveItem();

            foreach(Item i in Player.Instance.GetHotbar())
            {
                if(i == ActiveItem)
                {
                    tint = hilite;
                    spriteBatch.Draw(
                        ActiveHotbar,
                        location,
                        tint);
                } else
                {
                    tint = normal;
                    spriteBatch.Draw(
                        Hotbar,
                        location,
                        tint);

                }
                if (i is Empty) { }
                else {
                    spriteBatch.Draw(
                        i.Texture,
                        location,
                        tint);
                }

                location.X += Hotbar.Width;
            }
            //Color tint;

            //for (int i = 0; i < menuItems.Length; i++)
            //{
            //    if (i == selectedIndex)
            //        tint = hilite;
            //    else
            //        tint = normal;
            //    spriteBatch.DrawString(
            //        spriteFont,
            //        menuItems[i],
            //        location,
            //        tint);
            //    location.Y += spriteFont.LineSpacing + 5;
            //}
        }
    }
}
