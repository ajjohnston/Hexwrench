using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hexwrench
{
    public class Layer
    {
        public Scene Scene { get; private set; }
        public List<GameObject> GameObjects { get; private set; }
        public RenderTarget2D RenderTarget { get; private set; }
        public bool Active;
        public bool Visible;
        public int Depth;
        public Vector2 Origin;
        private SpriteBatch spriteBatch;

        public Layer(bool active = true, bool visible = true, int depth = 0)
        {
            Active = active;
            Visible = visible;
            Depth = depth;
            Origin = Vector2.Zero;
            GameObjects = new List<GameObject>();
            RenderTarget = new RenderTarget2D(Engine.Instance.GraphicsDevice,
                 Engine.Instance.GraphicsDevice.PresentationParameters.BackBufferWidth,
                 Engine.Instance.GraphicsDevice.PresentationParameters.BackBufferHeight);
            spriteBatch = new SpriteBatch(Engine.Instance.GraphicsDevice);
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject gameObject in GameObjects.Where(x => x.Active))
            {
                gameObject.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            DrawSceneToRenderTarget(gameTime);

            Engine.Instance.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            Hexwrench.Draw.SpriteBatch.Draw(RenderTarget, new Rectangle(0 + (int)Origin.X, 0 + (int)Origin.Y, RenderTarget.Width, RenderTarget.Height), Color.White);
            spriteBatch.End();
        }

        private void DrawSceneToRenderTarget(GameTime gameTime)
        {
            Engine.Instance.GraphicsDevice.SetRenderTarget(RenderTarget);
            Engine.Instance.GraphicsDevice.Clear(Color.Transparent);

            spriteBatch.Begin();
            foreach (GameObject gameObject in GameObjects.Where(x => x.Visible))
            {
                gameObject.Draw(spriteBatch, gameTime);
            }
            spriteBatch.End();

            Engine.Instance.GraphicsDevice.SetRenderTarget(null);
        }

        public virtual void Add(GameObject gameObject)
        {
            gameObject.Added(this);
            GameObjects.Add(gameObject);
        }

        public virtual void Remove(GameObject gameObject)
        {
            gameObject.Removed(this);
            GameObjects.Remove(gameObject);
        }

        public virtual void Added(Scene scene)
        {
            Scene = scene;
        }

        public virtual void Removed(Scene scene)
        {
            Scene = null;
        }
    }
}
