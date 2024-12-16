using Adapter.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Adapter
{
	[CreateAssetMenu(menuName = "Adapter/Setting", fileName = "New Setting", order = 1)]
	public class Setting : ScriptableObject
	{
		[Header("Language")]
		[SerializeField] private string m_LanguageProperty;
		[SerializeField] private Language m_DefaultLanguage;
		[SerializeField] private List<Language> m_Languages;

		private SystemLanguage? m_LanguageCode;
		private Language m_Language;

		public static SystemLanguage systemLanguage => Application.systemLanguage;

		public string languageProperty { get => m_LanguageProperty; set => m_LanguageProperty = value; }
		public Language defaultLanguage { get => m_DefaultLanguage; set => m_DefaultLanguage = value; }

		public SystemLanguage? languageCode => m_LanguageCode;
		public Language language => m_Language;

		public Language currentLanguage => m_LanguageCode.HasValue && m_Languages.Exists(item => item.languageCode == m_LanguageCode) ? m_Languages.Find(item => item.languageCode == m_LanguageCode) : m_Language;
		public int languageIndex => languageCodes.IndexOf(m_LanguageCode.Value);
		public List<SystemLanguage> languageCodes => m_Languages.Select(item => item.languageCode).ToList();

		public delegate void LanguageChangedHandler(SystemLanguage? languageCode, bool codeIsEmpty);
		public event LanguageChangedHandler LanguageChanged;

		[Header("Theme")]
		[SerializeField] private string m_ThemeProperty;
		[SerializeField] private Theme m_DefaultTheme;
		[SerializeField] private Theme m_LightTheme;
		[SerializeField] private Theme m_DarkTheme;
		[SerializeField] private List<Theme> m_Themes;

		private string m_ThemeName;
		private Theme m_Theme;

		public static bool? darkMode => DarkMode.darkMode;

		public string themeProperty { get => m_ThemeProperty; set => m_ThemeProperty = value; }
		public Theme defaultTheme { get => m_DefaultTheme; set => m_DefaultTheme = value; }
		public Theme lightTheme { get => m_LightTheme; set => m_LightTheme = value; }
		public Theme darkTheme { get => m_DarkTheme; set => m_DarkTheme = value; }

		public string themeName => m_ThemeName;
		public Theme theme => m_Theme;

		public Theme currentTheme => m_ThemeName != null && m_Themes.Exists(item => item.name == m_ThemeName) ? m_Themes.Find(item => item.themeName == m_ThemeName) : m_Theme;
		public int themeIndex => themeNames.IndexOf(m_ThemeName);
		public List<string> themeNames => m_Themes.Select(item => item.themeName).ToList();

		public delegate void ThemeChangedHandler(string themeName, bool nameIsEmpty);
		public event ThemeChangedHandler ThemeChanged;



		private void OnValidate()
		{
			m_Language = m_DefaultLanguage != null ? m_DefaultLanguage : (m_Languages != null && m_Languages.Count > 0 ? m_Languages[0] : null);
			m_LanguageCode = m_Language != null ? m_Language.languageCode : null;

			m_Theme = m_DefaultTheme != null ? m_DefaultTheme : (m_Themes != null && m_Themes.Count > 0 ? m_Themes[0] : null);
			m_ThemeName = m_Theme != null ? m_Theme.themeName : null;
		}

		public void AddLanguage(Language language) => m_Languages.Add(language);
		public void RemoveLanguage(Language language) => m_Languages.Remove(language);
		public void RemoveLanguage(SystemLanguage languageCode) => m_Languages.RemoveAll(item => item.languageCode == languageCode);

		public void SetDefaultLanguage() => SetLanguage(m_DefaultLanguage);

		public void ChangeLanguage(SystemLanguage languageCode)
		{
			if (!m_Languages.Exists(item => item.languageCode == languageCode))
				throw new KeyNotFoundException($"There is no language with this code: \"{languageCode}\"");
			m_LanguageCode = languageCode;

			LanguageChanged?.Invoke(m_LanguageCode.Value, !m_LanguageCode.HasValue);
		}
		public void SetLanguage(Language language)
		{
			if (language == null)
				throw new NullReferenceException("Language reference does not refer to language object");
			m_LanguageCode = languageCodes.Exists(item => item == language.languageCode) ? languageCodes.Find(item => item == language.languageCode) : null;
			m_Language = language;

			LanguageChanged?.Invoke(m_LanguageCode, !m_LanguageCode.HasValue);
		}

		public void SaveLanguage()
		{
			if (!m_LanguageCode.HasValue)
				throw new KeyNotFoundException("Language code is not set");
			PlayerPrefs.SetInt(m_LanguageProperty, (int)m_LanguageCode.Value);
			PlayerPrefs.Save();
		}
		public bool SafeSaveLanguage()
		{
			if (m_LanguageCode.HasValue is bool state && state)
				SaveLanguage();
			return state;
		}
		public void LoadLanguage()
		{
			if (!PlayerPrefs.HasKey(m_LanguageProperty))
				throw new KeyNotFoundException("Language code is not save");
			SystemLanguage languageCode = (SystemLanguage)PlayerPrefs.GetInt(m_LanguageProperty);
			Language language = m_Languages.Find(item => item.languageCode == languageCode);
			SetLanguage(language != null ? language : m_DefaultLanguage);
		}
		public bool SafeLoadLanguage()
		{
			if (PlayerPrefs.HasKey(m_LanguageProperty) is bool state && state)
				LoadLanguage();
			return state;
		}

		public void AddTheme(Theme theme) => m_Themes.Add(theme);
		public void RemoveTheme(Theme theme) => m_Themes.Remove(theme);
		public void RemoveTheme(string themeName) => m_Themes.RemoveAll(item => item.themeName == themeName);

		public void SetDefaultTheme() => SetTheme(m_DefaultTheme);
		public void SetLightTheme() => SetTheme(m_LightTheme);
		public void SetDarkTheme() => SetTheme(m_DarkTheme);

		public void ChangeTheme(string themeName)
		{
			if (!m_Themes.Exists(item => item.themeName == themeName))
				throw new KeyNotFoundException($"There is no language with this name: \"{themeName}\"");
			m_ThemeName = themeName;

			ThemeChanged?.Invoke(m_ThemeName, m_ThemeName == null);
		}
		public void SetTheme(Theme theme)
		{
			if (theme == null)
				throw new NullReferenceException("Theme reference does not refer to theme object");
			m_ThemeName = themeNames.Exists(item => item == theme.themeName) ? themeNames.Find(item => item == theme.themeName) : null;
			m_Theme = theme;

			ThemeChanged?.Invoke(m_ThemeName, m_ThemeName == null);
		}

		public void SaveTheme()
		{
			if (m_ThemeName == null)
				throw new KeyNotFoundException("Theme name is not set");
			PlayerPrefs.SetString(m_ThemeProperty, m_ThemeName);
			PlayerPrefs.Save();
		}
		public bool SafeSaveTheme()
		{
			if ((m_ThemeName != null) is bool state && state)
				SaveTheme();
			return state;
		}
		public void LoadTheme()
		{
			if (!PlayerPrefs.HasKey(m_ThemeProperty))
				throw new KeyNotFoundException("Theme name is not save");
			string themeName = PlayerPrefs.GetString(m_ThemeProperty);
			Theme theme = m_Themes.Find(item => item.themeName == themeName);
			SetTheme(theme != null ? theme : m_DefaultTheme);
		}
		public bool SafeLoadTheme()
		{
			if (PlayerPrefs.HasKey(m_ThemeProperty) is bool state && state)
				LoadTheme();
			return state;
		}
	}
}