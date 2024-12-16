using Adapter.Styles;
using Adapter.Translations;
using System.Collections.Generic;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Adapter.Elements
{
	[AddComponentMenu("UI/Adaptive/Dropdown", order: 7)]
	public class Dropdown : UI.Dropdown, IElement
	{
		[SerializeField] protected Setting m_Setting;

		[SerializeField] protected string m_Style;
		[SerializeField] protected List<string> m_Translation;

		public Setting setting { get => m_Setting; set => m_Setting = value; }

		public string style { get => m_Style; set => m_Style = value; }
		public List<string> translation { get => m_Translation; set => m_Translation = value; }



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
			if (m_Setting != null && m_Setting.currentTheme != null && m_Setting.currentTheme.SearchStyle(m_Style, out DropdownStyle dropdownStyle))
				dropdownStyle.Apply(this);
			ClearOptions();
			List<string> option = new List<string>();
			if (m_Setting != null && m_Setting.currentLanguage != null)
				foreach (string item in m_Translation)
					if (m_Setting.currentLanguage.SearchTranslation(item, out Translation translation))
						option.Add(translation);
					else
						option.Add(item);
			AddOptions(option);
		}
	}
}