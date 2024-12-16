using UnityEngine;

namespace Adapter
{
	public class Manager : MonoBehaviour
	{
		[Header("Setting")]
		[SerializeField] private Setting m_Setting;

		[Header("Language")]
		[SerializeField] private SystemLanguage m_DefaultLanguageCode;
		[SerializeField] private bool m_UseSystemLanguage;

		[Header("Theme")]
		[SerializeField] private string m_DefaultThemeName;
		[SerializeField] private bool m_UseSystemTheme;

		public Setting setting { get => m_Setting; set => m_Setting = value; }

		public SystemLanguage defaultLanguageCode { get => m_DefaultLanguageCode; set => m_DefaultLanguageCode = value; }
		public bool useSystemLanguage { get => m_UseSystemLanguage; set => m_UseSystemLanguage = value; }

		public string defaultThemeName { get => m_DefaultThemeName; set => m_DefaultThemeName = value; }
		public bool useSystemTheme { get => m_UseSystemTheme; set => m_UseSystemTheme = value; }



		private void OnEnable() => Load();
		private void OnDisable() => Save();

		public void Load()
		{
			if (m_Setting != null)
			{
				m_Setting.SafeLoadLanguage();
				m_Setting.SafeLoadTheme();
			}
		}
		public void Save()
		{
			if (m_Setting != null)
			{
				m_Setting.SafeSaveLanguage();
				m_Setting.SafeSaveTheme();
			}
		}

		public void Synchronize()
		{
			SynchronizeLanguage();
			SynchronizeTheme();
		}

		public void SynchronizeLanguage()
		{
			SystemLanguage languageCode = m_DefaultLanguageCode;
			if (m_UseSystemLanguage)
				languageCode = Setting.systemLanguage;
			m_Setting.ChangeLanguage(languageCode);

			m_Setting.SafeSaveLanguage();
			m_Setting.SafeLoadLanguage();
		}
		public void SynchronizeTheme()
		{
			string themeName = m_DefaultThemeName;
			if (m_UseSystemTheme && Setting.darkMode.HasValue)
				themeName = Setting.darkMode.Value ? m_Setting.darkTheme.themeName : m_Setting.lightTheme.themeName;
			m_Setting.ChangeTheme(themeName);

			m_Setting.SafeSaveTheme();
			m_Setting.SafeLoadTheme();
		}
	}
}