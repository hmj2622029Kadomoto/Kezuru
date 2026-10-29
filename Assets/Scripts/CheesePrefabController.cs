using UnityEngine;

public class CheesePrefabController : MonoBehaviour
{
	[SerializeField] int correctScore = 10;
	[SerializeField] int wrongScore = -5;
	[SerializeField] ParticleSystem correctParticle;
	[SerializeField] ParticleSystem wrongParticle;
	bool hit = false;
	ScoreManager scoreManager;

	private void Start()
	{
		scoreManager = FindFirstObjectByType<ScoreManager>();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (hit) return;

		if (collision.gameObject.CompareTag("Pizza")) // Tag‚ÉPizza‚ª‚Â‚­‚à‚Ì‚ÉG‚ê‚½‚Æ‚«ˆ—‚ğÀs‚·‚é
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

			correctParticle.Play();
			wrongParticle.Stop();

			if (col != null)
			{
				col.enabled = false;
			}

			if (rbody != null)
			{
				// “®ì‚ğ’â~‚µA•¨—‰‰Z‚à‚È‚­‚·
				rbody.linearVelocity = Vector3.zero;
				rbody.angularVelocity = Vector3.zero;
				rbody.isKinematic = true;
			}
		}
		else if(collision.gameObject.CompareTag("Table")) // Tag‚ÉTable‚ª‚Â‚­‚à‚Ì‚ÉG‚ê‚½‚Æ‚«ˆ—‚ğÀs‚·‚é
		{
			if (scoreManager != null)
			{
				scoreManager.Addscore(wrongScore);
			}
			hit = true;

			Rigidbody rbody = GetComponent<Rigidbody>();

			Collider col = GetComponent<Collider>();

			wrongParticle.Play();


			if (col != null)
			{
				col.enabled = false;
			}

			if (rbody != null)
			{
				// “®ì‚ğ’â~‚µA•¨—‰‰Z‚à‚È‚­‚·
				rbody.linearVelocity = Vector3.zero;
				rbody.angularVelocity = Vector3.zero;
				rbody.isKinematic = true;
			}
		}
		// else‚ª‚È‚¢——R‚ÍTag‚Ì‚Â‚¢‚Ä‚¢‚È‚¢‚à‚Ì‚ÉG‚ê‚½‚Æ‚«‚És‚¤ˆ—‚ª‚È‚¢‚©‚ç
	}
}