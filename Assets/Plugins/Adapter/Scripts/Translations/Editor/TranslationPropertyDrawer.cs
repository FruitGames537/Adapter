using UnityEditor;
using UnityEngine;

namespace Adapter.Translations.Editor
{
	[CustomPropertyDrawer(typeof(Translation))]
	public class TranslationPropertyDrawer : PropertyDrawer
	{
		private float singleLine => EditorGUIUtility.singleLineHeight;
		private float spacing => EditorGUIUtility.standardVerticalSpacing;
		private float areaSize => 5;



		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			EditorGUI.LabelField(new Rect(position.x, position.y, position.width, singleLine), label);

			SerializedProperty translationProperty = property.FindPropertyRelative("m_Translation");
			translationProperty.stringValue = EditorGUI.TextArea(new Rect(position.x, position.y += singleLine + spacing, position.width, singleLine * areaSize + spacing * areaSize - spacing), translationProperty.stringValue);
			
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = singleLine;

			height += singleLine * areaSize + spacing * areaSize;

			return height;
		}
	}
}