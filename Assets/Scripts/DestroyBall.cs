using DoorScript;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    [SerializeField] AudioSource Electricity;
    [SerializeField] AudioSource OpenDoor;
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Door2;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("kill"))
            Destroy(gameObject);





    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kill"))
            Destroy(gameObject);
          Door.GetComponent<Door>().open = true;
          Door2.GetComponent<Door>().open = true;

        AudioSource.PlayClipAtPoint(Electricity.clip, transform.position);
        AudioSource.PlayClipAtPoint(OpenDoor.clip, transform.position);
        
    }
}