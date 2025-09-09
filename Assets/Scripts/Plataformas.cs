using UnityEngine;
using DoorScript;

public class Plataformas : MonoBehaviour
{
    [SerializeField] AudioSource Electricity;
    [SerializeField] AudioSource OpenDoor;
    [SerializeField] GameObject Door2;
    [SerializeField] GameObject ActivarPl;

    private void OnCollisionEnter (UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("kill"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("kill")) return;

        // Activar objeto (puede estar desactivado, igual se asigna por Inspector)
        if (ActivarPl != null) ActivarPl.SetActive(true);
        else Debug.LogWarning("[Plataformas] 'ActivarPl' no asignado en el Inspector.");

        // Abrir puerta
        var door = Door2 != null ? Door2.GetComponent<Door>() : null;
        if (door != null) door.open = true;
        else Debug.LogWarning("[Plataformas] 'Door2' no asignado o no tiene componente Door.");

        // Sonidos (solo si hay AudioSource y clip)
        if (Electricity != null && Electricity.clip != null)
            AudioSource.PlayClipAtPoint(Electricity.clip, transform.position);
        else
            Debug.LogWarning("[Plataformas] 'Electricity' o su clip no están asignados.");

        if (OpenDoor != null && OpenDoor.clip != null)
            AudioSource.PlayClipAtPoint(OpenDoor.clip, transform.position);
        else
            Debug.LogWarning("[Plataformas] 'OpenDoor' o su clip no están asignados.");

        // Por último, destruir la pelota
        Destroy(gameObject);
    }
}
