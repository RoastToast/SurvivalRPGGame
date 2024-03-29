﻿// © 2022 David Alger <RoastToast-gh@protonmail.com>
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

		/// <summary>
		/// Get keyboard, mouse, and gamepad state every frame
		/// </summary>
		public static void Update()
		{
			lastKeyboardState = keyboardState;
			lastMouseState = mouseState;
			lastGamepadState = gamepadState;

			keyboardState = Keyboard.GetState();
			mouseState = Mouse.GetState();
			gamepadState = GamePad.GetState(PlayerIndex.One);
		}

		/// <summary>
		/// Checks if the key was pressed this cycle
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool WasKeyPressed(Keys key)
		{
			return lastKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key);
		}

		/// <summary>
		/// Checks if the button was pressed this cycle
		/// </summary>
		/// <param name="button"></param>
		/// <returns></returns>
		public static bool WasButtonPressed(Buttons button)
		{
			return lastGamepadState.IsButtonUp(button) && gamepadState.IsButtonDown(button);
		}

		/// <summary>
		/// Checks if the Exit Key was Pressed
		/// </summary>
		/// <returns></returns>
		public static bool WasExitPressed()
		{
			return keyboardState.IsKeyDown(Keys.Escape);
		}

		public static float GetScrollWheel()
        {
			return mouseState.ScrollWheelValue - lastMouseState.ScrollWheelValue;
		}

		/// <summary>
		/// Gets Direction of movement, left/right and up/down
		/// </summary>
		/// <returns></returns>
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