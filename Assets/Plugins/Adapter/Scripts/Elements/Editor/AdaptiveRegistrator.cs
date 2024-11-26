using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.Elements.Editor
{
	public static class AdaptiveRegistrator
	{
		[MenuItem("GameObject/UI/Adaptive/Image", priority = 1)]
		public static void CreateImage(MenuCommand command) => Create<ImageCreationWindow>(command);

		[MenuItem("GameObject/UI/Adaptive/Button", priority = 2)]
		public static void CreateButton(MenuCommand command) => Create<ButtonCreationWindow>(command);

		[MenuItem("GameObject/UI/Adaptive/Text", priority = 3)]
		public static void CreateText(MenuCommand command) => Create<TextCreationWindow>(command);

		private static void Create<T>(MenuCommand command) where T : ContextWindow
		{
			T window = EditorWindow.CreateWindow<T>(typeof(T));
			window.context = SearchCanvas(command.context as GameObject);
			window.Show();
		}

		private static GameObject SearchCanvas(GameObject context)
		{
			Canvas canvas;
			if (context == null)
			{
				canvas = Object.FindObjectsOfType<Canvas>()[^1];
				if (canvas != null)
					return canvas.gameObject;
			}
			else
			{
				Transform origin = context.transform;
				while (origin != null)
				{
					canvas = origin.GetComponentInParent<Canvas>();
					if (canvas != null)
						return context;
					origin = origin.parent;
				}
			}
			GameObject gameObject = new GameObject("Canvas");
			canvas = gameObject.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			gameObject.AddComponent<CanvasScaler>();
			gameObject.AddComponent<GraphicRaycaster>();
			gameObject.transform.SetParent(context?.transform, false);
			return gameObject;
		}
	}
}