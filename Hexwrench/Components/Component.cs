using System;
using Microsoft.Xna.Framework;

namespace Hexwrench
{
	public abstract class Component
	{
		public GameObject GameObject { get; private set; }

		public bool Active;

		public Component (bool active)
		{
			Active = active;
		}

		public abstract void Update (GameTime gameTime);

		public virtual void Added (GameObject gameObject)
		{
			GameObject = gameObject;
		}

		public virtual void Removed (GameObject gameObject)
		{
			GameObject = null;
		}
	}
}
