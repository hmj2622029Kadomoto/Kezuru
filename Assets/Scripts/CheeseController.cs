using UnityEngine;
using UnityEngine.InputSystem;

public class CheeseController : MonoBehaviour
{
	[SerializeField] float moveSpeed = 90f;

	[SerializeField] protected float distance = 0.1f;
	protected virtual void Update()
	{
		if(Mouse.current.leftButton.isPressed)
		{

		}
	}
}
