using UnityEngine;
using System.Collections.Generic;
using System;
using VEngine.Log;

namespace VEngine.Localization
{
	public class CLocalizationManager : ILocalizationManager
	{
		private const string STR_SAVE_PATH = "lang";
		protected string _languageFolderPath = "Lang\\";
		protected string _languageFileName = "lang";

		private SystemLanguage _currentLanguage;
		private List<SystemLanguage> _availableLanguages;
		private Dictionary<string, string> _texts = new Dictionary<string, string>();

		public Action<SystemLanguage> OnLanguageChanged { get; set; }

		public SystemLanguage CurrentLanguage() => _currentLanguage;
		public List<SystemLanguage> AvailableLanguages() => _availableLanguages;

		public CLocalizationManager(string languageFolderPath = "Lang\\", string languageFileName = "lang")
		{
			_languageFolderPath = languageFolderPath;
			_languageFileName = languageFileName;
			InitAvailableLanguages();
			ChangeSystemLanguage((SystemLanguage)PlayerPrefs.GetInt(STR_SAVE_PATH, (int)SystemLanguage.English));
		}

		private void InitAvailableLanguages()
		{
			_availableLanguages = new List<SystemLanguage>();
			_availableLanguages.Add(SystemLanguage.English);
			_availableLanguages.Add(SystemLanguage.Hungarian);
		}

		#region get
		public string LoadStr(string path) => GetString(path);

		private string GetString(string path)
		{
			string text;
			if (_texts.TryGetValue(path.ToLower(), out text))
				return Utils.ProcessStringEOL(text);
			VLog.Log(VLog.eFlag.Localization, VLog.eLevel.Error, $"{path} text not found on {_currentLanguage} language");
			return path;
		}
		#endregion

		#region change language
		public void ChangeSystemLanguage(SystemLanguage language)
		{
			if (_currentLanguage == language)
				return;
			_currentLanguage = language;
			PlayerPrefs.SetInt(STR_SAVE_PATH, (int)_currentLanguage);
			LoadTextsFromFile();
			OnLanguageChanged?.Invoke(_currentLanguage);
		}

		private void LoadTextsFromFile()
		{
			string path = _languageFolderPath + _languageFileName + "." + GetSortVersion(_currentLanguage).ToLower();
			VLog.Log(VLog.eFlag.GUI, VLog.eLevel.Normal, $"{path} language file loading start");
			var file = Resources.Load<TextAsset>(path);
			if (file == null)
			{
				VLog.Log(VLog.eFlag.Localization, VLog.eLevel.Error, $"{path} language file not found. Set language to english.");
				ChangeSystemLanguage(SystemLanguage.English);
				return;
			}
			_texts.Clear();
			ReadFile(file.text);
			VLog.Log(VLog.eFlag.GUI, VLog.eLevel.Normal, $"{path} language file loaded");
		}

		private void ReadFile(string file)
		{
			file = file.Replace('\r', '\n');
			var lines = file.Split('\n');
			for (var i = 0; i < lines.Length; ++i)
				ReadLine(i, lines[i]);
		}

		private void ReadLine(int index, string line)
		{
			if (string.IsNullOrEmpty(line))
				return;
			bool replaced = false;
			if (line.Contains(@"\="))
			{
				line = line.Replace(@"\=", "</061>");
				replaced = true;
			}
			var splitedLine = line.Split('=');
			if (splitedLine.Length != 2)
				VLog.Log(VLog.eFlag.Localization, VLog.eLevel.Error, $"Wrong line: {_currentLanguage} {index}. line ({line})");
			_texts[splitedLine[0].ToLower()] = replaced ? splitedLine[1].Replace("</061>", "=") : splitedLine[1];
		}

		private string GetSortVersion(SystemLanguage language)
		{
			var str = language.ToString();
			return str.Substring(0, Mathf.Min(2, str.Length));
		}
		#endregion
	}
}