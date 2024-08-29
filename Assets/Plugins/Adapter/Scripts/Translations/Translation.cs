using System;
using UnityEngine;

namespace Adapter.Translations
{
	[Serializable]
	public class Translation
	{
		public Translation(string translation) => m_Translation = translation;



		[SerializeField] private string m_Translation;

		public string translation { get => m_Translation; set => m_Translation = value; }



		public static implicit operator Translation(string translation) => new Translation(translation);
		public static implicit operator string(Translation translation) => translation.m_Translation;
	}
}