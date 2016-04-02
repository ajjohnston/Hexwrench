using System;
using Microsoft.Xna.Framework;

namespace Hexwrench
{
	public class Alarm : Component
	{
		public Action Action;

		public float Length { get; private set; }

		public double TimeLeft { get; private set; }

		public Alarm (Action action, float length, bool active = false) : base(active)
		{
			Action = action;
			Length = length;
			TimeLeft = Length;
		}

		public override void Update (GameTime gameTime)
		{
			if (!Active) {
				return;
			}

			TimeLeft -= gameTime.ElapsedGameTime.TotalMilliseconds;

			if (TimeLeft <= 0) {
				Action.Invoke();
				Stop();
			}
		}

		public void Start ()
		{
			Active = true;
		}

		public void Stop ()
		{
			Active = false;
		}

		public void Restart ()
		{
			TimeLeft = Length;
			Start();
		}
	}
}
