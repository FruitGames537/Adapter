using Adapter.Contents;
using Adapter.Translations;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter.Containers
{
	[CreateAssetMenu(menuName = "Adapter/Container/Language", fileName = "New Language", order = 1)]
	public class Language : ScriptableContainer
	{
		[SerializeField] private SystemLanguage m_LanguageCode = SystemLanguage.Unknown;

		[SerializeField] private List<Container<string, Translation>> m_Translations;

		[SerializeField] private List<Container<string, Document>> m_Documents;
		[SerializeField] private List<Container<string, Image>> m_Images;
		[SerializeField] private List<Container<string, Audio>> m_Audios;
		[SerializeField] private List<Container<string, Video>> m_Videos;

		public SystemLanguage languageCode => m_LanguageCode;

		public List<Container<string, Translation>> translations { get => m_Translations; set => m_Translations = value ?? new List<Container<string, Translation>>(); }

		public List<Container<string, Document>> documents { get => m_Documents; set => m_Documents = value ?? new List<Container<string, Document>>(); }
		public List<Container<string, Image>> images { get => m_Images; set => m_Images = value ?? new List<Container<string, Image>>(); }
		public List<Container<string, Audio>> audios { get => m_Audios; set => m_Audios = value ?? new List<Container<string, Audio>>(); }
		public List<Container<string, Video>> videos { get => m_Videos; set => m_Videos = value ?? new List<Container<string, Video>>(); }



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