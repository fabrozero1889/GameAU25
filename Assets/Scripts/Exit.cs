using DoorScript;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] GameObject Portal;
    [SerializeField] AudioSource Premio2;
    [SerializeField] AudioSource SfxPortal;
    [SerializeField] Animator PlayPortal;

   public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
        PlayPortal.enabled = true;
        AudioSource.PlayClipAtPoint(Premio2.clip, transform.position);
        AudioSource.PlayClipAtPoint(SfxPortal.clip, transform.position);


    } 

    
}
