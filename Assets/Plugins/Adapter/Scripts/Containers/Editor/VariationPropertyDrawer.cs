using UnityEditor;
using UnityEngine;

namespace Adapter.Containers.Editor
{
	[CustomPropertyDrawer(typeof(Variation<,>))]
	public class VariationPropertyDrawer : PropertyDrawer
	{
		private float singleLine => EditorGUIUtility.singleLineHeight;
		private float spacing => EditorGUIUtility.standardVerticalSpacing;



		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, singleLine), property.FindPropertyRelative("m_Type"));
			VariationType type = (VariationType)property.FindPropertyRelative("m_Type").intValue;

			if (type is VariationType.One && property.FindPropertyRelative("m_OneValue") is SerializedProperty oneValueProperty)
				EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, EditorGUI.GetPropertyHeight(oneValueProperty)), oneValueProperty, new GUIContent("Value"));
			else if (type is VariationType.Two && property.FindPropertyRelative("m_TwoValue") is SerializedProperty twoValueProperty)
				EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, EditorGUI.GetPropertyHeight(twoValueProperty)), twoValueProperty, new GUIContent("Value"));

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = singleLine + spacing;

			VariationType type = (VariationType)property.FindPropertyRelative("m_Type").intValue;
			if (type is VariationType.One && property.FindPropertyRelative("m_OneValue") is SerializedProperty oneValueProperty)
				height += EditorGUI.GetPropertyHeight(oneValueProperty);
			else if (type is VariationType.Two && property.FindPropertyRelative("m_TwoValue") is SerializedProperty twoValueProperty)
				height += EditorGUI.GetPropertyHeight(twoValueProperty);

			return height;
		}
	}
}