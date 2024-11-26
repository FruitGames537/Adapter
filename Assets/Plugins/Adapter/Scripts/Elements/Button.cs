using Adapter.Styles;
using UnityEngine;

namespace Adapter.Elements
{
	[AddComponentMenu("UI/Adaptive/Button", order: 2)]
	public class Button : UnityEngine.UI.Button, IElement
	{
		[SerializeField] protected Setting m_Setting;
		[SerializeField] protected string m_Style;

		public Setting setting { get => m_Setting; set => m_Setting = value; }
		public string style { get => m_Style; set => m_Style = value; }



		public void Modify()
		{
			if (m_Setting != null && m_Setting.currentTheme.GetStyle<ButtonStyle>(m_Style) is ButtonStyle style)
				style.Apply(this);
		}

		private void OnChangeTheme(string theme, bool emptyName) => Modify();

		protected override void OnEnable()
		{
			base.OnEnable();

			if (m_Setting != null)
				m_Setting.ThemeChanged += OnChangeTheme;
		}
		protected override void OnDisable()
		{
			base.OnDisable();

			if (m_Setting != null)
				m_Setting.ThemeChanged -= OnChangeTheme;
		}

		protected override void Start()
		{
			base.Start();

			Modify();
		}
	}
}