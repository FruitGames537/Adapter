using Adapter.Styles;
using UnityEngine;

namespace Adapter.Elements
{
	[AddComponentMenu("UI/Adaptive/Text", order: 3)]
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
			if (m_Setting != null && m_Setting.currentTheme != null && m_Setting.currentTheme.GetStyle<TextStyle>(m_Style) is TextStyle style)
				style.Apply(this, m_Setting.languageCode);
			if (m_Setting != null && m_Setting.currentLanguage != null)
				text = m_Setting.currentLanguage.GetTranslation(m_Translation) ?? m_Text;
		}

		private void OnChangeTheme(string theme, bool emptyName) => Modify();
		private void OnChangeLanguage(SystemLanguage? language, bool emptyCode) => Modify();

		protected override void OnEnable()
		{
			base.OnEnable();

			if (m_Setting != null)
			{
				m_Setting.ThemeChanged += OnChangeTheme;
				m_Setting.LanguageChanged += OnChangeLanguage;
			}
		}
		protected override void OnDisable()
		{
			base.OnDisable();

			if (m_Setting != null)
			{
				m_Setting.ThemeChanged -= OnChangeTheme;
				m_Setting.LanguageChanged -= OnChangeLanguage;
			}
		}

		protected override void Start()
		{
			base.Start();

			Modify();
		}
	}
}