using Adapter.Elements;
using System;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Adapter.Styles
{
	[Serializable]
	public class DropdownStyle : IStyle<Dropdown>
	{
		private DropdownStyle(UI.Selectable.Transition transition) => m_Transition = transition;

		public DropdownStyle(ColorBlock color) : this(UI.Selectable.Transition.ColorTint) => m_Color = color;
		public DropdownStyle(SpriteState sprite) : this(UI.Selectable.Transition.SpriteSwap) => m_Sprite = sprite;
		public DropdownStyle(UI.AnimationTriggers animation) : this(UI.Selectable.Transition.Animation) => m_Animation = animation ?? new UI.AnimationTriggers();



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



		public void Apply(Dropdown dropdown)
		{
			if (dropdown == null)
				throw new NullReferenceException("Dropdown reference does not refer to dropdown object");
			dropdown.transition = m_Transition;
			switch (m_Transition)
			{
				case UI.Selectable.Transition.ColorTint:
					dropdown.colors = m_Color.Apply(dropdown.setting);
					break;
				case UI.Selectable.Transition.SpriteSwap:
					dropdown.spriteState = m_Sprite.Apply(dropdown.setting);
					break;
				case UI.Selectable.Transition.Animation:
					dropdown.animationTriggers = m_Animation;
					break;
				case UI.Selectable.Transition.None:
				default:
					break;
			}
		}
	}
}