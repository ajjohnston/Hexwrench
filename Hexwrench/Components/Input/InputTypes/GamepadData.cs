using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Hexwrench
{
	public class GamepadData
	{
		public PlayerIndex PlayerIndex { get; private set; }

		public GamePadState CurrentState { get; private set; }

		public GamePadState PreviousState { get; private set; }

		public GamepadData (PlayerIndex playerIndex)
		{
			PlayerIndex = playerIndex;
			CurrentState = GamePad.GetState(PlayerIndex);
			PreviousState = GamePad.GetState(PlayerIndex);
		}

		public void Update ()
		{
			PreviousState = CurrentState;
			CurrentState = GamePad.GetState(PlayerIndex);
		}

		public bool Down (Buttons button)
		{
			return CurrentState.IsButtonDown(button);
		}

		public bool Up (Buttons button)
		{
			return CurrentState.IsButtonUp(button);
		}

		public bool Pressed (Buttons button)
		{
			return CurrentState.IsButtonDown(button) && PreviousState.IsButtonUp(button);
		}

		public bool Released (Buttons button)
		{
			return CurrentState.IsButtonUp(button) && PreviousState.IsButtonDown(button);
		}
	}
}

