using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Contents.Editor
{
	[CustomPropertyDrawer(typeof(Audio))]
	public class AudioSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label) => AddProperty(property, "m_AudioClip");
		public override void OnSmartHeight(SerializedProperty property, GUIContent label) => AddPropertyHeight(property, "m_AudioClip", out _);
	}
}