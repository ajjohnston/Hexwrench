using System;
using Microsoft.Xna.Framework.Input;

namespace Hexwrench
{
	public class KeyboardData
	{
		public KeyboardState CurrentState { get; private set; }

		public KeyboardState PreviousState { get; private set; }

		public KeyboardData ()
		{
			CurrentState = Keyboard.GetState();
			PreviousState = Keyboard.GetState();
		}

		public void Update ()
		{
			PreviousState = CurrentState;
			CurrentState = Keyboard.GetState(); 
		}

		public bool Down (Keys key)
		{
			return CurrentState.IsKeyDown(key);
		}

		public bool Up (Keys key)
		{
			return CurrentState.IsKeyUp(key);
		}

		public bool Pressed (Keys key)
		{
			return CurrentState.IsKeyDown(key) && PreviousState.IsKeyUp(key);
		}

		public bool Released (Keys key)
		{
			return CurrentState.IsKeyUp(key) && PreviousState.IsKeyDown(key);
		}
	}
}
	