using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Containers.Editor
{
	[CustomPropertyDrawer(typeof(Container<,>))]
	public class ContainerSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label)
		{
			AddLabel(label);
			AddProperty(property, "m_Key");
			AddProperty(property, "m_Value");
		}
		public override void OnSmartHeight(SerializedProperty property, GUIContent label)
		{
			AddLabelHeight(label, out _);
			AddPropertyHeight(property, "m_Key", out _);
			AddPropertyHeight(property, "m_Value", out _);
		}
	}
}