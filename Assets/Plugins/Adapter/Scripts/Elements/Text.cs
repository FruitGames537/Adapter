using Adapter.Styles;
using Adapter.Translations;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Adapter.Elements
{
	[AddComponentMenu("UI/Adaptive/Text", order: 1)]
	public class Text : UI.Text, IElement
	{
		[SerializeField] protected Setting m_Setting;

		[SerializeField] protected string m_Style;
		[SerializeField] protected string m_Translation;

		[SerializeField] protected bool m_Updatable;
		[SerializeField] protected bool m_Localizable;
		
		public Setting setting { get => m_Setting; set => m_Setting = value; }

		public string style { get => m_Style; set => m_Style = value; }
		public string translation { get => m_Translation; set => m_Translation = value; }

		public bool updatable { get => m_Updatable; set => m_Updatable = value; }
		public bool localizable { get => m_Localizable; set => m_Localizable = value; }



		protected override void Start()
		{
			base.Start();

			Modify();
		}

		protected override void OnEnable()
		{
			base.OnEnable();

			if (m_Setting != null)
			{
				m_Setting.ThemeChanged += OnThemeChanged;
				m_Setting.LanguageChanged += OnLanguageChanged;
			}
		}
		protected override void OnDisable()
		{
			base.OnDisable();

			if (m_Setting != null)
			{
				m_Setting.ThemeChanged -= OnThemeChanged;
				m_Setting.LanguageChanged -= OnLanguageChanged;
			}
		}

		private void OnThemeChanged(string themeName, bool nameIsEmpty) => Modify();
		private void OnLanguageChanged(SystemLanguage? languageCode, bool codeIsEmpty) => Modify();

		public void Modify()
		{
			if (m_Setting != null && m_Setting.currentTheme != null && m_Setting.currentTheme.SearchStyle(m_Style, out TextStyle textStyle))
				textStyle.Apply(this, m_Setting.languageCode);
			if (m_Setting != null && m_Setting.currentLanguage != null && m_Updatable)
				UpdateText();
		}
		private void UpdateText()
		{
			string translation = m_Translation;
			if (m_Localizable && m_Setting.currentLanguage.SearchTranslation(m_Translation, out Translation search))
				translation = search.translation;
			text = translation;
		}
	}
}