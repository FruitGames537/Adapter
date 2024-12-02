using Adapter.Editor;
using UnityEditor;
using UnityEngine;

namespace Adapter.Containers.Editor
{
	[CustomPropertyDrawer(typeof(Variation<,>))]
	public class VariationSmartDrawer : SmartDrawer
	{
		public override void OnSmartGUI(SerializedProperty property, GUIContent label)
		{
			SerializedProperty variationProperty = AddProperty(property, "m_Variation");
			VariationType variation = (VariationType)variationProperty.intValue;

			if (variation is VariationType.First)
				AddProperty(property, "m_FirstValue");
			else if (variation is VariationType.Second)
				AddProperty(property, "m_SecondValue");
		}
		public override void OnSmartHeight(SerializedProperty property, GUIContent label)
		{
			SerializedProperty variationProperty = AddPropertyHeight(property, "m_Variation", out _);
			VariationType variation = (VariationType)variationProperty.intValue;

			if (variation is VariationType.First)
				AddPropertyHeight(property, "m_FirstValue", out _);
			else if (variation is VariationType.Second)
				AddPropertyHeight(property, "m_SecondValue", out _);
		}
	}
}