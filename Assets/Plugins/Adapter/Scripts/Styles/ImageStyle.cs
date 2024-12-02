using Adapter.Containers;
using Adapter.Elements;
using System;
using UnityEngine;

namespace Adapter.Styles
{
	[Serializable]
	public class ImageStyle : IStyle<Image>
	{
		public ImageStyle(Variation<Sprite, string> sprite, Variation<Color, string> color)
		{
			m_CustomSprite = sprite != (Sprite)null;
			m_Sprite = sprite;
			m_Color = color;
		}



		[SerializeField] private bool m_CustomSprite = false;
		[SerializeField] private Variation<Sprite, string> m_Sprite = (Sprite)null;

		[SerializeField] private Variation<Color, string> m_Color = Color.white;

		public bool customSprite { get => m_CustomSprite; set => m_CustomSprite = value; }
		public Variation<Sprite, string> sprite
		{
			get
			{
				if (!m_CustomSprite)
					return (Sprite)null;
				return m_Sprite;
			}
			set
			{
				if (!m_CustomSprite)
					throw new ArgumentException("Custom sprite is not set to true");
				m_Sprite = value;
			}
		}

		public Variation<Color, string> color { get => m_Color; set => m_Color = value; }



		public void Apply(Image image)
		{
			if (image == null)
				throw new NullReferenceException("Image reference does not refer to image object");
			if (m_CustomSprite && image.setting != null && image.setting.currentTheme != null)
				image.sprite = m_Sprite.variation is VariationType.First ? m_Sprite.firstValue : image.setting.currentTheme.GetSprite(m_Sprite.secondValue);
			else if (m_CustomSprite)
				image.sprite = (Sprite)null;
			if (image.setting != null && image.setting.currentTheme != null)
				image.color = m_Color.variation is VariationType.First ? m_Color.firstValue : image.setting.currentTheme.GetColor(m_Color.secondValue);
			else
				image.color = Color.white;
		}
	}
}
