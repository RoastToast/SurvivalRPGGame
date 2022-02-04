using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalRPGGame
{
    public class Input
    {
		private static KeyboardState keyboardState, lastKeyboardState;
		private static MouseState mouseState, lastMouseState;
		private static GamePadState gamepadState, lastGamepadState;

		public static Vector2 MousePosition { get { return new Vector2(mouseState.X, mouseState.Y); } }

		public static void Update()
		{
			lastKeyboardState = keyboardState;
			lastMouseState = mouseState;
			lastGamepadState = gamepadState;

			keyboardState = Keyboard.GetState();
			mouseState = Mouse.GetState();
			gamepadState = GamePad.GetState(PlayerIndex.One);
		}

		// Checks if a key was just pressed down
		public static bool WasKeyPressed(Keys key)
		{
			return lastKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key);
		}

		public static bool WasButtonPressed(Buttons button)
		{
			return lastGamepadState.IsButtonUp(button) && gamepadState.IsButtonDown(button);
		}

		public static bool WasExitPressed()
		{
			return keyboardState.IsKeyDown(Keys.Escape);
		}

		public static Vector2 GetMovementDirection()
		{

			Vector2 direction = new Vector2(0, 0);

			if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
				direction.X -= 1;
			if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
				direction.X += 1;
			if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
				direction.Y -= 1;
			if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
				direction.Y += 1;

			// Clamp the length of the vector to a maximum of 1.
			if (direction.LengthSquared() > 1)
				direction.Normalize();

			return direction;
		}
	}
}