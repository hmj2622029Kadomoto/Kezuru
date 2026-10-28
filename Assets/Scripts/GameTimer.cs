using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
	[SerializeField] float gameTime = 120f;
	float timer;

	private void Start()
	{
		timer = gameTime;
	}

	private void Update()
	{
		timer -= Time.deltaTime;
		if(timer<=0f)
		{
			timer = 0f;
			SceneManager.LoadScene("ResultScene");
		}
	}
}
