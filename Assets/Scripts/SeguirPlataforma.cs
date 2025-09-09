using UnityEngine;

public class SeguirPlataforma : MonoBehaviour
{
    void OnCollisionEnter (UnityEngine.Collision other)
    {
        if (other.gameObject.CompareTag("Plataforma"))
            transform.SetParent(other.transform);
    }

    void OnCollisionExit(UnityEngine.Collision other)
    {
        if (other.gameObject.CompareTag("Plataforma"))
            transform.SetParent(null);
    }
}
