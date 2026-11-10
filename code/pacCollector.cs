using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public AudioClip coinSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            Destroy(gameObject);

        }
    }
}
