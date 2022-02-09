// © 2022 David Alger <RoastToast-gh@protonmail.com>
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{

    public class MathUtil
    {
        public static Rectangle GetBounds(int x, int y)
        {
            return new Rectangle(x * Tile.Width, y * Tile.Height, Tile.Width, Tile.Height);
        }

        public static float DirectionToAngle(Vector2 direction)
        {
            float angle = 0f;

            if (direction.Y < 0)
            {
                angle = -90;
                if (direction.X < 0)
                    angle -= 45;
                else if (direction.X > 0)
                    angle += 45;
            }
            else if (direction.Y > 0)
            {
                angle = 90;
                if (direction.X < 0)
                    angle += 45;
                else if (direction.X > 0)
                    angle -= 45;
            }
            else if (direction.X < 0)
                angle = 180;
            else if (direction.X > 0)
                angle = 0;

            return angle;
        }

    }
}