using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Contents.Editor
{
	[CustomPropertyDrawer(typeof(Document))]
	public class DocumentSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label) => AddProperty(property, "m_TextAsset");
		public override void OnSmartHeight(SerializedProperty property, GUIContent label) => AddPropertyHeight(property, "m_TextAsset", out _);
	}
}