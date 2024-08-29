using UnityEditor;
using UnityEngine;

namespace Adapter.Styles.Editor
{
	[CustomPropertyDrawer(typeof(ColorBlock))]
	public class ColorBlockPropertyDrawer : PropertyDrawer
	{
		private float singleLine => EditorGUIUtility.singleLineHeight;
		private float spacing => EditorGUIUtility.standardVerticalSpacing;



		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			SerializedProperty normalColorProperty = property.FindPropertyRelative("m_NormalColor");
			EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUI.GetPropertyHeight(normalColorProperty)), normalColorProperty);

			SerializedProperty highlightedColorProperty = property.FindPropertyRelative("m_HighlightedColor");
			EditorGUI.PropertyField(new Rect(position.x, position.y += EditorGUI.GetPropertyHeight(normalColorProperty) + spacing, position.width, EditorGUI.GetPropertyHeight(highlightedColorProperty)), highlightedColorProperty);

			SerializedProperty pressedColorProperty = property.FindPropertyRelative("m_PressedColor");
			EditorGUI.PropertyField(new Rect(position.x, position.y += EditorGUI.GetPropertyHeight(highlightedColorProperty) + spacing, position.width, EditorGUI.GetPropertyHeight(pressedColorProperty)), pressedColorProperty);

			SerializedProperty selectedColorProperty = property.FindPropertyRelative("m_SelectedColor");
			EditorGUI.PropertyField(new Rect(position.x, position.y += EditorGUI.GetPropertyHeight(pressedColorProperty) + spacing, position.width, EditorGUI.GetPropertyHeight(selectedColorProperty)), selectedColorProperty);

			SerializedProperty disabledColorProperty = property.FindPropertyRelative("m_DisabledColor");
			EditorGUI.PropertyField(new Rect(position.x, position.y += EditorGUI.GetPropertyHeight(selectedColorProperty) + spacing, position.width, EditorGUI.GetPropertyHeight(disabledColorProperty)), disabledColorProperty);

			EditorGUI.PropertyField(new Rect(position.x, position.y += EditorGUI.GetPropertyHeight(disabledColorProperty) + spacing, position.width, singleLine), property.FindPropertyRelative("m_ColorMultiplier"));
			EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, singleLine), property.FindPropertyRelative("m_FadeDuration"));

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = singleLine * 2 + spacing;

			height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_NormalColor")) + spacing;
			height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_HighlightedColor")) + spacing;
			height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_PressedColor")) + spacing;
			height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_SelectedColor")) + spacing;
			height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_DisabledColor")) + spacing;

			return height;
		}
	}
}