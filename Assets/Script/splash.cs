using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class splash : MonoBehaviour {

    public Image splashImage;

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
        yield return new WaitForSecondsRealtime(2f);
        FadeOut();
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Start Menu");

    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1f, true);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2f, true);
    }
}
