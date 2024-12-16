using Adapter.Styles;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	[CreateAssetMenu(menuName = "Adapter/Container/Theme", fileName = "New Theme", order = 2)]
	public class Theme : ScriptableContainer
	{
		[SerializeField] private string m_ThemeName = string.Empty;

		[SerializeField] private List<Container<string, Color>> m_Colors;
		[SerializeField] private List<Container<string, Sprite>> m_Sprites;

		[SerializeField] private List<Container<string, TextStyle>> m_TextStyles;
		[SerializeField] private List<Container<string, ImageStyle>> m_ImageStyles;
		[SerializeField] private List<Container<string, ButtonStyle>> m_ButtonStyles;

		[SerializeField] private List<Container<string, InputStyle>> m_InputStyles;
		[SerializeField] private List<Container<string, ToggleStyle>> m_ToggleStyles;
		[SerializeField] private List<Container<string, SliderStyle>> m_SliderStyles;
		[SerializeField] private List<Container<string, DropdownStyle>> m_DropdownStyles;

		public string themeName => m_ThemeName;

		public List<Container<string, Color>> colors { get => m_Colors; set => m_Colors = value ?? new List<Container<string, Color>>(); }
		public List<Container<string, Sprite>> sprites {get => m_Sprites; set => m_Sprites = value ?? new List<Container<string, Sprite>>(); }

		public List<Container<string, TextStyle>> textStyles { get => m_TextStyles; set => m_TextStyles = value ?? new List<Container<string, TextStyle>>(); }
		public List<Container<string, ImageStyle>> imageStyles { get => m_ImageStyles; set => m_ImageStyles = value ?? new List<Container<string, ImageStyle>>(); }
		public List<Container<string, ButtonStyle>> buttonStyles { get => m_ButtonStyles; set => m_ButtonStyles = value ?? new List<Container<string, ButtonStyle>>(); }
		
		public List<Container<string, InputStyle>> inputStyles { get => m_InputStyles; set => m_InputStyles = value ?? new List<Container<string, InputStyle>>(); }
		public List<Container<string, ToggleStyle>> toggleStyles { get => m_ToggleStyles; set => m_ToggleStyles = value ?? new List<Container<string, ToggleStyle>>(); }
		public List<Container<string, SliderStyle>> sliderStyles { get => m_SliderStyles; set => m_SliderStyles = value ?? new List<Container<string, SliderStyle>>(); }
		public List<Container<string, DropdownStyle>> dropdownStyles { get => m_DropdownStyles; set => m_DropdownStyles = value ?? new List<Container<string, DropdownStyle>>(); }



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
			else if (typeof(T) == typeof(InputStyle))
				return GetStore(m_ButtonStyles as List<Container<string, T>>, path, safe: safe);
			else if (typeof(T) == typeof(ToggleStyle))
				return GetStore(m_ButtonStyles as List<Container<string, T>>, path, safe: safe);
			else if (typeof(T) == typeof(SliderStyle))
				return GetStore(m_ButtonStyles as List<Container<string, T>>, path, safe: safe);
			else if (typeof(T) == typeof(DropdownStyle))
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
			else if (typeof(T) == typeof(InputStyle))
				return SearchStore(m_ButtonStyles as List<Container<string, T>>, path, out style);
			else if (typeof(T) == typeof(ToggleStyle))
				return SearchStore(m_ButtonStyles as List<Container<string, T>>, path, out style);
			else if (typeof(T) == typeof(SliderStyle))
				return SearchStore(m_ButtonStyles as List<Container<string, T>>, path, out style);
			else if (typeof(T) == typeof(DropdownStyle))
				return SearchStore(m_ButtonStyles as List<Container<string, T>>, path, out style);
			throw new NotImplementedException($"Style type argument is not supported: \"{typeof(T)}\"");
		}
	}
}