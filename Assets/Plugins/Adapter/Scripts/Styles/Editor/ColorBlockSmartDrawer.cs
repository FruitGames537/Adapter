using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Styles.Editor
{
	[CustomPropertyDrawer(typeof(ColorBlock))]
	public class ColorBlockSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label)
		{
			AddProperty(property, "m_NormalColor");
			AddProperty(property, "m_HighlightedColor");
			AddProperty(property, "m_PressedColor");
			AddProperty(property, "m_SelectedColor");
			AddProperty(property, "m_DisabledColor");
			AddProperty(property, "m_ColorMultiplier");
			AddProperty(property, "m_FadeDuration");
		}
		public override void OnSmartHeight(SerializedProperty property, GUIContent label)
		{
			AddPropertyHeight(property, "m_NormalColor", out _);
			AddPropertyHeight(property, "m_HighlightedColor", out _);
			AddPropertyHeight(property, "m_PressedColor", out _);
			AddPropertyHeight(property, "m_SelectedColor", out _);
			AddPropertyHeight(property, "m_DisabledColor", out _);
			AddPropertyHeight(property, "m_ColorMultiplier", out _);
			AddPropertyHeight(property, "m_FadeDuration", out _);
		}
	}
}