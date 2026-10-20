using UnityEngine;

public class GraterController : MonoBehaviour
{ 
	[SerializeField] Transform Pizza;
	[SerializeField] float rotateSpeed = 90f;

	[SerializeField] float distance = 0.1f;
	float angle;
	void Update()
	{
		if (Pizza == null)
			return;
		angle += rotateSpeed * Time.deltaTime;
		Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 20f, Mathf.Sin(angle * Mathf.Deg2Rad)) * distance;
		transform.position = Pizza.position + offset;
	}
}
