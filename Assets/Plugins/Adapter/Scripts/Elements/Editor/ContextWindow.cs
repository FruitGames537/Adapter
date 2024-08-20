using UnityEditor;
using UnityEngine;

namespace Adapter.Elements.Editor
{
	public class ContextWindow : EditorWindow
	{
		protected GameObject m_Context;

		public GameObject context { get => m_Context; set => m_Context = value; }
	}
}