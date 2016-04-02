using System;
using Microsoft.Xna.Framework;

namespace Hexwrench
{
	public static class Vector2Extensions
	{
		public static Vector2 Floor (this Vector2 vector)
		{
			return new Vector2((float)Math.Floor(vector.X), (float)Math.Floor(vector.Y));
		}
	}
}
