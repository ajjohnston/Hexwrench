using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hexwrench
{
	public class Engine : Game
	{
		static public Engine Instance { get; private set; }

		static public GraphicsDeviceManager Graphics { get; private set; }

		public Scene CurrentScene;

		public Engine ()
		{
			Instance = this;
			Graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = @"Content\";
		}

		protected override void Initialize ()
		{
			Services.AddService(typeof(GraphicsDeviceManager), Graphics);

			Hexwrench.Draw.Initialize(this);

			base.Initialize();
		}

		protected override void Update (GameTime gameTime)
		{
			if (CurrentScene != null) {
				CurrentScene.Update(gameTime);
			}

			base.Update(gameTime);
		}

		protected override bool BeginDraw ()
		{
			Hexwrench.Draw.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
			GraphicsDevice.Clear(Color.CornflowerBlue);

			return base.BeginDraw();
		}

		protected override void Draw (GameTime gameTime)
		{
			if (CurrentScene != null) {
				CurrentScene.Draw(gameTime);
			}

			base.Draw(gameTime);
		}

		protected override void EndDraw ()
		{
			Hexwrench.Draw.SpriteBatch.End();

			base.EndDraw();
		}
	}
}

