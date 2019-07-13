using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Miss : MonoBehaviour {

    public TextMeshProUGUI missText;
    private int missNumber = 0;
    public GameObject missPopSound;
    private int sound;

    // Use this for initialization
    void Start()
    {
        sound = PlayerPrefs.GetInt("sound");
        missText.text = "Miss: 0";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            missNumber++;
            missText.text = "Miss: " + missNumber;
            other.gameObject.tag = "Destroy It";
            if (sound == 0)
            {
                GameObject sound = Instantiate(missPopSound, this.transform);
                Destroy(sound, 1);
            }
        }
    }

}
