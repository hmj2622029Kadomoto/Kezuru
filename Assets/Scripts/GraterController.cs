using System.Collections;
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
		// ピザを中心に複雑な動きをする
		Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 4f, Mathf.Sin((angle * 160f / 180f) * Mathf.Deg2Rad)) * distance;
		transform.position = Pizza.position + offset;
	}
	IEnumerator SpawnObjects()
	{
		while (true)
		{
			// 左クリックを長押ししながらマウスを動かしたとき処理を実行する
			if (Mouse.current.leftButton.isPressed && Mouse.current.delta.magnitude > 0)
			{
				PlaySound();
				// cheesePrefabを生成する
				Instantiate(cheesePrefab, graterPoint.position, transform.rotation);
			}
			yield return new WaitForSeconds(interval);
		}
	}

	// 削る音が鳴っている間に新しく音が鳴らないようにするための処理
	public void PlaySound()
	{
		if(audioSource.isPlaying)
		{
			return;
		}
		audioSource.Play();
	}
}
