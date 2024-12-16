#if UNITY_EDITOR
#elif PLATFORM_ANDROID
using UnityEngine;
#endif

namespace Adapter
{
	public static class DarkMode
	{
		public static bool? darkMode
		{
			get
			{
#if UNITY_EDITOR
				return null;
#elif PLATFORM_ANDROID
				using AndroidJavaClass darkModeClass = new AndroidJavaClass("com.adapter.DarkMode");
				using AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				using AndroidJavaObject activity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
				int darkMode = darkModeClass.CallStatic<int>("getDarkMode", activity);
				return darkMode == 1 ? false : darkMode == 2 ? true : null;
#else
				return null;
#endif
			}
		}
	}
}