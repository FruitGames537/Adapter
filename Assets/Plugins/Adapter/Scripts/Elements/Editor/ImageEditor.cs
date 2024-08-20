using UnityEditor;

namespace Adapter.Elements.Editor
{
	[CustomEditor(typeof(Image))]
	public class ImageEditor : UnityEditor.UI.ImageEditor
	{
		private SerializedProperty settingProperty;
		private SerializedProperty styleProperty;



		protected override void OnEnable()
		{
			base.OnEnable();

			settingProperty = serializedObject.FindProperty("m_Setting");
			styleProperty = serializedObject.FindProperty("m_Style");
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.PropertyField(settingProperty);
			EditorGUILayout.PropertyField(styleProperty);

			serializedObject.ApplyModifiedProperties();

			base.OnInspectorGUI();
		}
	}
}