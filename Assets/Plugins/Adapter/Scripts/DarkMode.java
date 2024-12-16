package com.adapter;

import android.view.ContextThemeWrapper;
import android.content.res.Configuration;
import android.os.Build;

public class DarkMode {
	public static int getDarkMode(ContextThemeWrapper contextThemeWrapper) {
		if (Build.VERSION.SDK_INT < 29)
			return 0;

		switch (contextThemeWrapper.getResources().getConfiguration().uiMode & Configuration.UI_MODE_NIGHT_MASK) {
			case Configuration.UI_MODE_NIGHT_NO:
				return 1;
			case Configuration.UI_MODE_NIGHT_YES:
				return 2;
		}

		return 0;
	}
}