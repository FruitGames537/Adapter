using Adapter.Styles;
using Adapter.Translations;
using UnityEngine;

namespace Adapter.Elements
{
	[AddComponentMenu("UI/Adaptive/Text", order: 1)]
	public class Text : UnityEngine.UI.Text, IElement
	{
		[SerializeField] protected Setting m_Setting;

		[SerializeField] protected string m_Style;
		[SerializeField] protected string m_Translation;

		public Setting setting { get => m_Setting; set => m_Setting = value; }

		public string style { get => m_Style; set => m_Style = value; }
		public string translation { get => m_Translation; set => m_Translation = value; }



		public void Modify()
		{
			if (m_Setting != null && m_Setting.currentTheme != null && m_Setting.currentTheme.SearchStyle(m_Style, out TextStyle textStyle))
				textStyle.Apply(this, m_Setting.languageCode);
			if (m_Setting != null && m_Setting.currentLanguage != null && m_Setting.currentLanguage.SearchTranslation(m_Translation, out Translation translation))
				text = translation;
		}

		private void OnThemeChanged(string themeName, bool nameIsEmpty) => Modify();
		private void OnLanguageChanged(SystemLanguage? languageCode, bool codeIsEmpty) => Modify();

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

		protected override void Start()
		{
			base.Start();

			Modify();
		}
	}
}