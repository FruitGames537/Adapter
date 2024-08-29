using Adapter.Styles;
using UnityEngine;

namespace Adapter.Elements
{
	[AddComponentMenu("UI/Adaptive/Image", order: 1)]
	public class Image : UnityEngine.UI.Image, IElement
	{
		[SerializeField] protected Setting m_Setting;
		[SerializeField] protected string m_Style;

		public Setting setting { get => m_Setting; set => m_Setting = value; }
		public string style { get => m_Style; set => m_Style = value; }



		public void Modify()
		{
			if (m_Setting != null && m_Setting.currentTheme != null && m_Setting.currentTheme.GetStyle<ImageStyle>(m_Style) is ImageStyle style)
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