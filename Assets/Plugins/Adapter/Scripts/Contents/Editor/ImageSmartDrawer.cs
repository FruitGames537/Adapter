using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Contents.Editor
{
	[CustomPropertyDrawer(typeof(Image))]
	public class ImageSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label) => AddProperty(property, "m_Texture");
		public override void OnSmartHeight(SerializedProperty property, GUIContent label) => AddPropertyHeight(property, "m_Texture", out _);
	}
}