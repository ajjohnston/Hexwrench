using System;

namespace Hexwrench
{
	public abstract class ColliderComponent : Component
	{
		public ColliderComponent () : base(true)
		{
		}

		public override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
		}

		public virtual bool Collides (ColliderComponent other)
		{
			if (other is RectangleCollider) {
				return Collides(other as RectangleCollider);
			}

			return false;
		}

		protected abstract bool Collides (RectangleCollider other);
	}
}

