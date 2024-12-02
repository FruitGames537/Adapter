using System;
using UnityEngine;

namespace Adapter.Contents
{
	[Serializable]
	public class Document
	{
		public Document(TextAsset textAsset) => m_TextAsset = textAsset;



		[SerializeField] private TextAsset m_TextAsset;

		public TextAsset textAsset { get => m_TextAsset; set => m_TextAsset = value; }



		public static implicit operator Document(TextAsset textAsset) => new Document(textAsset);
		public static implicit operator TextAsset(Document document) => document.textAsset;
	}
}