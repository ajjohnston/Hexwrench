using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Hexwrench
{
	public class Scene
	{
		public List<GameObject> GameObjects { get; private set; }

		public bool Active;

		public Scene (bool active = true)
		{
			GameObjects = new List<GameObject>();
			Active = active;
		}

		public virtual void Update (GameTime gameTime)
		{
			foreach (GameObject gameObject in GameObjects) {
				gameObject.Update(gameTime);
			}
		}

		public virtual void Draw (GameTime gameTime)
		{
			foreach (GameObject gameObject in GameObjects) {
				gameObject.Draw(gameTime);
			}
		}

		public virtual void Add (GameObject gameObject)
		{
			gameObject.Added(this);
			GameObjects.Add(gameObject);
		}

		public virtual void Remove (GameObject gameObject)
		{
			gameObject.Removed(this);
			GameObjects.Remove(gameObject);
		}
	}
}

