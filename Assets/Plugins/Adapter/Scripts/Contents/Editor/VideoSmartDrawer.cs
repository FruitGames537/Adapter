using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Contents.Editor
{
	[CustomPropertyDrawer(typeof(Video))]
	public class VideoSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label) => AddProperty(property, "m_VideoClip");
		public override void OnSmartHeight(SerializedProperty property, GUIContent label) => AddPropertyHeight(property, "m_VideoClip", out _);
	}
}