using UnityEditor;
using UnityEngine;

namespace Adapter.Elements.Editor
{
	public class TextCreationWindow : ContextWindow
	{
		private RectTransform m_RectTransform;

		private string m_NameValue;

		private Vector3 m_PositionValue;
		private Vector2 m_SizeValue;
		private Vector3 m_RotationValue;

		private Setting m_SettingValue;

		private string m_StyleValue;
		private string m_TranslationValue;

		private string m_TextValue;

		private Font m_FontValue;
		private FontStyle m_FontStyleValue;

		private int m_FontSizeValue;
		private int m_FontSpacingValue;

		private TextAnchor m_FontAlignmentValue;

		private Color m_FontColorValue;

		public RectTransform rectTransform { get => m_RectTransform; set => m_RectTransform = value; }

		public string nameValue { get => m_NameValue; set => m_NameValue = value; }

		public Vector3 positionValue { get => m_PositionValue; set => m_PositionValue = value; }
		public Vector2 sizeValue { get => m_SizeValue; set => m_SizeValue = value; }
		public Vector3 rotationValue { get => m_RotationValue; set => m_RotationValue = value; }

		public Setting settingValue { get => m_SettingValue; set => m_SettingValue = value; }

		public string styleValue { get => m_StyleValue; set => m_StyleValue = value; }
		public string translationValue { get => m_TranslationValue; set => m_TranslationValue = value; }

		public string textValue { get => m_TextValue; set => m_TextValue = value; }

		public Font fontValue { get => m_FontValue; set => m_FontValue = value; }
		public FontStyle fontStyleValue { get => m_FontStyleValue; set => m_FontStyleValue = value; }

		public int fontSizeValue { get => m_FontSizeValue; set => m_FontSizeValue = value; }
		public int fontSpacingValue { get => m_FontSpacingValue; set => m_FontSpacingValue = value; }

		public TextAnchor fontAlignmentValue { get => m_FontAlignmentValue; set => m_FontAlignmentValue = value; }

		public Color fontColorValue { get => m_FontColorValue; set => m_FontColorValue = value; }



		private void OnEnable()
		{
			titleContent = new GUIContent("Text Creation");
			minSize = maxSize = new Vector2(320, 640);
			m_RectTransform = Selection.activeGameObject ? Selection.activeGameObject.GetComponent<RectTransform>() : null;

			m_NameValue = "Adaptive Text";
			m_PositionValue = Vector3.zero;
			m_SizeValue = new Vector2(160, 30);
			m_RotationValue = Vector3.zero;
			m_TextValue = "Adaptive Text";
			m_FontValue = AssetDatabase.LoadAssetAtPath<Font>("Assets/Plugins/Adapter/Fonts/Arial/Regular.ttf");
			m_FontStyleValue = FontStyle.Normal;
			m_FontSizeValue = 16;
			m_FontSpacingValue = 1;
			m_FontAlignmentValue = TextAnchor.UpperLeft;
			m_FontColorValue = Color.black;
		}

		private void OnGUI()
		{
			m_NameValue = EditorGUILayout.TextField("Name", m_NameValue);

			m_PositionValue = EditorGUILayout.Vector3Field("Position", m_PositionValue);
			m_SizeValue = EditorGUILayout.Vector2Field("Size", m_SizeValue);
			m_RotationValue = EditorGUILayout.Vector3Field("Rotation", m_RotationValue);

			m_SettingValue = (Setting)EditorGUILayout.ObjectField("Setting", m_SettingValue, typeof(Setting), true);

			m_StyleValue = EditorGUILayout.TextField("Style Name", m_StyleValue);
			m_TranslationValue = EditorGUILayout.TextField("Translation Key", m_TranslationValue);

			m_TextValue = EditorGUILayout.TextField("Text", m_TextValue);

			m_FontValue = (Font)EditorGUILayout.ObjectField("Font", m_FontValue, typeof(Font), true);
			m_FontStyleValue = (FontStyle)EditorGUILayout.EnumPopup("Font Style", m_FontStyleValue);

			m_FontSizeValue = EditorGUILayout.IntField("Font Size", m_FontSizeValue);
			m_FontSpacingValue = EditorGUILayout.IntField("Font Spacing", m_FontSpacingValue);

			m_FontAlignmentValue = (TextAnchor)EditorGUILayout.EnumPopup("Font Alignment", m_FontAlignmentValue);

			m_FontColorValue = EditorGUILayout.ColorField("Font Color", m_FontColorValue);

			if (GUILayout.Button("Create Text"))
			{
				GameObject creation = new GameObject(m_NameValue);
				RectTransform transform = creation.AddComponent<RectTransform>();
				transform.position = m_RectTransform != null ? m_RectTransform.TransformPoint(m_PositionValue) : context.transform.TransformPoint(m_PositionValue);
				transform.sizeDelta = m_SizeValue;
				transform.rotation = Quaternion.Euler(m_RotationValue);
				Text text = creation.AddComponent<Text>();
				text.setting = m_SettingValue;
				text.style = m_StyleValue;
				text.translation = m_TranslationValue;
				text.text = m_TextValue;
				text.font = m_FontValue;
				text.fontStyle = m_FontStyleValue;
				text.fontSize = m_FontSizeValue;
				text.lineSpacing = m_FontSpacingValue;
				text.alignment = m_FontAlignmentValue;
				text.color = m_FontColorValue;
				if (m_Context != null)
					creation.transform.SetParent(m_Context.transform);
				creation.transform.localScale = Vector3.one;
				Close();
			}
		}
	}
}