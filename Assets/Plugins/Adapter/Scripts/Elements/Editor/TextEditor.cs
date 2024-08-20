using UnityEditor;

namespace Adapter.Elements.Editor
{
	[CustomEditor(typeof(Text))]
	public class TextEditor : UnityEditor.UI.TextEditor
	{
		private SerializedProperty settingProperty;

		private SerializedProperty styleProperty;
		private SerializedProperty translationProperty;



		protected override void OnEnable()
		{
			base.OnEnable();

			settingProperty = serializedObject.FindProperty("m_Setting");

			styleProperty = serializedObject.FindProperty("m_Style");
			translationProperty = serializedObject.FindProperty("m_Translation");
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.PropertyField(settingProperty);

			EditorGUILayout.PropertyField(styleProperty);
			EditorGUILayout.PropertyField(translationProperty);

			serializedObject.ApplyModifiedProperties();

			base.OnInspectorGUI();
		}
	}
}