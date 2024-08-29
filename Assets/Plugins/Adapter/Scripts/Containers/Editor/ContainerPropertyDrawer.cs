using UnityEditor;
using UnityEngine;

namespace Adapter.Containers.Editor
{
	[CustomPropertyDrawer(typeof(Container<,>))]
	public class ContainerPropertyDrawer : PropertyDrawer
	{
		private float singleLine => EditorGUIUtility.singleLineHeight;
		private float spacing => EditorGUIUtility.standardVerticalSpacing;



		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			EditorGUI.LabelField(new Rect(position.x, position.y, position.width, singleLine), label);

			SerializedProperty keyProperty = property.FindPropertyRelative("m_Key");
			EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, EditorGUI.GetPropertyHeight(keyProperty)), keyProperty);

			SerializedProperty valueProperty = property.FindPropertyRelative("m_Value");
			EditorGUI.PropertyField(new Rect(position.x, position.y += EditorGUI.GetPropertyHeight(keyProperty) + spacing, position.width, EditorGUI.GetPropertyHeight(valueProperty)), valueProperty);

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = singleLine;

			height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_Key")) + spacing;
			height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("m_Value")) + spacing;

			return height;
		}
	}
}