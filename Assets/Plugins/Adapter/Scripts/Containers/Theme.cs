using Adapter.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Adapter.Containers
{
	[CreateAssetMenu(menuName = "Adapter/Container/Theme", fileName = "New Theme", order = 1)]
	public class Theme : ScriptableObject
	{
		[SerializeField] private string m_ThemeName;
		[SerializeField] private List<Container<string, Color>> m_Colors;
		[SerializeField] private List<Container<string, ImageStyle>> m_ImageStyles;
		[SerializeField] private List<Container<string, ButtonStyle>> m_ButtonStyles;
		[SerializeField] private List<Container<string, TextStyle>> m_TextStyles;

		public string themeName => m_ThemeName;
		public List<Container<string, Color>> colors => m_Colors;
		public List<Container<string, ImageStyle>> imageStyles => m_ImageStyles;
		public List<Container<string, ButtonStyle>> buttonStyles => m_ButtonStyles;
		public List<Container<string, TextStyle>> textStyles => m_TextStyles;



		public Color GetColor(string name) => FindValue(m_Colors, name);
		public T GetStyle<T>(string name) where T : class, new()
		{
			if (typeof(T) == typeof(ImageStyle))
				return FindValue(m_ImageStyles as List<Container<string, T>>, name);
			else if (typeof(T) == typeof(ButtonStyle))
				return FindValue(m_ButtonStyles as List<Container<string, T>>, name);
			else if (typeof(T) == typeof(TextStyle))
				return FindValue(m_TextStyles as List<Container<string, T>>, name);
			throw new NotImplementedException($"Cannot return style because this type not support: \"{typeof(T)}\"");
		}

		private T FindValue<T>(List<Container<string, T>> containers, string name)
		{
			string[] split = name.Split('.', 2);
			foreach (Container<string, T> container in containers)
				if (container.name == split[0])
					if (container.type is ContainerType.Container)
						return FindValue(container.container, split[1]);
					else if (container.type is ContainerType.Store)
						return container.store;
			throw new KeyNotFoundException($"Cannot find value in container by key \"{name}\"");
		}
	}
}