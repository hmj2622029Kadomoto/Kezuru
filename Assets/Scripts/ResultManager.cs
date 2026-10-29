using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] AudioClip BGM;
	[SerializeField] AudioClip BGM2;
	AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
		if (scoreManager != null)
		{
			int score = scoreManager.GetScore();
			scoreText.text = "Score: " + score;
			if (score > 0)// スコアが０より大きいとき、達成感のあるBGMを流す
			{
				audioSource.PlayOneShot(BGM);
			}
			else // ０以下のとき、悲壮感のあるBGMを流す
			{
				audioSource.PlayOneShot(BGM2);
			}
		}

		// スコアを表示したのでScoreManagerを削除
		Destroy(scoreManager.gameObject);
	}
	private void Update()
	{
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			// スペースキーが押されたときTitleSceneに遷移する
			SceneManager.LoadScene("TitleScene");
		}
	}
}
