using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeControl: MonoBehaviour {

    private int sumScore;
    private int classicHighScore;
    public GameObject lifePanel;
    public GameObject life;
    public GameObject gameOverPanel;
    public GameObject gamePanel;
    public TextMeshProUGUI scoreText;
    private List<Transform> childs;
    public GameObject spwaner;
    public GameObject touchControl;
    public GameObject missPopSound;
    private int sound;

    void Start()
    {
        sound = PlayerPrefs.GetInt("sound");
        sumScore = PlayerPrefs.GetInt("sumScore");
        classicHighScore = PlayerPrefs.GetInt("classicHighScore");
        Transform[] childsArray = lifePanel.GetComponentsInChildren<Transform>();
        childs = new List<Transform>(childsArray);
        childs.Remove(lifePanel.transform);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            if (childs.Count == 0) return;
            Destroy(childs[childs.Count - 1].gameObject);
            childs.RemoveAt(childs.Count - 1);
            if (childs.Count == 0)
            {
                spwaner.SetActive(false);
                touchControl.SetActive(false);
                Invoke("GameOver", 2.5f);
            }
            if(sound == 0)
            {
                GameObject sound = Instantiate(missPopSound, this.transform);
                Destroy(sound, 1);
            }
            
        }
    }

    void GameOver()
    {
        int score = ScoreCounter.smashNumber;
        if (score > classicHighScore) PlayerPrefs.SetInt("classicHighScore", score);
        sumScore += score;
        PlayerPrefs.SetInt("sumScore", sumScore);
        Time.timeScale = 0;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        scoreText.text = "YOUR SCORE " + score;
    }
}
