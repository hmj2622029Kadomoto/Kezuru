using UnityEngine;

public class GraterController : MonoBehaviour
{ 
	[SerializeField] Transform Pizza;
	[SerializeField] float rotateSpeed = 90f;
	[SerializeField] bool followPizza = true;

	[SerializeField] float distance = 0.1f;
	float angle;
	void Update()
	{
		if (!followPizza)
			return;
		if (Pizza == null)
			return;
		angle += rotateSpeed * Time.deltaTime;
		Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 7.5f, Mathf.Sin(angle * Mathf.Deg2Rad)) * distance;
		transform.position = Pizza.position + offset;
	}
	public bool FollowPlayer() // プレイヤーに追従しているかどうかを確認する関数
	{
		return followPizza;
	}
}
