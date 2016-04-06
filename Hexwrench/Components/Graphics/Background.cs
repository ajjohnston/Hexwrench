using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Hexwrench
{
	public class Background : GraphicsComponent
	{
		public Texture2D Texture;
		public Vector2 Position;
		public Vector2 Speed;
		public Rectangle Destination;

		public Background (Texture2D texture, Vector2 position, Vector2 speed, float depth) : base(true)
		{
			Texture = texture;
			Position = position;
			Speed = speed;
			Depth = depth;
		}

		public Background (Texture2D texture) : this(texture, Vector2.Zero, Vector2.Zero, 0)
		{
			
		}

		public override void Update (GameTime gameTime)
		{
			Position += Speed;
			Position = new Vector2(Position.X % Texture.Width, Position.Y % Texture.Height);
		}

		public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			if (Position.X < Texture.Width) {
				spriteBatch.Draw(Texture, Position, null, Color.White * Alpha, Rotation, Vector2.Zero, Scale, SpriteEffects.None, Depth);
			}
				
			spriteBatch.Draw(Texture, Position - new Vector2(Texture.Width, 0), null, Color.White * Alpha, Rotation, Vector2.Zero, Scale, SpriteEffects.None, Depth);
		}
	}
}
