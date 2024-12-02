using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Styles.Editor
{
	[CustomPropertyDrawer(typeof(ImageStyle))]
	public class ImageStyleSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label)
		{
			if (AddProperty(property, "m_CustomSprite").boolValue)
				AddProperty(property, "m_Sprite");
			AddProperty(property, "m_Color");
		}
		public override void OnSmartHeight(SerializedProperty property, GUIContent label)
		{
			if (AddPropertyHeight(property, "m_CustomSprite", out _).boolValue)
				AddPropertyHeight(property, "m_Sprite", out _);
			AddPropertyHeight(property, "m_Color", out _);
		}
	}
}