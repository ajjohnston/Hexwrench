using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Hexwrench
{
	public class GameObject
	{
		public Scene Scene { get; private set; }

		public List<Component> Components;
		public Vector2 Position;

		public List<string> Tags { get; private set; }

		public GameObject (Vector2 position)
		{
			Position = position;
			Components = new List<Component>();
			Tags = new List<string>();
		}

		public GameObject () : this(Vector2.Zero)
		{
            
		}

		public virtual void Update (GameTime gameTime)
		{
			foreach (Component component in Components.Where(x => x.Active)) {
				component.Update(gameTime);
			}
		}

		public virtual void Draw (GameTime gameTime)
		{
			foreach (GraphicsComponent component in Components.OfType<GraphicsComponent>().Where(x => x.Visible)) {
				component.Draw(gameTime);
			}
		}

		public virtual void Added (Scene scene)
		{
			Scene = scene;
		}

		public virtual void Removed (Scene scene)
		{
			Scene = null;
		}

		public virtual void Add (Component component)
		{
			component.Added(this);
			Components.Add(component);
		}

		public virtual void Remove (Component component)
		{
			component.Removed(this);
			Components.Remove(component);
		}
	}
}
