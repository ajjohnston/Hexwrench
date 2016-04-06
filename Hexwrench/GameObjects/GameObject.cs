using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Hexwrench
{
    public class GameObject
	{
		public Layer Layer { get; private set; }
        public Vector2 Position;
        public List<Component> Components;
		public ColliderComponent Collider { get; protected set; }
		public List<string> Tags { get; private set; }
        public bool Active;
        public bool Visible;

        public GameObject (Vector2 position, bool active = true, bool visible = true)
		{
			Position = position;
			Components = new List<Component>();
			Tags = new List<string>();
            Active = active;
            Visible = visible;
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

		public virtual void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			foreach (GraphicsComponent component in Components.OfType<GraphicsComponent>().Where(x => x.Visible)) {
				component.Draw(spriteBatch, gameTime);
			}
		}

		public virtual void Added (Layer layer)
		{
			Layer = layer;
		}

		public virtual void Removed (Layer layer)
		{
			Layer = null;
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

		public bool CollidesWith (GameObject other)
		{
			if (other == null || Collider == null) {
				return false;
			}

			return Collider.Collides(other.Collider);
		}

		public GameObject CollidesWith (string objectTag)
		{
			if (Collider == null) {
				return null;
			}

			foreach (GameObject gameObject in Layer.GameObjects.Where(x => x.Tags.Contains(objectTag))) {
				if (this.CollidesWith(gameObject)) {
					return gameObject;
				}
			}

			return null;
		}
	}
}
