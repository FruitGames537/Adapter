using Adapter.Containers;
using Adapter.Elements;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Styles
{
	[Serializable]
	public class TextStyle : IStyle<Text>
	{
		[Serializable]
		public struct Extra
		{
			public Extra(SystemLanguage languageCode, Font font)
			{
				m_LanguageCode = languageCode;
				m_Font = font;
			}



			[SerializeField] private SystemLanguage m_LanguageCode;
			[SerializeField] private Font m_Font;

			public SystemLanguage languageCode { get => m_LanguageCode; set => m_LanguageCode = value; }
			public Font font { get => m_Font; set => m_Font = value; }
		}



		public TextStyle(Font font, List<Extra> extra, FontStyle style, int size, int spacing, TextAnchor alignment, Variation<Color, string> color)
		{
			m_Font = font ?? null;
			m_Extra = extra ?? new List<Extra>();
			m_Style = style;
			m_Size = size;
			m_Spacing = spacing;
			m_Alignment = alignment;
			m_Color = color;
		}



		[SerializeField] private Font m_Font = null;
		[SerializeField] private List<Extra> m_Extra = new List<Extra>();
		[SerializeField] private FontStyle m_Style = FontStyle.Normal;

		[SerializeField] private int m_Size = 16;
		[SerializeField] private int m_Spacing = 1;

		[SerializeField] private TextAnchor m_Alignment = TextAnchor.UpperLeft;

		[SerializeField] private Variation<Color, string> m_Color = Color.white;

		public Font font { get => m_Font; set => m_Font = value; }
		public List<Extra> extra { get => m_Extra; set => m_Extra = value ?? new List<Extra>(); }
		public FontStyle style { get => m_Style; set => m_Style = value; }

		public int size { get => m_Size; set => m_Size = value; }
		public int spacing { get => m_Spacing; set => m_Spacing = value; }

		public TextAnchor alignment { get => m_Alignment; set => m_Alignment = value; }

		public Variation<Color, string> color { get => m_Color; set => m_Color = value; }



		public void AddFont(SystemLanguage language, Font font) => m_Extra.Add(new Extra(language, font));
		public void RemoveFont(SystemLanguage language) => m_Extra.RemoveAll(item => item.languageCode == language);

		public void Apply(Text text) => Apply(text, null);
		public void Apply(Text text, SystemLanguage? language)
		{
			if (text == null)
				throw new NullReferenceException("Text reference does not refer to text object");
			text.font = language.HasValue && m_Extra.Exists(item => item.languageCode == language.Value) ? m_Extra.Find(item => item.languageCode == language.Value).font : m_Font;
			text.fontStyle = m_Style;
			text.fontSize = m_Size;
			text.lineSpacing = m_Spacing;
			text.alignment = m_Alignment;
			if (text.setting != null && text.setting.currentTheme != null)
				text.color = m_Color.variation is VariationType.First ? m_Color.firstValue : text.setting.currentTheme.GetColor(m_Color.secondValue);
			else
				text.color = Color.black;
		}
	}
}