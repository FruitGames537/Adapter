using UnityEditor;
using UnityEngine;

namespace Adapter.Styles.Editor
{
	[CustomPropertyDrawer(typeof(ImageStyle))]
	public class imageStylePropertyDrawer : PropertyDrawer
	{
		private float singleLine => EditorGUIUtility.singleLineHeight;
		private float spacing => EditorGUIUtility.standardVerticalSpacing;



		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, singleLine), property.FindPropertyRelative("m_CustomSprite"));
			bool customSprite = property.FindPropertyRelative("m_CustomSprite").boolValue;

			if (customSprite)
				EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, singleLine), property.FindPropertyRelative("m_Sprite"));

			EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, singleLine), property.FindPropertyRelative("m_Color"));

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = singleLine + spacing;

			bool customSprite = property.FindPropertyRelative("m_CustomSprite").boolValue;
			if (customSprite)
				height += singleLine + spacing;
			height += singleLine;

			return height;
		}
	}
}