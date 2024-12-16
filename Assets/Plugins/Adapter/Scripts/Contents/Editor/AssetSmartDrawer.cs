using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Contents.Editor
{
	[CustomPropertyDrawer(typeof(Asset))]
	public class AssetSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label) => AddProperty(property, "m_ScriptableObject");
		public override void OnSmartHeight(SerializedProperty property, GUIContent label) => AddPropertyHeight(property, "m_ScriptableObject", out _);
	}
}