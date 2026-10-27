using UnityEngine;

public class CheesePrefabController : MonoBehaviour
{
	[SerializeField] int correctScore = 10;
	[SerializeField] int wrongScore = -5;
	bool hit = false;
	ScoreManager scoreManager;

	private void Start()
	{
		scoreManager = FindFirstObjectByType<ScoreManager>();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (hit) return;

		if (collision.gameObject.CompareTag("Pizza"))
		{
			if (scoreManager != null)
			{
				scoreManager.Addscore(correctScore);
			}
			transform.SetParent(collision.transform);

			gameObject.tag = ("Pizza");

			hit = true;

			Rigidbody rbody = GetComponent<Rigidbody>();

			Collider col = GetComponent<Collider>();


			if (col != null)
			{
				col.enabled = false;
			}

			if (rbody != null)
			{
				rbody.linearVelocity = Vector3.zero;
				rbody.angularVelocity = Vector3.zero;
				rbody.isKinematic = true;
			}
		}
		else if(collision.gameObject.CompareTag("Table"))
		{
			if (scoreManager != null)
			{
				scoreManager.Addscore(wrongScore);
			}
			hit = true;

			Rigidbody rbody = GetComponent<Rigidbody>();

			Collider col = GetComponent<Collider>();


			if (col != null)
			{
				col.enabled = false;
			}

			if (rbody != null)
			{
				rbody.linearVelocity = Vector3.zero;
				rbody.angularVelocity = Vector3.zero;
				rbody.isKinematic = true;
			}
		}
	}
}