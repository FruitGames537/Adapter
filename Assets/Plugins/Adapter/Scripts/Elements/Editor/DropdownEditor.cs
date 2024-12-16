using UnityEditor;
using UI = UnityEditor.UI;

namespace Adapter.Elements.Editor
{
	[CustomEditor(typeof(Dropdown))]
	public class DropdownEditor : UI.DropdownEditor
	{
		private SerializedProperty m_SettingProperty;

		private SerializedProperty m_StyleProperty;
		private SerializedProperty m_TranslationProperty;



		protected override void OnEnable()
		{
			base.OnEnable();

			m_SettingProperty = serializedObject.FindProperty("m_Setting");

			m_StyleProperty = serializedObject.FindProperty("m_Style");
			m_TranslationProperty = serializedObject.FindProperty("m_Translation");
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.PropertyField(m_SettingProperty);

			EditorGUILayout.PropertyField(m_StyleProperty);
			EditorGUILayout.PropertyField(m_TranslationProperty);

			serializedObject.ApplyModifiedProperties();

			base.OnInspectorGUI();
		}
	}
}