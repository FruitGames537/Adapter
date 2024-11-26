using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.Elements.Editor
{
	public class ButtonCreationWindow : ContextWindow
	{
		private RectTransform m_RectTransform;

		private string m_ButtonNameValue;
		private string m_TextNameValue;

		private Vector3 m_PositionValue;
		private Vector2 m_SizeValue;
		private Vector3 m_RotationValue;

		private Setting m_SettingValue;

		private string m_ImageStyleValue;
		private string m_ButtonStyleValue;
		private string m_TextStyleValue;
		private string m_TranslationValue;

		private Sprite m_SpriteValue;
		private Color m_ColorValue;

		private Selectable.Transition m_TransitionValue;
		private ColorBlock m_ColorBlockValue;
		private SpriteState m_SpriteStateValue;
		private AnimationTriggers m_AnimationValue;

		private string m_TextValue;

		private Font m_FontValue;
		private FontStyle m_FontStyleValue;

		private int m_FontSizeValue;
		private int m_FontSpacingValue;

		private TextAnchor m_FontAlignmentValue;

		private Color m_FontColorValue;

		public RectTransform rectTransform { get => m_RectTransform; set => m_RectTransform = value; }

		public string buttonNameValue { get => m_ButtonNameValue; set => m_ButtonNameValue = value; }
		public string textNameValue { get => m_TextNameValue; set => m_TextNameValue = value; }

		public Vector3 positionValue { get => m_PositionValue; set => m_PositionValue = value; }
		public Vector2 sizeValue { get => m_SizeValue; set => m_SizeValue = value; }
		public Vector3 rotationValue { get => m_RotationValue; set => m_RotationValue = value; }

		public Setting settingValue { get => m_SettingValue; set => m_SettingValue = value; }

		public string imageStyleValue { get => m_ImageStyleValue; set => m_ImageStyleValue = value; }
		public string buttonCtyleValue { get => m_ButtonStyleValue; set => m_ButtonStyleValue = value; }
		public string textCtyleValue { get => m_TextStyleValue; set => m_TextStyleValue = value; }
		public string translationValue { get => m_TranslationValue; set => m_TranslationValue = value; }

		public Sprite spriteValue { get => m_SpriteValue; set => m_SpriteValue = value; }
		public Color colorValue { get => m_ColorValue; set => m_ColorValue = value; }

		public Selectable.Transition transitionValue { get => m_TransitionValue; set => m_TransitionValue = value; }
		public ColorBlock colorBlockValue { get => m_ColorBlockValue; set => m_ColorBlockValue = value; }
		public SpriteState spriteStateValue { get => m_SpriteStateValue; set => m_SpriteStateValue = value; }
		public AnimationTriggers animationValue { get => m_AnimationValue; set => m_AnimationValue = value; }
		
		public string textValue { get => m_TextValue; set => m_TextValue = value; }

		public Font fontValue { get => m_FontValue; set => m_FontValue = value; }
		public FontStyle fontStyleValue { get => m_FontStyleValue; set => m_FontStyleValue = value; }

		public int fontSizeValue { get => m_FontSizeValue; set => m_FontSizeValue = value; }
		public int fontSpacingValue { get => m_FontSpacingValue; set => m_FontSpacingValue = value; }

		public TextAnchor fontAlignmentValue { get => m_FontAlignmentValue; set => m_FontAlignmentValue = value; }

		public Color fontColorValue { get => m_FontColorValue; set => m_FontColorValue = value; }



		private void OnEnable()
		{
			titleContent = new GUIContent("Button Creation");
			minSize = maxSize = new Vector2(320, 640);
			m_RectTransform = Selection.activeGameObject?.GetComponent<RectTransform>();

			m_ButtonNameValue = "Adaptive Button";
			m_TextNameValue = "Adaptive Text";
			m_PositionValue = Vector3.zero;
			m_SizeValue = new Vector2(160, 30);
			m_RotationValue = Vector3.zero;
			m_SpriteValue = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Plugins/Adapter/Sprites/Raster/Small/Round128.png");
			m_ColorValue = Color.white;
			m_TransitionValue = Selectable.Transition.ColorTint;
			m_ColorBlockValue = ColorBlock.defaultColorBlock;
			m_SpriteStateValue = new SpriteState();
			m_AnimationValue = new AnimationTriggers();
			m_TextValue = "Adaptive Button";
			m_FontValue = AssetDatabase.LoadAssetAtPath<Font>("Assets/Plugins/Adapter/Fonts/Arial/Regular.ttf");
			m_FontStyleValue = FontStyle.Normal;
			m_FontSizeValue = 16;
			m_FontSpacingValue = 1;
			m_FontAlignmentValue = TextAnchor.UpperLeft;
			m_FontColorValue = Color.black;
		}

		private void OnGUI()
		{
			m_ButtonNameValue = EditorGUILayout.TextField("Button Name", m_ButtonNameValue);
			m_TextNameValue = EditorGUILayout.TextField("Text Name", m_TextNameValue);

			m_PositionValue = EditorGUILayout.Vector3Field("Position", m_PositionValue);
			m_SizeValue = EditorGUILayout.Vector2Field("Size", m_SizeValue);
			m_RotationValue = EditorGUILayout.Vector3Field("Rotation", m_RotationValue);

			m_SettingValue = (Setting)EditorGUILayout.ObjectField("Setting", m_SettingValue, typeof(Setting), true);

			m_ImageStyleValue = EditorGUILayout.TextField("Image Style Name", m_ImageStyleValue);
			m_ButtonStyleValue = EditorGUILayout.TextField("Button Style Name", m_ButtonStyleValue);
			m_TextStyleValue = EditorGUILayout.TextField("Text Style Name", m_TextStyleValue);
			m_TranslationValue = EditorGUILayout.TextField("Translation Key", m_TranslationValue);

			m_SpriteValue = (Sprite)EditorGUILayout.ObjectField("Sprite", m_SpriteValue, typeof(Sprite), true);
			m_ColorValue = EditorGUILayout.ColorField("Color", m_ColorValue);

			m_TransitionValue = (Selectable.Transition)EditorGUILayout.EnumPopup("Transition", m_TransitionValue);
			switch (m_TransitionValue)
			{
				case Selectable.Transition.ColorTint:
					//m_ColorBlockValue = (ColorBlock)EditorGUILayout.ObjectField("Color Block", m_ColorBlockValue, typeof(ColorBlock));
					break;
				case Selectable.Transition.SpriteSwap:
					//m_SpriteStateValue = (SpriteState)EditorGUILayout.ObjectField("Sprite State", m_SpriteStateValue, typeof(SpriteState));
					break;
				case Selectable.Transition.Animation:
					//m_AnimationValue = (AnimationTriggers)EditorGUILayout.ObjectField("Animation", m_AnimationValue, typeof(AnimationTriggers));
					break;
				case Selectable.Transition.None:
				default:
					break;
			}

			m_TextValue = EditorGUILayout.TextField("Text", m_TextValue);

			m_FontValue = (Font)EditorGUILayout.ObjectField("Font", m_FontValue, typeof(Font), true);
			m_FontStyleValue = (FontStyle)EditorGUILayout.EnumPopup("Font Style", m_FontStyleValue);

			m_FontSizeValue = EditorGUILayout.IntField("Font Size", m_FontSizeValue);
			m_FontSpacingValue = EditorGUILayout.IntField("Font Spacing", m_FontSpacingValue);

			m_FontAlignmentValue = (TextAnchor)EditorGUILayout.EnumPopup("Font Alignment", m_FontAlignmentValue);

			m_FontColorValue = EditorGUILayout.ColorField("Font Color", m_FontColorValue);

			if (GUILayout.Button("Create Button"))
			{
				GameObject creation = new GameObject(m_ButtonNameValue);
				RectTransform transform = creation.AddComponent<RectTransform>();
				transform.position = m_RectTransform?.TransformPoint(m_PositionValue) ?? context.transform.TransformPoint(m_PositionValue);
				transform.sizeDelta = m_SizeValue;
				transform.rotation = Quaternion.Euler(m_RotationValue);
				Image image = creation.AddComponent<Image>();
				image.setting = m_SettingValue;
				image.style = m_ImageStyleValue;
				image.sprite = m_SpriteValue;
				image.color = m_ColorValue;
				Button button = creation.AddComponent<Button>();
				button.setting = m_SettingValue;
				button.style = m_ButtonStyleValue;
				button.transition = m_TransitionValue;
				button.colors = m_ColorBlockValue;
				button.spriteState = m_SpriteStateValue;
				button.animationTriggers = m_AnimationValue;
				GameObject innerCreation = new GameObject(m_TextNameValue);
				RectTransform innerTransform = innerCreation.AddComponent<RectTransform>();
				innerTransform.anchorMin = Vector2.zero;
				innerTransform.anchorMax = Vector2.one;
				innerTransform.sizeDelta = Vector2.zero;
				Text text = innerCreation.AddComponent<Text>();
				text.setting = m_SettingValue;
				text.style = m_TextStyleValue;
				text.translation = m_TranslationValue;
				text.text = m_TextValue;
				text.font = m_FontValue;
				text.fontStyle = m_FontStyleValue;
				text.fontSize = m_FontSizeValue;
				text.lineSpacing = m_FontSpacingValue;
				text.alignment = m_FontAlignmentValue;
				text.color = m_FontColorValue;
				innerCreation.transform.SetParent(creation.transform, false);
				creation.transform.SetParent(m_Context?.transform);
				creation.transform.localScale = Vector3.one;
				Close();
			}
		}
	}
}