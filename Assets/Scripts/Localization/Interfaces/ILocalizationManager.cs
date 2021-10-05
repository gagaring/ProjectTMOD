using UnityEngine;
using System.Collections.Generic;
using System;

namespace VEngine.Localization
{
	public interface ILocalizationManager
	{
		string LoadStr(string path);
		void ChangeSystemLanguage(SystemLanguage language);
		SystemLanguage CurrentLanguage();
		List<SystemLanguage> AvailableLanguages();
		Action<SystemLanguage> OnLanguageChanged { get; set; }
	}
}