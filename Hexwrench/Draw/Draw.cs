using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hexwrench
{
	public static class Draw
	{
		public static SpriteBatch SpriteBatch { get; private set; }

		public static SpriteFont DefaultFont { get; private set; }

		public static void Initialize (Engine engine)
		{
			SpriteBatch = new SpriteBatch(engine.GraphicsDevice);
			DefaultFont = Engine.Instance.Content.Load<SpriteFont>(@"DefaultFont");
		}

		public static void Text (Vector2 position, String text, Color color)
		{
			SpriteBatch.DrawString(DefaultFont, text, position, color);
		}

		public static void Rectangle (float x, float y, int width, int height, Color color)
		{
			Texture2D rect = new Texture2D(Engine.Instance.GraphicsDevice, width, height);
			Color[] data = new Color[width * height];
			for (int i = 0; i < data.Length; ++i) {
				data [i] = color;
			}
			rect.SetData(data);

			SpriteBatch.Draw(rect, new Vector2(x, y), color);
		}

		public static void Rectangle (Rectangle rectangle, Color color)
		{
			Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, color);
		}
	}
}
