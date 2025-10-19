using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadePanel;       // UI Image (czarny panel)
    public float fadeDuration = 0.2f;

    void Start()
    {
        // Scena docelowa pojawia się płynnie
        StartCoroutine(FadeIn());
    }

    // Ładowanie sceny po INDEXIE
    public void LoadSceneByIndex(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    IEnumerator FadeIn()
    {
        Color c = fadePanel.color;
        for (float t = 1; t >= 0; t -= Time.deltaTime / fadeDuration)
        {
            c.a = t;
            fadePanel.color = c;
            yield return null;
        }
    }

    IEnumerator FadeOut(int sceneIndex)
    {
        Color c = fadePanel.color;
        for (float t = 0; t <= 1; t += Time.deltaTime / fadeDuration)
        {
            c.a = t;
            fadePanel.color = c;
            yield return null;
        }
        // Załadowanie sceny przez index
        SceneManager.LoadScene(sceneIndex);
    }

}