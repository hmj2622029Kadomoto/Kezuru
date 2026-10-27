using UnityEngine;
using UnityEngine.InputSystem;

public class CheeseController : MonoBehaviour
{
	[SerializeField] Transform Grater;
	[SerializeField] float rotateSpeed = 90f;
	[SerializeField] float cheeseX = 1f;
	[SerializeField] float cheeseY = 1f;

	[SerializeField] float distance = 0.1f;
	float angle;
	void Update()
	{
		// 左クリックを長押ししながらマウスを動かしたとき処理を実行する
		if (Mouse.current.leftButton.isPressed && Mouse.current.delta.magnitude > 0)
		{
			if (Grater == null)
				return;
			angle += rotateSpeed * Time.deltaTime;
		}
		Vector3 offset = new Vector3(cheeseX, Mathf.Cos(angle * Mathf.Deg2Rad) - cheeseY, 0f) * distance;
		transform.position = Grater.position + offset;
	}
}
