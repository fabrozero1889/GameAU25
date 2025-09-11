using UnityEngine;

public class Elevator : MonoBehaviour

{
    [SerializeField] AudioSource Elevation;
    [SerializeField] Animator PlayElevator;

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            PlayElevator.enabled = true;
        Elevation.Play();
        

    }


}
