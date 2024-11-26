using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.Styles.Editor
{
	[CustomPropertyDrawer(typeof(ButtonStyle))]
	public class ButtonStylePropertyDrawer : PropertyDrawer
	{
		private float singleLine => EditorGUIUtility.singleLineHeight;
		private float spacing => EditorGUIUtility.standardVerticalSpacing;



		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			SerializedProperty transitionProperty = property.FindPropertyRelative("m_Transition");
			EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, singleLine), transitionProperty);
			Selectable.Transition transition = (Selectable.Transition)transitionProperty.intValue;

			if (transition is Selectable.Transition.ColorTint && property.FindPropertyRelative("m_Color") is SerializedProperty colorProperty)
				EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, EditorGUI.GetPropertyHeight(colorProperty)), colorProperty);
			else if (transition is Selectable.Transition.SpriteSwap && property.FindPropertyRelative("m_Sprite") is SerializedProperty spriteProperty)
				EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, EditorGUI.GetPropertyHeight(spriteProperty)), spriteProperty);
			else if (transition is Selectable.Transition.Animation && property.FindPropertyRelative("m_Animation") is SerializedProperty animationProperty)
				EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, EditorGUI.GetPropertyHeight(animationProperty)), animationProperty);

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = singleLine;

			Selectable.Transition transition = (Selectable.Transition)property.FindPropertyRelative("m_Transition").intValue;
			if (transition is Selectable.Transition.ColorTint)
				height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_Color")) + spacing;
			else if (transition is Selectable.Transition.SpriteSwap)
				height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_Sprite")) + spacing;
			else if (transition is Selectable.Transition.Animation)
				height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_Animation")) + spacing;

			return height;
		}
	}
}