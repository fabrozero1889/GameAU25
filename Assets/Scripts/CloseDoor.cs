using UnityEngine;
using DoorScript;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] AudioSource closeSfx;
    [SerializeField] GameObject Door2;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var door = Door2.GetComponent<Door>();
        if (door != null) door.open = false;   // cerramos la puerta

        closeSfx?.Play();
        // ← desactiva el trigger para que no vuelva a disparar
        GetComponent<Collider>().enabled = false;
    }
}
