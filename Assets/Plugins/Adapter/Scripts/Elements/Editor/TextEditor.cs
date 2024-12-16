using UnityEditor;
using UI = UnityEditor.UI;

namespace Adapter.Elements.Editor
{
	[CustomEditor(typeof(Text))]
	public class TextEditor : UI.TextEditor
	{
		private SerializedProperty m_SettingProperty;

		private SerializedProperty m_StyleProperty;
		private SerializedProperty m_TranslationProperty;

		private SerializedProperty m_UpdatableProperty;
		private SerializedProperty m_LocalizableProperty;



		protected override void OnEnable()
		{
			base.OnEnable();

			m_SettingProperty = serializedObject.FindProperty("m_Setting");

			m_StyleProperty = serializedObject.FindProperty("m_Style");
			m_TranslationProperty = serializedObject.FindProperty("m_Translation");

			m_UpdatableProperty = serializedObject.FindProperty("m_Updatable");
			m_LocalizableProperty = serializedObject.FindProperty("m_Localizable");
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.PropertyField(m_SettingProperty);

			EditorGUILayout.PropertyField(m_StyleProperty);
			EditorGUILayout.PropertyField(m_TranslationProperty);

			EditorGUILayout.PropertyField(m_UpdatableProperty);
			EditorGUILayout.PropertyField(m_LocalizableProperty);

			serializedObject.ApplyModifiedProperties();

			base.OnInspectorGUI();
		}
	}
}