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
		[Header("Theme")]
		[SerializeField] private string m_ThemePropertyName;
		[SerializeField] private Theme m_DefaultTheme;
		[SerializeField] private Theme m_LightTheme;
		[SerializeField] private Theme m_DarkTheme;
		[SerializeField] private List<Theme> m_Themes;

		private string m_ThemeName;
		private Theme m_Theme;

		public string themePropertyName { get => m_ThemePropertyName; set => m_ThemePropertyName = value; }
		public Theme defaultTheme { get => m_DefaultTheme; set => m_DefaultTheme = value; }
		public Theme lightTheme { get => m_LightTheme; set => m_LightTheme = value; }
		public Theme darkTheme { get => m_DarkTheme; set => m_DarkTheme = value; }

		public string themeName => m_ThemeName;
		public Theme theme => m_Theme;

		public Theme currentTheme => m_ThemeName != null && m_Themes.Exists(item => item.name == m_ThemeName) ? m_Themes.Find(item => item.themeName == m_ThemeName) : m_Theme;
		public int themeIndex => themeNames.IndexOf(m_ThemeName);
		public List<string> themeNames => m_Themes.Select(item => item.themeName).ToList();

		public delegate void ThemeChangedHandler(string theme, bool emptyName);
		public event ThemeChangedHandler ThemeChanged;

		[Header("Language")]
		[SerializeField] private string m_LanguagePropertyName;
		[SerializeField] private Language m_DefaultLanguage;
		[SerializeField] private List<Language> m_Languages;

		private SystemLanguage? m_LanguageCode;
		private Language m_Language;

		public string languagePropertyName { get => m_LanguagePropertyName; set => m_LanguagePropertyName = value; }
		public Language defaultLanguage { get => m_DefaultLanguage; set => m_DefaultLanguage = value; }

		public SystemLanguage? languageCode => m_LanguageCode;
		public Language language => m_Language;

		public Language currentLanguage => m_LanguageCode.HasValue && m_Languages.Exists(item => item.languageCode == m_LanguageCode) ? m_Languages.Find(item => item.languageCode == m_LanguageCode) : m_Language;
		public int languageIndex => languageCodes.IndexOf(m_LanguageCode.Value);
		public List<SystemLanguage> languageCodes => m_Languages.Select(item => item.languageCode).ToList();

		public delegate void LanguageChangedHandler(SystemLanguage? language, bool emptyCode);
		public event LanguageChangedHandler LanguageChanged;


		
		private void OnValidate()
		{
			m_Theme = m_DefaultTheme ?? (m_Themes != null && m_Themes.Count > 0 ? m_Themes[0] : null);
			m_ThemeName = m_Theme != null ? m_Theme.themeName : null;

			m_Language = m_DefaultLanguage ?? (m_Languages != null && m_Languages.Count > 0 ? m_Languages[0] : null);
			m_LanguageCode = m_Language != null ? m_Language.languageCode : null;
		}

		public void AddTheme(Theme theme) => m_Themes.Add(theme);
		public void RemoveTheme(Theme theme) => m_Themes.Remove(theme);
		public void RemoveTheme(string theme) => m_Themes.RemoveAll(item => item.themeName == theme);
		
		public void SetDefaultTheme() => SetTheme(m_DefaultTheme);
		public void SetLightTheme() => SetTheme(m_LightTheme);
		public void SetDarkTheme() => SetTheme(m_DarkTheme);
		
		public void ChangeTheme(string theme)
		{
			if (!m_Themes.Exists(item => item.themeName == theme))
				throw new KeyNotFoundException($"There is no language with this name: \"{theme}\"");
			m_ThemeName = theme;

			ThemeChanged?.Invoke(m_ThemeName, m_ThemeName == null);
		}
		public void SetTheme(Theme theme)
		{
			if (theme == null)
				throw new NullReferenceException("Theme reference does not refer to the theme object");
			m_ThemeName = themeNames.Exists(item => item == theme.themeName) ? themeNames.Find(item => item == theme.themeName) : null;
			m_Theme = theme;

			ThemeChanged?.Invoke(m_ThemeName, m_ThemeName == null);
		}

		public void SaveTheme()
		{
			if (m_ThemeName == null)
				throw new KeyNotFoundException("Theme name is not set");
			PlayerPrefs.SetString(m_ThemePropertyName, m_ThemeName);
			PlayerPrefs.Save();
		}
		public void LoadTheme()
		{
			if (!PlayerPrefs.HasKey(m_ThemePropertyName))
				throw new KeyNotFoundException("Theme name is not save");
			string name = PlayerPrefs.GetString(m_ThemePropertyName);
			SetTheme(m_Themes.Find(item => item.themeName == name) ?? m_DefaultTheme);
		}

		public void AddLanguage(Language language) => m_Languages.Add(language);
		public void RemoveLanguage(Language language) => m_Languages.Remove(language);
		public void RemoveLanguage(SystemLanguage language) => m_Languages.RemoveAll(item => item.languageCode == language);

		public void SetDefaultLanguage() => SetLanguage(m_DefaultLanguage);

		public void ChangeLanguage(SystemLanguage language)
		{
			if (!m_Languages.Exists(item => item.languageCode == language))
				throw new KeyNotFoundException($"There is no language with this code: \"{language}\"");
			m_LanguageCode = language;

			LanguageChanged?.Invoke(m_LanguageCode.Value, !m_LanguageCode.HasValue);
		}
		public void SetLanguage(Language language)
		{
			if (language == null)
				throw new NullReferenceException("Language reference does not refer to the language object");
			m_LanguageCode = languageCodes.Exists(item => item == language.languageCode) ? languageCodes.Find(item => item == language.languageCode) : null;
			m_Language = language;

			LanguageChanged?.Invoke(m_LanguageCode, !m_LanguageCode.HasValue);
		}

		public void SaveLanguage()
		{
			if (!m_LanguageCode.HasValue)
				throw new KeyNotFoundException("Language code is not set");
			PlayerPrefs.SetInt(m_LanguagePropertyName, (int)m_LanguageCode.Value);
			PlayerPrefs.Save();
		}
		public void LoadLanguage()
		{
			if (!PlayerPrefs.HasKey(m_LanguagePropertyName))
				throw new KeyNotFoundException("Language code is not save");
			SystemLanguage code = (SystemLanguage)PlayerPrefs.GetInt(m_LanguagePropertyName);
			SetLanguage(m_Languages.Find(item => item.languageCode == code) ?? m_DefaultLanguage);
		}
	}
}