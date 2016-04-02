using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Hexwrench
{
	public class TextureMap
	{
		public Dictionary<string, Texture2D> Textures { get; private set; }

		public TextureMap ()
		{
			Textures = new Dictionary<string, Texture2D>();
		}

		public void Add (string key, Texture2D value)
		{
			Textures.Add(key, value);
		}

		public void Remove (string key)
		{
			Textures.Remove(key);
		}

		public Texture2D Get (string key)
		{
			return Textures [key];			
		}
	}
}

