using Adapter.Elements;
using System;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Adapter.Styles
{
	[Serializable]
	public class ButtonStyle : IStyle<Button>
	{
		private ButtonStyle(UI.Selectable.Transition transition) => m_Transition = transition;

		public ButtonStyle(ColorBlock color) : this(UI.Selectable.Transition.ColorTint) => m_Color = color;
		public ButtonStyle(SpriteState sprite) : this(UI.Selectable.Transition.SpriteSwap) => m_Sprite = sprite;
		public ButtonStyle(UI.AnimationTriggers animation) : this(UI.Selectable.Transition.Animation) => m_Animation = animation ?? new UI.AnimationTriggers();



		[SerializeField] private UI.Selectable.Transition m_Transition = UI.Selectable.Transition.ColorTint;

		[SerializeField] private ColorBlock m_Color = ColorBlock.defaultColorBlock;
		[SerializeField] private SpriteState m_Sprite = new SpriteState();
		[SerializeField] private UI.AnimationTriggers m_Animation = new UI.AnimationTriggers();

		public UI.Selectable.Transition transition { get => m_Transition; set => m_Transition = value; }

		public ColorBlock? color {
			get
			{
				if (m_Transition != UI.Selectable.Transition.ColorTint)
					return null;
				return m_Color;
			}
			set
			{
				if (m_Transition != UI.Selectable.Transition.ColorTint)
					throw new ArgumentException("Transition mode is not set to color tint");
				m_Color = value.Value;
			}
		}
		public SpriteState? sprite {
			get
			{
				if (m_Transition != UI.Selectable.Transition.SpriteSwap)
					return null;
				return m_Sprite;
			}
			set
			{
				if (m_Transition != UI.Selectable.Transition.SpriteSwap)
					throw new ArgumentException("Transition mode is not set to sprite swap");
				m_Sprite = value.Value;
			}
		}
		public UI.AnimationTriggers animation {
			get
			{
				if (m_Transition != UI.Selectable.Transition.Animation)
					return null;
				return m_Animation;
			}
			set
			{
				if (m_Transition != UI.Selectable.Transition.Animation)
					throw new ArgumentException("Transition mode is not set to animation");
				m_Animation = value;
			}
		}



		public void Apply(Button button)
		{
			if (button == null)
				throw new NullReferenceException("Button reference does not refer to button object");
			button.transition = m_Transition;
			switch (m_Transition)
			{
				case UI.Selectable.Transition.ColorTint:
					button.colors = m_Color.Apply(button.setting);
					break;
				case UI.Selectable.Transition.SpriteSwap:
					button.spriteState = m_Sprite.Apply(button.setting);
					break;
				case UI.Selectable.Transition.Animation:
					button.animationTriggers = m_Animation;
					break;
				case UI.Selectable.Transition.None:
				default:
					break;
			}
		}
	}
}