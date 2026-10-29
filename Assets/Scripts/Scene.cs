using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
	private void Update()
	{
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			// スペースキーが押されたらGameSceneに遷移する
			SceneManager.LoadScene("GameScene");
		}
	}
}
