using System;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.Styles
{
	[Serializable]
	public class ButtonStyle : IStyle<Button>
	{
		public ButtonStyle()
		{
			m_Transition = Selectable.Transition.ColorTint;
			m_Color = ColorBlock.defaultColorBlock;
			m_Sprite = new SpriteState();
			m_Animation = new AnimationTriggers();
		}



		[SerializeField] private Selectable.Transition m_Transition;
		[SerializeField] private ColorBlock m_Color;
		[SerializeField] private SpriteState m_Sprite;
		[SerializeField] private AnimationTriggers m_Animation;

		public Selectable.Transition transition { get => m_Transition; set => m_Transition = value; }
		public ColorBlock? color {
			get
			{
				if (m_Transition != Selectable.Transition.ColorTint)
					return null;
				return m_Color;
			}
			set
			{
				if (m_Transition != Selectable.Transition.ColorTint)
					throw new ArgumentException("Cannot set color block because transition mode not set to color tint");
				m_Color = value.Value;
			}
		}
		public SpriteState? sprite {
			get
			{
				if (m_Transition != Selectable.Transition.SpriteSwap)
					return null;
				return m_Sprite;
			}
			set
			{
				if (m_Transition != Selectable.Transition.SpriteSwap)
					throw new ArgumentException("Cannot set color block because transition mode not set to sprite swap");
				m_Sprite = value.Value;
			}
		}
		public AnimationTriggers animation {
			get
			{
				if (m_Transition != Selectable.Transition.Animation)
					return null;
				return m_Animation;
			}
			set
			{
				if (m_Transition != Selectable.Transition.Animation)
					throw new ArgumentException("Cannot set color block because transition mode not set to animation");
				m_Animation = value;
			}
		}



		public void Apply(Button button)
		{
			button.transition = m_Transition;
			switch (m_Transition)
			{
				case Selectable.Transition.ColorTint:
					button.colors = m_Color;
					break;
				case Selectable.Transition.SpriteSwap:
					button.spriteState = m_Sprite;
					break;
				case Selectable.Transition.Animation:
					button.animationTriggers = m_Animation;
					break;
				case Selectable.Transition.None:
				default:
					break;
			}
		}
	}
}