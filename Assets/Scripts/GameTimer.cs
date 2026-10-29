using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
	[SerializeField] float gameTime = 120f;
	[SerializeField] TextMeshProUGUI scoreText;
	float timer;

	private void Start()
	{
		timer = gameTime;
	}

	private void Update()
	{
		timer -= Time.deltaTime;
		scoreText.text = "Timer: " + timer.ToString("F1");
		if(timer<=0f)
		{
			timer = 0f;
			SceneManager.LoadScene("ResultScene");
		}
	}
}
