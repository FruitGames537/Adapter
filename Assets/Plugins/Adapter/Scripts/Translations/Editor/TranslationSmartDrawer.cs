using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Translations.Editor
{
	[CustomPropertyDrawer(typeof(Translation))]
	public class TranslationSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label) => AddTextArea(property, "m_Translation", 4);
		public override void OnSmartHeight(SerializedProperty property, GUIContent label) => AddTextAreaHeight(property, "m_Translation", 4, out _);
	}
}