using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hexwrench
{
	public class InputComponent : Component
	{
		public PlayerIndex PlayerIndex { get; private set; }

		public KeyboardData Keyboard { get; private set; }

		public GamepadData Gamepad { get; private set; }

		public InputComponent (PlayerIndex playerIndex) : base(true)
		{
			PlayerIndex = playerIndex;
			Keyboard = new KeyboardData();
			Gamepad = new GamepadData(PlayerIndex);
		}

		public override void Update (GameTime gameTime)
		{
			Keyboard.Update();
			Gamepad.Update();
		}

		public bool Down (Buttons button)
		{
			return Gamepad.Down(button);
		}

		public bool Down (Keys key)
		{
			return Keyboard.Down(key);
		}

		public bool Up (Buttons button)
		{
			return Gamepad.Up(button);
		}

		public bool Up (Keys key)
		{
			return Keyboard.Up(key);
		}

		public bool Pressed (Buttons button)
		{
			return Gamepad.Pressed(button);
		}

		public bool Pressed (Keys key)
		{
			return Keyboard.Pressed(key);
		}

		public bool Released (Buttons button)
		{
			return Gamepad.Released(button);
		}

		public bool Released (Keys key)
		{
			return Keyboard.Released(key);
		}
	}
}
	