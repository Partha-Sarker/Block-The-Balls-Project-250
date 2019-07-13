using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour {

    public TextMeshProUGUI classicHighScore;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelScoreText;
    public GameObject soundOn;
    public GameObject soundOff;
    private int sound;
    public Slider speedSlider;

    private void Awake()
    {
        sound = PlayerPrefs.GetInt("sound");
    }

    void Start()
    {
        float sumScore = PlayerPrefs.GetInt("sumScore");
        int level = 1 + (int)Mathf.Pow((sumScore / 500f), 2f / 3f);
        levelScoreText.text = "OVERALL BLOCKS: " + PlayerPrefs.GetInt("sumScore");
        levelText.text = level.ToString();
        int highScore = PlayerPrefs.GetInt("classicHighScore");
        classicHighScore.text = "CLASSIC: " + highScore;
    }

    public void PlayClassicGame()
    {
        SceneManager.LoadScene("Classic Game Scene");
        Time.timeScale = 1;
    }

    public void PlayPracticeGame()
    {
        SceneManager.LoadScene("Practice Game Scene");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameMode()
    {
        //modeGroup.alpha = Mathf.Lerp(0f, 1f, .1f);
    }

    public void toggleSound()
    {
        if (sound == 0) PlayerPrefs.SetInt("sound", 1);
        else PlayerPrefs.SetInt("sound", 0);
    }

    public void settingsClicked()
    {

        if (sound == 0) soundOn.SetActive(true);
        else soundOff.SetActive(true);
    }

    public void setSpeed()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed");
    }

    public void saveSpeed()
    {
        PlayerPrefs.SetFloat("speed", speedSlider.value);
    }

}