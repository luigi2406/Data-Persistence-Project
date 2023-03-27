using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
		if (HighscoreManager.Instance != null)
		{
			UpdateHighscoreText();
		}
    }

	public void ReturnToMenu()
	{
		SceneManager.LoadScene(0);
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
