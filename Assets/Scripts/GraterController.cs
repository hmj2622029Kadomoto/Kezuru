using System.Collections;
using UnityEngine;

public class GraterController : MonoBehaviour
{ 
	[SerializeField] Transform Pizza;
	[SerializeField] Transform graterPoint;
	[SerializeField] float rotateSpeed = 90f;

	[SerializeField] float distance = 0.1f;
	float angle;

	[SerializeField] GameObject cheesePrefab;
	[SerializeField] float interval = 3f;

	[SerializeField] Vector3 areaCenter;
	[SerializeField] Vector3 areaSize = new Vector3(20f, 0f, 20f);

	void Start()
	{
		StartCoroutine(SpawnObjects());
	}

	void Update()
	{
		if (Pizza == null)
			return;
		angle += rotateSpeed * Time.deltaTime;
		Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 20f, Mathf.Sin(angle * Mathf.Deg2Rad)) * distance;
		transform.position = Pizza.position + offset;
	}
	IEnumerator SpawnObjects()
	{
		while (true)
		{

			Instantiate(cheesePrefab, graterPoint.position, transform.rotation);
			yield return new WaitForSeconds(interval);
		}
	}
}
