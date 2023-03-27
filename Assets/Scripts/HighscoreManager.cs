using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

	public string currentPlayerName { get; set; }
	public Highscore highscore;

	// singleton and load highscore on awake
	void Awake()
	{
		if (Instance == null)
		{
            Instance = this;
            DontDestroyOnLoad(gameObject);

			LoadHighscore();
		}
		else
		{
			Destroy(gameObject);
		}

	}

	// store Highscore in JSON file
	public void SaveHighscore(int score)
	{
		highscore = new Highscore();

		highscore.name = currentPlayerName;
		highscore.score = score;

		string json = JsonUtility.ToJson(highscore);

		File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
	}

	// load Highscore from JSON file
	public void LoadHighscore()
	{
		string path = Application.persistentDataPath + "/highscore.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);

			highscore = JsonUtility.FromJson<Highscore>(json);
		}
		else
		{
			Debug.Log("No Highscore File Found");
		}
	}

	// Highscore class for persistent data
	[Serializable]
	public class Highscore
	{
		public string name;
		public int score;
	}
}
