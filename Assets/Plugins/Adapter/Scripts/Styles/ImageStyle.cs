using System;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.Styles
{
	[Serializable]
	public class ImageStyle : IStyle<Image>
	{
		public ImageStyle()
		{
			m_CustomSprite = false;
			m_Sprite = null;
			m_Color = Color.white;
		}



		[SerializeField] private bool m_CustomSprite;
		[SerializeField] private Sprite m_Sprite;

		[SerializeField] private Color m_Color;

		public bool customSprite { get => m_CustomSprite; set => m_CustomSprite = value; }
		public Sprite sprite
		{
			get
			{
				if (!m_CustomSprite)
					return null;
				return m_Sprite;
			}
			set
			{
				if (!m_CustomSprite)
					throw new ArgumentException("Cannot set sprite because custom sprite not set to true");
				m_Sprite = value;
			}
		}

		public Color color { get => m_Color; set => m_Color = value; }



		public void Apply(Image image)
		{
			if (m_CustomSprite)
				image.sprite = m_Sprite;
			image.color = m_Color;
		}
	}
}