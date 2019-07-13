using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class fadingIn : MonoBehaviour {

    private static bool faded = false;
    public Image blackImage;

    IEnumerator Start() {
        if (!faded)
        {
            blackImage.gameObject.SetActive(true);
            blackImage.CrossFadeAlpha(0.0f, 2.5f, true);
            faded = true;
            yield return new WaitForSecondsRealtime(2.5f);
            blackImage.gameObject.SetActive(false);
        }
	}
	

}
