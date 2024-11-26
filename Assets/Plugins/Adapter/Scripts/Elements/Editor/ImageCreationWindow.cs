using UnityEditor;
using UnityEngine;

namespace Adapter.Elements.Editor
{
	public class ImageCreationWindow : ContextWindow
	{
		private RectTransform m_RectTransform;

		private string m_NameValue;

		private Vector3 m_PositionValue;
		private Vector2 m_SizeValue;
		private Vector3 m_RotationValue;
		
		private Setting m_SettingValue;
		private string m_StyleValue;

		private Sprite m_SpriteValue;
		private Color m_ColorValue;

		public RectTransform rectTransform { get => m_RectTransform; set => m_RectTransform = value; }

		public string nameValue { get => m_NameValue; set => m_NameValue = value; }

		public Vector3 positionValue { get => m_PositionValue; set => m_PositionValue = value; }
		public Vector2 sizeValue { get => m_SizeValue; set => m_SizeValue = value; }
		public Vector3 rotationValue { get => m_RotationValue; set => m_RotationValue = value; }

		public Setting settingValue { get => m_SettingValue; set => m_SettingValue = value; }
		public string styleValue { get => m_StyleValue; set => m_StyleValue = value; }

		public Sprite spriteValue { get => m_SpriteValue; set => m_SpriteValue = value; }
		public Color colorValue { get => m_ColorValue; set => m_ColorValue = value; }



		private void OnEnable()
		{
			titleContent = new GUIContent("Image Creation");
			minSize = maxSize = new Vector2(320, 640);
			m_RectTransform = Selection.activeGameObject?.GetComponent<RectTransform>();

			m_NameValue = "Adaptive Image";
			m_PositionValue = Vector3.zero;
			m_SizeValue = new Vector2(100, 100);
			m_RotationValue = Vector3.zero;
			m_SpriteValue = null;
			m_ColorValue = Color.white;
		}

		private void OnGUI()
		{
			m_NameValue = EditorGUILayout.TextField("Name", m_NameValue);

			m_PositionValue = EditorGUILayout.Vector3Field("Position", m_PositionValue);
			m_SizeValue = EditorGUILayout.Vector2Field("Size", m_SizeValue);
			m_RotationValue = EditorGUILayout.Vector3Field("Rotation", m_RotationValue);

			m_SettingValue = (Setting)EditorGUILayout.ObjectField("Setting", m_SettingValue, typeof(Setting), true);
			m_StyleValue = EditorGUILayout.TextField("Style Name", m_StyleValue);

			m_SpriteValue = (Sprite)EditorGUILayout.ObjectField("Sprite", m_SpriteValue, typeof(Sprite), true);
			m_ColorValue = EditorGUILayout.ColorField("Color", m_ColorValue);

			if (GUILayout.Button("Create Image"))
			{
				GameObject creation = new GameObject(m_NameValue);
				RectTransform transform = creation.AddComponent<RectTransform>();
				transform.position = m_RectTransform?.TransformPoint(m_PositionValue) ?? context.transform.TransformPoint(m_PositionValue);
				transform.sizeDelta = m_SizeValue;
				transform.rotation = Quaternion.Euler(m_RotationValue);
				Image image = creation.AddComponent<Image>();
				image.setting = m_SettingValue;
				image.style = m_StyleValue;
				image.sprite = m_SpriteValue;
				image.color = m_ColorValue;
				creation.transform.SetParent(m_Context?.transform);
				creation.transform.localScale = Vector3.one;
				Close();
			}
		}
	}
}