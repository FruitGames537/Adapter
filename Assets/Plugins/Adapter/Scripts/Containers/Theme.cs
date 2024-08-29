using Adapter.Styles;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	[CreateAssetMenu(menuName = "Adapter/Container/Theme", fileName = "New Theme", order = 1)]
	public class Theme : ScriptableContainer
	{
		[SerializeField] private string m_ThemeName = string.Empty;
		[SerializeField] private List<Container<string, Color>> m_Colors = new List<Container<string, Color>>();
		[SerializeField] private List<Container<string, ImageStyle>> m_ImageStyles = new List<Container<string, ImageStyle>>();
		[SerializeField] private List<Container<string, ButtonStyle>> m_ButtonStyles = new List<Container<string, ButtonStyle>>();
		[SerializeField] private List<Container<string, TextStyle>> m_TextStyles = new List<Container<string, TextStyle>>();

		public string themeName => m_ThemeName;
		public List<Container<string, Color>> colors => m_Colors;
		public List<Container<string, ImageStyle>> imageStyles => m_ImageStyles;
		public List<Container<string, ButtonStyle>> buttonStyles => m_ButtonStyles;
		public List<Container<string, TextStyle>> textStyles => m_TextStyles;



		public Color GetColor(string name, bool ignore = false) => GetValue(m_Colors, name, ignore: ignore);
		public Color? CanGetColor(string name) => CanGetValue(m_Colors, name) ? GetValue(m_Colors, name) : null;

		public T GetStyle<T>(string name, bool ignore = false) where T : class
		{
			if (typeof(T) == typeof(ImageStyle))
				return GetValue(m_ImageStyles as List<Container<string, T>>, name, ignore: ignore);
			else if (typeof(T) == typeof(ButtonStyle))
				return GetValue(m_ButtonStyles as List<Container<string, T>>, name, ignore: ignore);
			else if (typeof(T) == typeof(TextStyle))
				return GetValue(m_TextStyles as List<Container<string, T>>, name, ignore: ignore);
			throw new NotImplementedException($"Style type argument is not supported: \"{typeof(T)}\"");
		}
		public T CanGetStyle<T>(string name) where T : class
		{
			List<Container<string, T>> containers;
			if (typeof(T) == typeof(ImageStyle))
				containers = m_ImageStyles as List<Container<string, T>>;
			else if (typeof(T) == typeof(ButtonStyle))
				containers = m_ImageStyles as List<Container<string, T>>;
			else if (typeof(T) == typeof(TextStyle))
				containers = m_ImageStyles as List<Container<string, T>>;
			else
				throw new NotImplementedException($"Style type argument is not supported: \"{typeof(T)}\"");
			return CanGetValue(containers, name) ? GetValue(containers, name) : null;
		}
	}
}