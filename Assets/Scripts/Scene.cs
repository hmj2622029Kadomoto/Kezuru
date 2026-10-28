using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
	private void Update()
	{
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			SceneManager.LoadScene("GameScene");
		}
	}
}
