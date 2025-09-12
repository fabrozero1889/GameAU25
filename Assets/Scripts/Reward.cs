using DoorScript;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] GameObject Door3;
    [SerializeField] AudioSource Premio;
    [SerializeField] AudioSource Door;

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        Destroy(gameObject);
        Door3.GetComponent<Door>().open = true;
        AudioSource.PlayClipAtPoint(Premio.clip, transform.position);
        AudioSource.PlayClipAtPoint(Door.clip, transform.position);


    } 

    
}
