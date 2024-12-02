using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Styles.Editor
{
	[CustomPropertyDrawer(typeof(TextStyle))]
	public class TextStyleSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label)
		{
			AddProperty(property, "m_Font");
			AddProperty(property, "m_Extra");
			AddProperty(property, "m_Style");
			AddProperty(property, "m_Size");
			AddProperty(property, "m_Spacing");
			AddProperty(property, "m_Alignment");
			AddProperty(property, "m_Color");
		}
		public override void OnSmartHeight(SerializedProperty property, GUIContent label)
		{
			AddPropertyHeight(property, "m_Font", out _);
			AddPropertyHeight(property, "m_Extra", out _);
			AddPropertyHeight(property, "m_Style", out _);
			AddPropertyHeight(property, "m_Size", out _);
			AddPropertyHeight(property, "m_Spacing", out _);
			AddPropertyHeight(property, "m_Alignment", out _);
			AddPropertyHeight(property, "m_Color", out _);
		}
	}
}