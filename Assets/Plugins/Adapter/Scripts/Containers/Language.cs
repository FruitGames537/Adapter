using Adapter.Contents;
using Adapter.Translations;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	[CreateAssetMenu(menuName = "Adapter/Container/Language", fileName = "New Language", order = 1)]
	public class Language : ScriptableContainer
	{
		public Language(SystemLanguage languageCode) => m_LanguageCode = languageCode;

		public Language(SystemLanguage languageCode, List<Container<string, Translation>> translations) : this(languageCode) => m_Translations = translations;
		public Language(SystemLanguage languageCode, List<Container<string, Document>> documents, List<Container<string, Image>> images, List<Container<string, Audio>> audios, List<Container<string, Video>> videos) : this(languageCode)
		{
			m_Documents = documents;
			m_Images = images;
			m_Audios = audios;
			m_Videos = videos;
		}

		public Language(SystemLanguage languageCode, List<Container<string, Translation>> translations, List<Container<string, Document>> documents, List<Container<string, Image>> images, List<Container<string, Audio>> audios, List<Container<string, Video>> videos) : this(languageCode, documents, images, audios, videos) => m_Translations = translations;



		[SerializeField] private SystemLanguage m_LanguageCode = SystemLanguage.Unknown;

		[SerializeField] private List<Container<string, Translation>> m_Translations = new List<Container<string, Translation>>();

		[SerializeField] private List<Container<string, Document>> m_Documents = new List<Container<string, Document>>();
		[SerializeField] private List<Container<string, Image>> m_Images = new List<Container<string, Image>>();
		[SerializeField] private List<Container<string, Audio>> m_Audios = new List<Container<string, Audio>>();
		[SerializeField] private List<Container<string, Video>> m_Videos = new List<Container<string, Video>>();

		public SystemLanguage languageCode => m_LanguageCode;

		public List<Container<string, Translation>> translations => m_Translations;

		public List<Container<string, Document>> documents => m_Documents;
		public List<Container<string, Image>> images => m_Images;
		public List<Container<string, Audio>> audios => m_Audios;
		public List<Container<string, Video>> videos => m_Videos;



		public Translation GetTranslation(string path, bool safe = false) => GetStore(m_Translations, path, safe: safe);
		public bool SearchTranslation(string path, out Translation translation) => SearchStore(m_Translations, path, out translation);

		public Document GetDocument(string path, bool safe = false) => GetStore(m_Documents, path, safe: safe);
		public bool SeatchDocument(string path, out Document document) => SearchStore(m_Documents, path, out document);

		public Image GetImage(string path, bool safe = false) => GetStore(m_Images, path, safe: safe);
		public bool SearchImage(string path, out Image image) => SearchStore(m_Images, path, out image);

		public Audio GetAudio(string path, bool safe = false) => GetStore(m_Audios, path, safe: safe);
		public bool SearchAudio(string path, out Audio audio) => SearchStore(m_Audios, path, out audio);

		public Video GetVideo(string path, bool safe = false) => GetStore(m_Videos, path, safe: safe);
		public bool SearchVideo(string path, out Video video) => SearchStore(m_Videos, path, out video);
	}
}