using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hexwrench
{
	public abstract class GraphicsComponent : Component
	{
		public bool Visible;
		public Vector2 Origin;
		public Vector2 Scale = Vector2.One;
		public float Rotation = 0;
		public float Depth = 0;
		public float Alpha = 1;
		private Color color = Color.White;

		public Color Color {
			get {
				return color * (Visible ? Alpha : 0);
			}
			set {
				color = value;
			}
		}

		public GraphicsComponent (bool active, bool visible = true) : base(active)
		{
			Visible = visible;
		}

		public abstract void Draw (GameTime gameTime);
	}
}

