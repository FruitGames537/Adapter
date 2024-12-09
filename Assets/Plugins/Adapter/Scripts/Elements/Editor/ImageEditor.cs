using UnityEditor;

namespace Adapter.Elements.Editor
{
	[CustomEditor(typeof(Image))]
	public class ImageEditor : UnityEditor.UI.ImageEditor
	{
		private SerializedProperty m_SettingProperty;
		private SerializedProperty m_StyleProperty;



		protected override void OnEnable()
		{
			base.OnEnable();

			m_SettingProperty = serializedObject.FindProperty("m_Setting");
			m_StyleProperty = serializedObject.FindProperty("m_Style");
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.PropertyField(m_SettingProperty);
			EditorGUILayout.PropertyField(m_StyleProperty);

			serializedObject.ApplyModifiedProperties();

			base.OnInspectorGUI();
		}
	}
}