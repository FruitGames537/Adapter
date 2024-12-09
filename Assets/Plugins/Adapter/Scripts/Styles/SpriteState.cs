using Adapter.Containers;
using System;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Adapter.Styles
{
	[Serializable]
	public struct SpriteState
	{
		public SpriteState(Variation<Sprite, string> highlightedSprite, Variation<Sprite, string> pressedSprite, Variation<Sprite, string> selectedSprite, Variation<Sprite, string> disabledSprite)
		{
			m_HighlightedSprite = highlightedSprite;
			m_PressedSprite = pressedSprite;
			m_SelectedSprite = selectedSprite;
			m_DisabledSprite = disabledSprite;
		}



		[SerializeField] private Variation<Sprite, string> m_HighlightedSprite;
		[SerializeField] private Variation<Sprite, string> m_PressedSprite;
		[SerializeField] private Variation<Sprite, string> m_SelectedSprite;
		[SerializeField] private Variation<Sprite, string> m_DisabledSprite;

		public Variation<Sprite, string> highlightedSprite { get => m_HighlightedSprite; set => m_HighlightedSprite = value; }
		public Variation<Sprite, string> pressedSprite { get => m_PressedSprite; set => m_PressedSprite = value; }
		public Variation<Sprite, string> selectedSprite { get => m_SelectedSprite; set => m_SelectedSprite = value; }
		public Variation<Sprite, string> disabledSprite { get => m_DisabledSprite; set => m_DisabledSprite = value; }



		public UI.SpriteState Apply(Setting setting)
		{
			if (setting == null)
				return new UI.SpriteState();
			UI.SpriteState spriteState = new UI.SpriteState();
			spriteState.highlightedSprite = Apply(setting, m_HighlightedSprite);
			spriteState.pressedSprite = Apply(setting, m_PressedSprite);
			spriteState.selectedSprite = Apply(setting, m_SelectedSprite);
			spriteState.disabledSprite = Apply(setting, m_DisabledSprite);
			return spriteState;
		}
		private Sprite Apply(Setting setting, Variation<Sprite, string> value)
		{
			if (setting.currentTheme != null)
				return value.variation is VariationType.First ? value.firstValue : value.variation is VariationType.Second ? setting.currentTheme.GetSprite(value.secondValue) : null;
			return null;
		}



		public static implicit operator SpriteState(UI.SpriteState spriteState) => new SpriteState(spriteState.highlightedSprite, spriteState.pressedSprite, spriteState.selectedSprite, spriteState.disabledSprite);
		public static implicit operator UI.SpriteState(SpriteState spriteState) => new UI.SpriteState() { highlightedSprite = spriteState.highlightedSprite, pressedSprite = spriteState.pressedSprite, selectedSprite = spriteState.selectedSprite, disabledSprite = spriteState.disabledSprite };
	}
}