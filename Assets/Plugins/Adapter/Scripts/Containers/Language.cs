using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	[CreateAssetMenu(menuName = "Adapter/Container/Language", fileName = "New Language", order = 2)]
	public class Language : ScriptableObject
	{
		[SerializeField] private SystemLanguage m_LanguageCode;
		[SerializeField] private List<Container<string, string>> m_Translations;
		
		public SystemLanguage languageCode => m_LanguageCode;
		public List<Container<string, string>> translations => m_Translations;



		public string GetTranslation(string name) => FindValue(m_Translations, name);

		private T FindValue<T>(List<Container<string, T>> containers, string name)
		{
			string[] split = name.Split('.', 2);
            foreach (Container<string, T> container in containers)
                if (container.name == split[0])
                    if (container.type is ContainerType.Container)
                        return FindValue(container.container, split[1]);
                    else if (container.type is ContainerType.Store)
                        return container.store;
            throw new KeyNotFoundException($"Cannot find value in container by key \"{name}\"");
		}
	}
}