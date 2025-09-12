using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinZoneUI_TMP : MonoBehaviour
{
    [SerializeField] Image   fadeWhite;           // la Image blanca (alpha 0 al inicio)
    [SerializeField] TMP_Text winText;            // tu TextMeshProUGUI "Fin"
    [SerializeField] float   fadeSeconds = 1f;
    [SerializeField] string  message = "¡FIN!";   // o "¡GANASTE!"

    bool done;

    void Start()
    {
        if (fadeWhite) fadeWhite.canvasRenderer.SetAlpha(0f);
        if (winText)
        {
            winText.text = message;
            var c = winText.color;
            winText.color = new Color(c.r, c.g, c.b, 0f); // empieza invisible
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (done || !other.CompareTag("Player")) return;
        done = true;

        // Fade a blanco + mostrar texto (usa tiempo no escalado)
        fadeWhite?.CrossFadeAlpha(1f, fadeSeconds, true);
        winText?.CrossFadeAlpha(1f, fadeSeconds, true);

        // Pausar juego y liberar cursor
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible   = true;
    }
}
