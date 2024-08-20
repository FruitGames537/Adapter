using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.Styles
{
	[Serializable]
	public class TextStyle : IStyle<Text>
	{
		public TextStyle()
		{
			m_Font = null;
			m_ExtraFont = new List<ExtraFont>();
			m_Style = FontStyle.Normal;
			m_Size = 16;
			m_Spacing = 1;
			m_Alignment = TextAnchor.UpperLeft;
			m_Color = Color.white;
		}



		[Serializable]
		public struct ExtraFont
		{
			public ExtraFont(SystemLanguage languageCode, Font font)
			{
				m_LanguageCode = languageCode;
				m_Font = font;
			}



			[SerializeField] private SystemLanguage m_LanguageCode;
			[SerializeField] private Font m_Font;

			public SystemLanguage languageCode { get => m_LanguageCode; set => m_LanguageCode = value; }
			public Font font { get => m_Font; set => m_Font = value; }
		}



		[SerializeField] private Font m_Font;
		[SerializeField] private List<ExtraFont> m_ExtraFont;
		[SerializeField] private FontStyle m_Style;

		[SerializeField] private int m_Size;
		[SerializeField] private int m_Spacing;

		[SerializeField] private TextAnchor m_Alignment;

		[SerializeField] private Color m_Color;

		public Font font { get => m_Font; set => m_Font = value; }
		public FontStyle style { get => m_Style; set => m_Style = value; }

		public int size { get => m_Size; set => m_Size = value; }
		public int spacing { get => m_Spacing; set => m_Spacing = value; }

		public TextAnchor alignment { get => m_Alignment; set => m_Alignment = value; }

		public Color color { get => m_Color; set => m_Color = value; }



		public void AddExtraFont(SystemLanguage language, Font font) => m_ExtraFont.Add(new ExtraFont(language, font));
		public void RemoveExtraFont(SystemLanguage language) => m_ExtraFont.RemoveAll(item => item.languageCode == language);

		public void Apply(Text text) => Apply(text, null);
		public void Apply(Text text, SystemLanguage? language)
		{
			text.font = language.HasValue && m_ExtraFont.Exists(item => item.languageCode == language.Value) ? m_ExtraFont.Find(item => item.languageCode == language.Value).font : m_Font;
			text.fontStyle = m_Style;
			text.fontSize = m_Size;
			text.lineSpacing = m_Spacing;
			text.alignment = m_Alignment;
			text.color = m_Color;
		}
	}
}