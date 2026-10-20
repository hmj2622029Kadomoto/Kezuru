using UnityEngine;
using UnityEngine.InputSystem;

public class CheeseController : MonoBehaviour
{
	[SerializeField] GameObject grater;
	private void Update()
	{
		if(Mouse.current.leftButton.isPressed)
		{
			Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				float y = Mathf.RoundToInt(hit.point .y);
				transform.position = new Vector3(0, y, 0);
			}
		}
	}
}
