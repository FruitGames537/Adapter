using System;
using UnityEngine;

namespace Adapter.Contents
{
	[Serializable]
	public class Asset
	{
		public Asset(ScriptableObject scriptableObject) => m_ScriptableObject = scriptableObject;



		[SerializeField] private ScriptableObject m_ScriptableObject;

		public ScriptableObject scriptableObject { get => m_ScriptableObject; set => m_ScriptableObject = value; }



		public static implicit operator Asset(ScriptableObject scriptableObject) => new Asset(scriptableObject);
		public static implicit operator ScriptableObject(Asset asset) => asset.scriptableObject;
	}
}