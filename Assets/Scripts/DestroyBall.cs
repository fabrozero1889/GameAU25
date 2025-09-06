using DoorScript;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    [SerializeField] AudioSource BallBounce;
    [SerializeField] AudioSource Electricity;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("kill"))
            Destroy(gameObject);
      

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kill"))
            Destroy(gameObject);
        AudioSource.PlayClipAtPoint(Electricity.clip, transform.position);
        
    }
}