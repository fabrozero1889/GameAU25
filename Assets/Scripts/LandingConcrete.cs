using UnityEngine;

public class LandingConcrete : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
{
    GetComponent<AudioSource>().Play();
}

    }
}

