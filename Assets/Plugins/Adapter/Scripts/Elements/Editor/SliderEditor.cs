using UnityEditor;
using UI = UnityEditor.UI;

namespace Adapter.Elements.Editor
{
	[CustomEditor(typeof(Slider))]
	public class SliderEditor : UI.SliderEditor
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