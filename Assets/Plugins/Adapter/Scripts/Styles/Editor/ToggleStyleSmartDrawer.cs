using Adapter.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.Styles.Editor
{
	[CustomPropertyDrawer(typeof(ToggleStyle))]
	public class ToggleStyleSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label)
		{
			SerializedProperty transitionProperty = AddProperty(property, "m_Transition");
			Selectable.Transition transition = (Selectable.Transition)transitionProperty.intValue;

			if (transition is Selectable.Transition.ColorTint)
				AddProperty(property, "m_Color");
			else if (transition is Selectable.Transition.SpriteSwap)
				AddProperty(property, "m_Sprite");
			else if (transition is Selectable.Transition.Animation)
				AddProperty(property, "m_Animation");
		}
		public override void OnSmartHeight(SerializedProperty property, GUIContent label)
		{
			SerializedProperty transitionProperty = AddPropertyHeight(property, "m_Transition", out _);
			Selectable.Transition transition = (Selectable.Transition)transitionProperty.intValue;

			if (transition is Selectable.Transition.ColorTint)
				AddPropertyHeight(property, "m_Color", out _);
			else if (transition is Selectable.Transition.SpriteSwap)
				AddPropertyHeight(property, "m_Sprite", out _);
			else if (transition is Selectable.Transition.Animation)
				AddPropertyHeight(property, "m_Animation", out _);
		}
	}
}