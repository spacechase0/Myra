﻿using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.StbSharp;

namespace Myra.Utility
{
	public static class GraphicsExtension
	{
		private static readonly Dictionary<string, Color> _colors = new Dictionary<string, Color>();

		static GraphicsExtension()
		{
			var type = typeof (Color);

			var colors = type.GetRuntimeProperties();

			foreach (var c in colors)
			{
				if (!c.GetMethod.IsStatic &&
				    c.PropertyType != typeof (Color))
				{
					continue;
				}

				var value = (Color) c.GetValue(null, null);
				_colors[c.Name.ToLower()] = value;
			}
		}

		public static string ToHexString(this Color c)
		{
			return string.Format("#{0}{1}{2}{3}",
				c.R.ToString("X2"),
				c.G.ToString("X2"),
				c.B.ToString("X2"),
				c.A.ToString("X2"));
		}

		public static Color? FromName(this string name)
		{
			if (name.StartsWith("#"))
			{
				name = name.Substring(1);
				uint u;
				if (uint.TryParse(name, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out u))
				{
					// Parsed value contains color in RGBA form
					// Extract color components

					byte r, g, b, a;

					unchecked
					{
						r = (byte) (u >> 24);
						g = (byte) (u >> 16);
						b = (byte) (u >> 8);
						a = (byte) u;
					}

					return new Color(r, g, b, a);
				}
			}
			else
			{
				Color result;
				if (_colors.TryGetValue(name.ToLower(), out result))
				{
					return result;
				}
			}

			return null;
		}

		public static Point Size(this Rectangle r)
		{
			return new Point(r.Width, r.Height);
		}

		public static void SetSize(ref Rectangle r, Point size)
		{
			r.Width = size.X;
			r.Height = size.Y;
		}

		public static Rectangle Add(this Rectangle r, Point p)
		{
			return new Rectangle(r.X + p.X, r.Y + p.Y, r.Width, r.Height);
		}

		private static byte ApplyAlpha(byte color, byte alpha)
		{
			var fc = color/255.0f;
			var fa = alpha/255.0f;

			var fr = (int) (255.0f*fc*fa);

			if (fr < 0)
			{
				fr = 0;
			}

			if (fr > 255)
			{
				fr = 255;
			}

			return (byte) fr;
		}

		/// <summary>
		/// Loads an image in PNG, JPG, BMP, GIF, TGA or PSD format from the stream
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="premultiplyAlpha">Performs alpha premultiplying if set to true</param>
		/// <returns></returns>
		public static Texture2D FromStream(Stream stream, bool premultiplyAlpha = false)
		{
			var reader = new ImageReader();

			int x, y;
			int comp;
			var data = reader.Read(stream, out x, out y, out comp, Stb.STBI_rgb_alpha);

			if (premultiplyAlpha)
			{
				// Premultiply alpha
				for (var i = 0; i < x*y; ++i)
				{
					var a = data[i*4 + 3];

					data[i*4] = ApplyAlpha(data[i*4], a);
					data[i*4 + 1] = ApplyAlpha(data[i*4 + 1], a);
					data[i*4 + 2] = ApplyAlpha(data[i*4 + 2], a);
				}
			}

			var texture = new Texture2D(MyraEnvironment.GraphicsDevice, x, y, false, SurfaceFormat.Color);
			texture.SetData(data);

			return texture;
		}

		public static void Process(this Texture2D texture, bool premultiplyAlpha, Color? transColor)
		{
			var data = new Color[texture.Width*texture.Height];
			texture.GetData(data);

			for (var i = 0; i < data.Length; ++i)
			{
				if (transColor.HasValue)
				{
					if (data[i].R == transColor.Value.R &&
						data[i].G == transColor.Value.G &&
						data[i].B == transColor.Value.B)
					{
						data[i].A = 0;
					}
				}

				var a = data[i].A;

				if (premultiplyAlpha)
				{
					data[i].R = ApplyAlpha(data[i].R, a);
					data[i].G = ApplyAlpha(data[i].G, a);
					data[i].B = ApplyAlpha(data[i].B, a);
				}
			}

			texture.SetData(data);
		}
	}
}