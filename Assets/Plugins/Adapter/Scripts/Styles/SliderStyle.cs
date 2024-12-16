using Adapter.Elements;
using System;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Adapter.Styles
{
	[Serializable]
	public class SliderStyle : IStyle<Slider>
	{
		private SliderStyle(UI.Selectable.Transition transition) => m_Transition = transition;

		public SliderStyle(ColorBlock color) : this(UI.Selectable.Transition.ColorTint) => m_Color = color;
		public SliderStyle(SpriteState sprite) : this(UI.Selectable.Transition.SpriteSwap) => m_Sprite = sprite;
		public SliderStyle(UI.AnimationTriggers animation) : this(UI.Selectable.Transition.Animation) => m_Animation = animation ?? new UI.AnimationTriggers();



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



		public void Apply(Slider slider)
		{
			if (slider == null)
				throw new NullReferenceException("Slider reference does not refer to slider object");
			slider.transition = m_Transition;
			switch (m_Transition)
			{
				case UI.Selectable.Transition.ColorTint:
					slider.colors = m_Color.Apply(slider.setting);
					break;
				case UI.Selectable.Transition.SpriteSwap:
					slider.spriteState = m_Sprite.Apply(slider.setting);
					break;
				case UI.Selectable.Transition.Animation:
					slider.animationTriggers = m_Animation;
					break;
				case UI.Selectable.Transition.None:
				default:
					break;
			}
		}
	}
}