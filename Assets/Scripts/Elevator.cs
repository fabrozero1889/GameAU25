using UnityEngine;

public class Elevator : MonoBehaviour

{
    [SerializeField] AudioSource Elevation;
    [SerializeField] Animator PlayElevator;
    [SerializeField] GameObject Iluminar;

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            PlayElevator.enabled = true;
        Elevation.Play();
        Iluminar.SetActive(true);


    }

    public void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            PlayElevator.enabled = false;
        Elevation.Stop();
        Iluminar.SetActive(false);
    }


}
