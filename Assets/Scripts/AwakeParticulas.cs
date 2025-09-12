using UnityEngine;

public class AwakeParticulas : MonoBehaviour


{
    [SerializeField] GameObject Particulas;
    public void OnTriggerEnter(Collider other)
    {
        Particulas.SetActive(true);


    }

    }

