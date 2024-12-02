using UnityEditor;
using UnityEngine;

namespace Adapter.Editor
{
	public abstract class SmartDrawer : PropertyDrawer
	{
		private float m_LastHeight = 0;
		private float m_TotalHeight = 0;

		private Rect m_TotalPosition = Rect.zero;

		private float currentOffset => m_LastHeight != 0 ? m_LastHeight + defaultSpacing : 0;
		private float currentSpacing => m_TotalHeight != 0 ? defaultSpacing : 0;

		protected float defaultHeight => EditorGUIUtility.singleLineHeight;
		protected float defaultSpacing => EditorGUIUtility.standardVerticalSpacing;

		

		public sealed override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			m_LastHeight = 0;
			m_TotalPosition = position;

			EditorGUI.BeginProperty(position, label, property);

			OnSmartGUI(property, label);

			EditorGUI.EndProperty();
		}
		public sealed override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			m_TotalHeight = 0;

			OnSmartHeight(property, label);

			return m_TotalHeight;
		}

		protected void AddLabel(GUIContent label) => EditorGUI.LabelField(new Rect(m_TotalPosition.x, m_TotalPosition.y += currentOffset, m_TotalPosition.width, m_LastHeight = defaultHeight), label);
		protected SerializedProperty AddTextArea(SerializedProperty property, string name, uint areaSize)
		{
			SerializedProperty serializedProperty = property.FindPropertyRelative(name);
			EditorGUI.PropertyField(new Rect(m_TotalPosition.x, m_TotalPosition.y += currentOffset, m_TotalPosition.width, m_LastHeight = CalculateTextAreaSize(areaSize)), serializedProperty);
			return serializedProperty;
		}
		protected SerializedProperty AddProperty(SerializedProperty property, string name)
		{
			SerializedProperty serializedProperty = property.FindPropertyRelative(name);
			EditorGUI.PropertyField(new Rect(m_TotalPosition.x, m_TotalPosition.y += currentOffset, m_TotalPosition.width, m_LastHeight = EditorGUI.GetPropertyHeight(serializedProperty)), serializedProperty);
			return serializedProperty;
		}

		protected void AddLabelHeight(GUIContent label, out float height) => m_TotalHeight += height = defaultHeight + currentSpacing;
		protected SerializedProperty AddTextAreaHeight(SerializedProperty property, string name, uint areaSize, out float height)
		{
			SerializedProperty serializedProperty = property.FindPropertyRelative(name);
			m_TotalHeight += height = CalculateTextAreaSize(areaSize) + currentSpacing;
			return serializedProperty;
		}
		protected SerializedProperty AddPropertyHeight(SerializedProperty property, string name, out float height)
		{
			SerializedProperty serializedProperty = property.FindPropertyRelative(name);
			m_TotalHeight += height = EditorGUI.GetPropertyHeight(serializedProperty) + currentSpacing;
			return serializedProperty;
		}

		private float CalculateTextAreaSize(uint areaSize) => defaultHeight + (defaultHeight + defaultSpacing) * areaSize;

		public abstract void OnSmartGUI(SerializedProperty property, GUIContent label);
		public abstract void OnSmartHeight(SerializedProperty property, GUIContent label);
	}
}