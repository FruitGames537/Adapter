using Adapter.Styles;
using UnityEngine;
using UI = UnityEngine.UI;

namespace Adapter.Elements
{
	[AddComponentMenu("UI/Adaptive/Input", order: 4)]
	public class Input : UI.InputField, IElement
	{
		[SerializeField] protected Setting m_Setting;
		[SerializeField] protected string m_Style;

		public Setting setting { get => m_Setting; set => m_Setting = value; }
		public string style { get => m_Style; set => m_Style = value; }



		protected override void Start()
		{
			base.Start();

			Modify();
		}

		protected override void OnEnable()
		{
			base.OnEnable();

			if (m_Setting != null)
				m_Setting.ThemeChanged += OnThemeChanged;
		}
		protected override void OnDisable()
		{
			base.OnDisable();

			if (m_Setting != null)
				m_Setting.ThemeChanged -= OnThemeChanged;
		}

		private void OnThemeChanged(string themeName, bool nameIsEmpty) => Modify();

		public void Modify()
		{
			if (m_Setting != null && m_Setting.currentLanguage != null && m_Setting.currentTheme.SearchStyle(m_Style, out InputStyle inputStyle))
				inputStyle.Apply(this);
		}
	}
}