using Adapter.Styles;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	[CreateAssetMenu(menuName = "Adapter/Container/Theme", fileName = "New Theme", order = 2)]
	public class Theme : ScriptableContainer
	{
		public Theme(string themeName) => m_ThemeName = themeName;

		public Theme(string themeName, List<Container<string, Color>> colors, List<Container<string, Sprite>> sprites) : this(themeName)
		{
			m_Colors = colors;
			m_Sprites = sprites;
		}
		public Theme(string themeName, List<Container<string, TextStyle>> textStyles, List<Container<string, ImageStyle>> imageStyles, List<Container<string, ButtonStyle>> buttonStyles) : this(themeName)
		{
			m_TextStyles = textStyles;
			m_ImageStyles = imageStyles;
			m_ButtonStyles = buttonStyles;
		}

		public Theme(string themeName, List<Container<string, Color>> colors, List<Container<string, Sprite>> sprites, List<Container<string, TextStyle>> textStyles, List<Container<string, ImageStyle>> imageStyles, List<Container<string, ButtonStyle>> buttonStyles) : this(themeName, textStyles, imageStyles, buttonStyles)
		{
			m_Colors = colors;
			m_Sprites = sprites;
		}



		[SerializeField] private string m_ThemeName = string.Empty;

		[SerializeField] private List<Container<string, Color>> m_Colors = new List<Container<string, Color>>();
		[SerializeField] private List<Container<string, Sprite>> m_Sprites = new List<Container<string, Sprite>>();

		[SerializeField] private List<Container<string, TextStyle>> m_TextStyles = new List<Container<string, TextStyle>>();
		[SerializeField] private List<Container<string, ImageStyle>> m_ImageStyles = new List<Container<string, ImageStyle>>();
		[SerializeField] private List<Container<string, ButtonStyle>> m_ButtonStyles = new List<Container<string, ButtonStyle>>();

		public string themeName => m_ThemeName;

		public List<Container<string, Color>> colors => m_Colors;
		public List<Container<string, Sprite>> sprites => m_Sprites;

		public List<Container<string, TextStyle>> textStyles => m_TextStyles;
		public List<Container<string, ImageStyle>> imageStyles => m_ImageStyles;
		public List<Container<string, ButtonStyle>> buttonStyles => m_ButtonStyles;



		public Color GetColor(string path, bool safe = false) => GetStore(m_Colors, path, safe: safe);
		public bool SearchColor(string path, out Color color) => SearchStore(m_Colors, path, out color);

		public Sprite GetSprite(string path, bool safe = false) => GetStore(m_Sprites, path, safe: safe);
		public bool SeatchSprite(string path, out Sprite sprite) => SearchStore(m_Sprites, path, out sprite);

		public T GetStyle<T>(string path, bool safe = false) where T : class
		{
			if (typeof(T) == typeof(TextStyle))
				return GetStore(m_TextStyles as List<Container<string, T>>, path, safe: safe);
			else if (typeof(T) == typeof(ImageStyle))
				return GetStore(m_ImageStyles as List<Container<string, T>>, path, safe: safe);
			else if (typeof(T) == typeof(ButtonStyle))
				return GetStore(m_ButtonStyles as List<Container<string, T>>, path, safe: safe);
			throw new NotImplementedException($"Style type argument is not supported: \"{typeof(T)}\"");
		}
		public bool SearchStyle<T>(string path, out T style) where T : class
		{
			if (typeof(T) == typeof(TextStyle))
				return SearchStore(m_TextStyles as List<Container<string, T>>, path, out style);
			else if (typeof(T) == typeof(ImageStyle))
				return SearchStore(m_ImageStyles as List<Container<string, T>>, path, out style);
			else if (typeof(T) == typeof(ButtonStyle))
				return SearchStore(m_ButtonStyles as List<Container<string, T>>, path, out style);
			throw new NotImplementedException($"Style type argument is not supported: \"{typeof(T)}\"");
		}
	}
}