using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("kill"))
            Destroy(gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kill"))
            Destroy(gameObject);
        
    }
}