using System;
using Microsoft.Xna.Framework;

namespace Hexwrench
{
	public class RectangleCollider : ColliderComponent
	{
		public Rectangle Hitbox;

		public int Width, Height;

		public RectangleCollider (int width, int height) : base()
		{
			Width = width;
			Height = height;
		}

		public override void Update (GameTime gameTime)
		{
			Hitbox = new Rectangle((int)Math.Floor(GameObject.Position.X), (int)Math.Floor(GameObject.Position.Y), Width, Height);

			base.Update(gameTime);
		}

		protected override bool Collides (RectangleCollider other)
		{
			return Hitbox.Intersects(other.Hitbox);
		}
	}
}

