using UnityEngine;

namespace Adapter
{
	public class AutoLoader : MonoBehaviour
	{
		[SerializeField] private Setting m_Setting;

		public Setting setting { get => m_Setting; set => m_Setting = value; }



		private void Start()
		{
			if (m_Setting != null)
			{
				m_Setting.LoadLanguage();
				m_Setting.LoadTheme();
			}
		}
	}
}