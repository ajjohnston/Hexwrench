using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Hexwrench
{
	public class Scene
	{
		public List<Layer> Layers { get; private set; }

		public bool Active;

		public Scene (bool active = true)
		{
			Layers = new List<Layer>();
			Active = active;
		}

		public virtual void Update (GameTime gameTime)
		{
			foreach (Layer layer in Layers.Where(x => x.Active)) {
				layer.Update(gameTime);
			}
		}

		public virtual void Draw (GameTime gameTime)
		{
			foreach (Layer layer in Layers.Where(x => x.Visible).OrderBy(x => x.Depth)) {
                layer.Draw(gameTime);
			}
		}

		public virtual void Add (Layer layer)
		{
			layer.Added(this);
			Layers.Add(layer);
		}

		public virtual void Remove(Layer layer)
        {
			layer.Removed(this);
            Layers.Remove(layer);
		}
	}
}

