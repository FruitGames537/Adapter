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

			if (property.FindPropertyRelative("m_Key") is SerializedProperty keyProperty)
				EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, EditorGUI.GetPropertyHeight(keyProperty)), keyProperty);
			if (property.FindPropertyRelative("m_Value") is SerializedProperty valueProperty)
				EditorGUI.PropertyField(new Rect(position.x, position.y += singleLine + spacing, position.width, EditorGUI.GetPropertyHeight(valueProperty)), valueProperty);

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = singleLine + spacing;

			if (property.FindPropertyRelative("m_Key") is SerializedProperty keyProperty)
				height += EditorGUI.GetPropertyHeight(keyProperty);
			if (property.FindPropertyRelative("m_Value") is SerializedProperty valueProperty)
				height += EditorGUI.GetPropertyHeight(valueProperty);
			if (property.FindPropertyRelative("m_Key") is not null && property.FindPropertyRelative("m_Value") is not null)
				height += spacing;

			return height;
		}
	}
}