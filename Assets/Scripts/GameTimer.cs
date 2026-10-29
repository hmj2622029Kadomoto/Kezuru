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
		// タイマーの表示
		scoreText.text = "Timer: " + timer.ToString("F1");
		// タイマーが０になったときResultSceneに遷移する
		if (timer <= 0f)
		{
			timer = 0f;
			SceneManager.LoadScene("ResultScene");
		}
	}
}
