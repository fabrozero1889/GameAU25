using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   // <-- agregado

public class Reiniciar : MonoBehaviour
{
    [SerializeField] Image fade; // arrastrá acá la Image negra (alpha 0)

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("kill"))
        {
            fade?.CrossFadeAlpha(0.5f, 1f, true); // fade a negro en 2s
            Invoke(nameof(Reload), 1f);          // recarga tras el fade
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kill"))
        {
            fade?.CrossFadeAlpha(0.5f, 1f, true); // fade a negro en 2s
            Invoke(nameof(Reload), 1f);          // recarga tras el fade
        }

        GetComponent<AudioSource>()?.Play();
    }

    void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

