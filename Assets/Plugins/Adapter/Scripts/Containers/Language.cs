using Adapter.Translations;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	[CreateAssetMenu(menuName = "Adapter/Container/Language", fileName = "New Language", order = 2)]
	public class Language : ScriptableContainer
	{
		[SerializeField] private SystemLanguage m_LanguageCode = SystemLanguage.Unknown;
		[SerializeField] private List<Container<string, Translation>> m_Translations = new List<Container<string, Translation>>();

		public SystemLanguage languageCode => m_LanguageCode;
		public List<Container<string, Translation>> translations => m_Translations;



		public Translation GetTranslation(string name, bool ignore = false) => GetValue(m_Translations, name, ignore: ignore);
		public Translation CanGetTranslation(string name) => CanGetValue(m_Translations, name) ? GetValue(m_Translations, name) : null;
	}
}