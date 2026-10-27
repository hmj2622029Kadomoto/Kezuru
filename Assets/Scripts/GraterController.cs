using NUnit.Framework;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GraterController : MonoBehaviour
{ 
	[SerializeField] Transform Pizza;
	[SerializeField] Transform graterPoint;
	[SerializeField] float rotateSpeed = 90f;
	[SerializeField] AudioClip SE;

	[SerializeField] float distance = 0.1f;
	float angle;

	[SerializeField] GameObject cheesePrefab;
	[SerializeField] float interval = 3f;

	[SerializeField] Vector3 areaCenter;
	[SerializeField] Vector3 areaSize = new Vector3(20f, 0f, 20f);

	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		StartCoroutine(SpawnObjects());
	}

	void Update()
	{
		if (Pizza == null)
			return;
		angle += rotateSpeed * Time.deltaTime;
		Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 4f, Mathf.Sin((angle * 160f / 180f) * Mathf.Deg2Rad)) * distance;
		transform.position = Pizza.position + offset;
	}
	IEnumerator SpawnObjects()
	{
		while (true)
		{
			if (Mouse.current.leftButton.isPressed && Mouse.current.delta.magnitude > 0)
			{
				PlaySound();
				Instantiate(cheesePrefab, graterPoint.position, transform.rotation);
			}
			yield return new WaitForSeconds(interval);
		}
	}
	public void PlaySound()
	{
		if(audioSource.isPlaying)
		{
			return;
		}

		audioSource.Play();
	}
}
