using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reiniciar : MonoBehaviour
{
    [SerializeField] Image fade;          // arrastra tu FadeBlack (Image)
    [SerializeField] float fadeSeconds = 1f;
    [SerializeField] AudioSource sfx;     // opcional

    bool restarting;

    void Awake()
    {
        if (!fade)
            fade = GameObject.Find("FadeBlack")?.GetComponent<Image>(); // fallback simple
    }

    void Start()
    {
        if (fade)
        {
            fade.gameObject.SetActive(true);   // debe estar activa para CrossFadeAlpha
            fade.color = Color.black;          // fuerza negro
            fade.canvasRenderer.SetAlpha(0f);  // arranca invisible
            fade.transform.SetAsLastSibling(); // arriba de todo
            var cg = fade.GetComponentInParent<CanvasGroup>();
            if (cg) cg.alpha = 1f;             // por si el CanvasGroup estaba en 0
        }
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("kill")) DoKill();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kill")) DoKill();
    }

    void DoKill()
    {
        if (restarting) return;
        restarting = true;

        if (sfx) sfx.Play();

        if (fade)
        {
            fade.color = Color.black;                    // asegura negro
            fade.transform.SetAsLastSibling();           // por si algo quedó encima
            fade.CrossFadeAlpha(1f, fadeSeconds, true);  // true = unscaled time
        }

        Invoke(nameof(Reload), fadeSeconds + 0.5f);
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
