using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class WinZoneUI_TMP : MonoBehaviour
{
    [SerializeField] Image   fadeWhite;               // Image blanca (Alpha 0)
    [SerializeField] TMP_Text winText;                // TU Text (TMP)
    [SerializeField] float   fadeSeconds = 1f;
    [SerializeField] float   textDelay   = 0.15f;
    [SerializeField] string  message     = "¡FIN!";
    [Header("Audio")]
    [SerializeField] bool    fadeOutAudio = true;
    [SerializeField, Range(0,1)] float targetVolume = 0f;

    bool done;

    void Awake()
    {
        if (!fadeWhite) fadeWhite = GameObject.Find("FadeWhite")?.GetComponent<Image>();
        if (!winText)
        {
            // busca nombres comunes
            var go = GameObject.Find("WinText") ?? GameObject.Find("Text (TMP)");
            winText = go ? go.GetComponent<TMP_Text>() : null;
        }
    }

    void Start()
    {
        if (fadeWhite)
        {
            fadeWhite.gameObject.SetActive(true);
            fadeWhite.color = Color.white;
            fadeWhite.canvasRenderer.SetAlpha(0f);
        }
        if (winText)
        {
            winText.text = message;

            // Asegurar que no esté “matado” por material/alpha
            winText.canvasRenderer.cullTransparentMesh = false;

            var c = winText.color;              // alpha del vértice (lo que animamos)
            winText.color = new Color(c.r, c.g, c.b, 0f);

            var mat = winText.fontMaterial;     // alpha del material (debe ser 1)
            if (mat && mat.HasProperty(ShaderUtilities.ID_FaceColor))
            {
                var face = mat.GetColor(ShaderUtilities.ID_FaceColor);
                face.a = 1f;
                mat.SetColor(ShaderUtilities.ID_FaceColor, face);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (done || !other.CompareTag("Player")) return;
        done = true;
        StartCoroutine(WinSequence());
    }

    IEnumerator WinSequence()
    {
        if (fadeWhite)
        {
            var cg = fadeWhite.GetComponentInParent<CanvasGroup>(); if (cg) cg.alpha = 1f;
            fadeWhite.transform.SetAsLastSibling();
            fadeWhite.canvasRenderer.SetAlpha(0f);
            fadeWhite.CrossFadeAlpha(1f, fadeSeconds, true); // unscaled time
        }

        if (winText)
        {
            winText.transform.SetAsLastSibling(); // texto por encima del blanco
            yield return new WaitForSecondsRealtime(textDelay);
            yield return StartCoroutine(FadeTMPAlpha(winText, 0f, 1f, fadeSeconds * 0.6f));
        }

        if (fadeOutAudio) StartCoroutine(FadeListenerVolume(AudioListener.volume, targetVolume, fadeSeconds));

        yield return new WaitForSecondsRealtime(fadeSeconds);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible   = true;
    }

    IEnumerator FadeTMPAlpha(TMP_Text txt, float from, float to, float dur)
    {
        if (!txt) yield break;
        var c = txt.color; c.a = from; txt.color = c;
        float t = 0f;
        while (t < dur)
        {
            t += Time.unscaledDeltaTime;
            c.a = Mathf.Lerp(from, to, t / dur);
            txt.color = c;
            yield return null;
        }
        c.a = to; txt.color = c;
    }

    IEnumerator FadeListenerVolume(float from, float to, float dur)
    {
        float t = 0f;
        while (t < dur)
        {
            t += Time.unscaledDeltaTime;
            AudioListener.volume = Mathf.Lerp(from, to, t / dur);
            yield return null;
        }
        AudioListener.volume = to;
    }
}
