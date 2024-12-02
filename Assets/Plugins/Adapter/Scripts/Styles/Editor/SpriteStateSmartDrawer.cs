using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Styles.Editor
{
	[CustomPropertyDrawer(typeof(SpriteState))]
	public class SpriteStateSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label)
		{
			AddProperty(property, "m_HighlightedSprite");
			AddProperty(property, "m_PressedSprite");
			AddProperty(property, "m_SelectedSprite");
			AddProperty(property, "m_DisabledSprite");
		}
		public override void OnSmartHeight(SerializedProperty property, GUIContent label)
		{
			AddPropertyHeight(property, "m_HighlightedSprite", out _);
			AddPropertyHeight(property, "m_PressedSprite", out _);
			AddPropertyHeight(property, "m_SelectedSprite", out _);
			AddPropertyHeight(property, "m_DisabledSprite", out _);
		}
	}
}