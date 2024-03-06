using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneCrossfadeController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;

    private void Start()
    {
        // You can call the crossfade from here if you want it to start automatically
    }

    public void StartCrossfade()
    {
        StartCoroutine(Crossfade());
    }

    private IEnumerator Crossfade()
    {
        // Fade out from black to transparent
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = Color.black;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = Color.Lerp(Color.black, Color.clear, normalizedTime);
            yield return null;
        }

        // Load the next scene
        SceneManager.LoadScene("GameOver");

        // Fade back in from transparent to black
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = Color.Lerp(Color.clear, Color.black, normalizedTime);
            yield return null;
        }

        // Disable the fade image once the transition is complete
        fadeImage.gameObject.SetActive(false);
    }
}