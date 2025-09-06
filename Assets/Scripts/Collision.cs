using UnityEngine;

public class Collision : MonoBehaviour
{

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        GetComponent<AudioSource>().Play();
    }


}

    
