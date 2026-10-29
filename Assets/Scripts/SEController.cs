using UnityEngine;

public class SEController : MonoBehaviour
{
	[SerializeField] AudioClip SE;
	AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	private void OnCollisionEnter(Collision collision)
	{
		// ‰½‚ª‚ªG‚ê‚½‚Æ‚«‰¹‚ğ–Â‚ç‚·
		audioSource.PlayOneShot(SE);
	}
}
