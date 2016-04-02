using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Hexwrench
{
	public class Sprite : GraphicsComponent
	{
		public Texture2D Texture;
		public bool Loop;
		public SpriteEffects Effects = SpriteEffects.None;

		public int FrameWidth { get; private set; }

		public int FrameHeight { get; private set; }

		public int[] FrameTime { get; private set; }

		public int FrameCount { get; private set; }

		private int currentFrame;
		private double time;
		private Rectangle currentFrameBounds;

		public Sprite (SpriteData data) : this(data.Texture, data.Origin, data.FrameCount, data.FrameWidth, data.FrameHeight, data.FrameTime, data.Alpha, data.Loop)
		{
			
		}

		public Sprite (Texture2D texture, Vector2 origin) : this(texture, origin, 0, texture.Width, texture.Height, new int[] { 0 }, loop: false)
		{
		}

		public Sprite (Texture2D texture, Vector2 origin, int frameCount, int frameWidth, int frameHeight, int[] frameTime, float alpha = 1f, bool loop = true) : base(true)
		{
			Texture = texture;
			FrameCount = frameCount;
			FrameWidth = frameWidth;
			FrameHeight = frameHeight;
			FrameTime = frameTime;
			Origin = origin;
			Loop = loop;
			this.ResetAnimation();
		}

		public void Load (SpriteData spriteData)
		{
			Texture = spriteData.Texture;
			FrameCount = spriteData.FrameCount;
			FrameWidth = spriteData.FrameWidth;
			FrameHeight = spriteData.FrameHeight;
			FrameTime = spriteData.FrameTime;
			Alpha = spriteData.Alpha;
			Origin = spriteData.Origin;
			Loop = spriteData.Loop;
			this.ResetAnimation();
		}

		public override void Update (GameTime gameTime)
		{
			if (FrameCount == 0) {
				return;
			}

			time += gameTime.ElapsedGameTime.TotalMilliseconds;

			if (time >= FrameTime [currentFrame]) {
				currentFrame++;
				time = 0;

				if (currentFrame >= FrameCount) {
					if (Loop) {
						this.ResetAnimation();
					} else {
						currentFrame--;
					}
				}

				currentFrameBounds = GetCurrentFrameBounds(currentFrame);	
			}
		}

		public override void Draw (GameTime gameTime)
		{
			Hexwrench.Draw.SpriteBatch.Draw(Texture, GameObject.Position.Floor(), null, currentFrameBounds, Origin, Rotation, Scale, Color, Effects, Depth);
		}

		public void ResetAnimation ()
		{
			currentFrame = 0;
			currentFrameBounds = GetCurrentFrameBounds(currentFrame);
			time = 0;
		}

		private Rectangle GetCurrentFrameBounds (int frame)
		{
			int x = (frame * FrameWidth) % (Texture.Width / FrameWidth);
			int y = frame / (Texture.Width / FrameWidth);

			return new Rectangle(x * FrameWidth, y * FrameHeight, FrameWidth, FrameHeight);
		}
	}

	public struct SpriteData
	{
		public Texture2D Texture;
		public float Alpha;
		public int FrameWidth;
		public int FrameHeight;
		public int[] FrameTime;
		public int FrameCount;
		public Vector2 Origin;
		public bool Loop;

		public SpriteData (Texture2D texture, int frameCount, int frameWidth, int frameHeight, int[] frameTime, Vector2 origin, float alpha = 1f, bool loop = true)
		{
			Texture = texture;
			FrameCount = frameCount;
			FrameWidth = frameWidth;
			FrameHeight = frameHeight;
			FrameTime = frameTime;
			Origin = origin;
			Alpha = alpha;
			Loop = loop;
		}
	}
}
