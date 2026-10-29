using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] AudioClip SE;
	[SerializeField] AudioClip SE2;
	AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
		if (scoreManager != null)
		{
			int score = scoreManager.GetScore();
			scoreText.text = "Score: " + score;
			if(score >0)
			{
				audioSource.PlayOneShot(SE);
			}
			else
			{
				audioSource.PlayOneShot(SE2);
			}
		}

		// スコアを表示したのでScoreManagerを削除
		Destroy(scoreManager.gameObject);
	}
	private void Update()
	{
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			SceneManager.LoadScene("TitleScene");
		}
	}
}
