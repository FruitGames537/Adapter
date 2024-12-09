using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Adapter.Elements.Editor
{
	public static class AdaptiveRegistrator
	{
		[MenuItem("GameObject/UI/Adaptive/Text", priority = 1)]
		public static void CreateText(MenuCommand command) => Create<TextCreationWindow>(command);

		[MenuItem("GameObject/UI/Adaptive/Image", priority = 2)]
		public static void CreateImage(MenuCommand command) => Create<ImageCreationWindow>(command);

		[MenuItem("GameObject/UI/Adaptive/Button", priority = 3)]
		public static void CreateButton(MenuCommand command) => Create<ButtonCreationWindow>(command);

		private static void Create<T>(MenuCommand command) where T : ContextWindow
		{
			T window = EditorWindow.CreateWindow<T>(typeof(T));
			window.context = SearchCanvas(command.context as GameObject);
			SearchEventSystem();
			window.Show();
		}

		private static GameObject SearchCanvas(GameObject context)
		{
			GameObject gameObject = context == null ? CanvasOnScene() : CanvasInParent(context);
			if (gameObject != null)
				return gameObject;
			return CreateCanvas(context);
		}

		private static GameObject CanvasOnScene()
		{
			if (Object.FindObjectOfType<Canvas>() is Canvas canvas)
				return canvas.gameObject;
			return null;
		}
		private static GameObject CanvasInParent(GameObject context)
		{
			Transform origin = context.transform;
			while (true)
				if (origin.GetComponentInParent<Canvas>() != null)
					return context;
				else if ((origin = origin.parent) == null)
					break;
			return null;
		}
		private static GameObject CreateCanvas(GameObject context)
		{
			GameObject gameObject = new GameObject("Canvas");
			Canvas canvas = gameObject.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			gameObject.AddComponent<CanvasScaler>();
			gameObject.AddComponent<GraphicRaycaster>();
			if (context != null)
				gameObject.transform.SetParent(context.transform, false);
			return gameObject;
		}

		private static GameObject SearchEventSystem()
		{
			if (Object.FindObjectOfType<EventSystem>() is EventSystem eventSystem)
				return eventSystem.gameObject;
			return CreateEventSystem();
		}

		private static GameObject CreateEventSystem()
		{
			GameObject gameObject = new GameObject("EventSystem");
			gameObject.AddComponent<EventSystem>();
			gameObject.AddComponent<StandaloneInputModule>();
			gameObject.AddComponent<BaseInput>();
			return gameObject;
		}
	}
}