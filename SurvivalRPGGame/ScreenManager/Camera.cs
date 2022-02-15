// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{

    /// <summary>
    /// An Entity Tracking Camera with zoom
    /// 
    /// Credits:
    /// Zoom Logic: https://community.monogame.net/u/spool
    /// Entity Tracking: https://community.monogame.net/u/shiro
    /// </summary>
    public class Camera
    {
        public float Zoom { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; protected set; }
        public Rectangle VisibleArea { get; protected set; }
        public Matrix Transform { get; protected set; }

        private float zoom, previousZoom;
        public void Follow(Entity target)
        {
            Position = new Vector2(-target.Position.X - (target.Rectangle.Width / 2), -target.Position.Y - (target.Rectangle.Height / 2));
            UpdateCamera();
            UpdateMatrix();
        }

        public Camera()
        {
            Zoom = 1f;
        }


        //private void UpdateVisibleArea()
        //{
        //    var inverseViewMatrix = Matrix.Invert(Transform);

        //    var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
        //    var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
        //    var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
        //    var br = Vector2.Transform(new Vector2(Bounds.Width, Bounds.Height), inverseViewMatrix);

        //    var min = new Vector2(
        //        MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
        //        MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
        //    var max = new Vector2(
        //        MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
        //        MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
        //    VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        //}

        private void UpdateMatrix()
        {
            var position = Matrix.CreateTranslation(
              Position.X,
              Position.Y,
              0);
            var offset = Matrix.CreateTranslation(
                Resolution.GameWidth / zoom / 2,
                Resolution.GameHeight / zoom / 2,
                0);

            Transform = position
                * offset
                * Resolution.ScaleMatrix
                * Matrix.CreateScale(Zoom);
        }

        public void AdjustZoom(float zoomAmount)
        {
            Zoom += zoomAmount;
            if (Zoom < .35f)
            {
                Zoom = .35f;
            }
            if (Zoom > 2f)
            {
                Zoom = 2f;
            }
        }

        public void UpdateCamera()
        {

            float scrollValue = Input.GetScrollWheel();

            if (scrollValue > 0)
            {
                AdjustZoom(.05f);
            }

            if (scrollValue < 0)
            {
                AdjustZoom(-.05f);
            }

            previousZoom = zoom;
            zoom = Zoom;
            if (previousZoom != zoom)
            {
                Console.WriteLine(zoom);

            }
        }
    }
}
