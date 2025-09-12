using UnityEngine;

public class OnPelota : MonoBehaviour
{

    public GameObject PelotaOn;

public void OnTriggerEnter(Collider other)

    {
        PelotaOn.SetActive(true);
    }
}
