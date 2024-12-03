using Adapter.Containers;
using Adapter.Elements;
using System;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Adapter.Styles
{
	[Serializable]
	public struct ColorBlock
	{
		public ColorBlock(Variation<Color, string> normalColor, Variation<Color, string> highlightedColor, Variation<Color, string> pressedColor, Variation<Color, string> selectedColor, Variation<Color, string> disabledColor, float colorMultiplier, float fadeDuration)
		{
			m_NormalColor = normalColor;
			m_HighlightedColor = highlightedColor;
			m_PressedColor = pressedColor;
			m_SelectedColor = selectedColor;
			m_DisabledColor = disabledColor;
			m_ColorMultiplier = colorMultiplier;
			m_FadeDuration = fadeDuration;
		}



		[SerializeField] private Variation<Color, string> m_NormalColor;
		[SerializeField] private Variation<Color, string> m_HighlightedColor;
		[SerializeField] private Variation<Color, string> m_PressedColor;
		[SerializeField] private Variation<Color, string> m_SelectedColor;
		[SerializeField] private Variation<Color, string> m_DisabledColor;

		[SerializeField, Range(1, 5)] private float m_ColorMultiplier;
		[SerializeField] private float m_FadeDuration;

		public Variation<Color, string> normalColor { get => m_NormalColor; set => m_NormalColor = value; }
		public Variation<Color, string> highlightedColor { get => m_HighlightedColor; set => m_HighlightedColor = value; }
		public Variation<Color, string> pressedColor { get => m_PressedColor; set => m_PressedColor = value; }
		public Variation<Color, string> selectedColor { get => m_SelectedColor; set => m_SelectedColor = value; }
		public Variation<Color, string> disabledColor { get => m_DisabledColor; set => m_DisabledColor = value; }

		public float colorMultiplier { get => m_ColorMultiplier; set => m_ColorMultiplier = value; }
		public float fadeDuration { get => m_FadeDuration; set => m_FadeDuration = value; }
		
		public static readonly ColorBlock defaultColorBlock = UI.ColorBlock.defaultColorBlock;



		public UI.ColorBlock Apply(Button button)
		{
			if (button == null)
				return UI.ColorBlock.defaultColorBlock;
			UI.ColorBlock colorBlock = new UI.ColorBlock();
			colorBlock.normalColor = Apply(button, defaultColorBlock.normalColor, m_NormalColor);
			colorBlock.highlightedColor = Apply(button, defaultColorBlock.highlightedColor, m_HighlightedColor);
			colorBlock.pressedColor = Apply(button, defaultColorBlock.pressedColor, m_PressedColor);
			colorBlock.selectedColor = Apply(button, defaultColorBlock.selectedColor, m_SelectedColor);
			colorBlock.disabledColor = Apply(button, defaultColorBlock.disabledColor, m_DisabledColor);
			colorBlock.colorMultiplier = m_ColorMultiplier;
			colorBlock.fadeDuration = m_FadeDuration;
			return colorBlock;
		}
		private Color Apply(Button button, Color color, Variation<Color, string> value)
		{
			if (button.setting != null && button.setting.currentTheme != null)
				return value.variation is VariationType.First ? value.firstValue : button.setting.currentTheme.GetColor(value.secondValue);
			return color;
		}

		public static implicit operator ColorBlock(UI.ColorBlock colorBlock) => new ColorBlock(colorBlock.normalColor, colorBlock.highlightedColor, colorBlock.pressedColor, colorBlock.selectedColor, colorBlock.disabledColor, colorBlock.colorMultiplier, colorBlock.fadeDuration);
		public static implicit operator UI.ColorBlock(ColorBlock colorBlock) => new UI.ColorBlock() { normalColor = colorBlock.normalColor, highlightedColor = colorBlock.highlightedColor, pressedColor = colorBlock.pressedColor, selectedColor = colorBlock.selectedColor, disabledColor = colorBlock.disabledColor, colorMultiplier = colorBlock.colorMultiplier, fadeDuration = colorBlock.fadeDuration };
	}
}