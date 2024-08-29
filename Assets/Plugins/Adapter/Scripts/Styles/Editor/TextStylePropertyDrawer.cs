using UnityEditor;
using UnityEngine;

namespace Adapter.Styles.Editor
{
	[CustomPropertyDrawer(typeof(TextStyle))]
	public class TextStylePropertyDrawer : PropertyDrawer
	{
		private float singleLine => EditorGUIUtility.singleLineHeight;
		private float spacing => EditorGUIUtility.standardVerticalSpacing;



		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, singleLine), property.FindPropertyRelative("m_Font"));

			SerializedProperty extraFontProperty = property.FindPropertyRelative("m_ExtraFont");
			EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, EditorGUI.GetPropertyHeight(extraFontProperty)), extraFontProperty);

			EditorGUI.PropertyField(new Rect(position.x, position.y += EditorGUI.GetPropertyHeight(extraFontProperty) + spacing, position.width, singleLine), property.FindPropertyRelative("m_Style"));

			EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, singleLine), property.FindPropertyRelative("m_Size"));
			EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, singleLine), property.FindPropertyRelative("m_Spacing"));

			EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, singleLine), property.FindPropertyRelative("m_Alignment"));

			EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, singleLine), property.FindPropertyRelative("m_Color"));

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = singleLine * 6 + spacing * 5;

			height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_ExtraFont")) + spacing;
			height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_Color")) + spacing;

			return height;
		}
	}
}