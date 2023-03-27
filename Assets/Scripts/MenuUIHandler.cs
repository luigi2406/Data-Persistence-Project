using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI highscoreText;
	[SerializeField] TMP_InputField inputField;
	[SerializeField] GameObject errorMessage;

	private void Start()
	{
		UpdateHighscoreText();
		inputField.text = HighscoreManager.Instance.currentPlayerName;
	}

	public void StartGame()
	{
		if (!string.IsNullOrEmpty(inputField.text))
		{
			HighscoreManager.Instance.currentPlayerName = inputField.text;
			SceneManager.LoadScene(1);
		}
		else
		{
			errorMessage.SetActive(true);
		}
	}

	private void UpdateHighscoreText()
	{
		int score = HighscoreManager.Instance.highscore.score;
		if (score > 0) // check if highscore exists
		{
			string name = HighscoreManager.Instance.highscore.name;
			highscoreText.text = "Current Highscore: " + score + " by " + name;
		}
		else
		{
			highscoreText.text = "No Highscore found";
		}
	}

}
