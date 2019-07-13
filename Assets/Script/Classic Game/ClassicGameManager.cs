using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClassicGameManager : MonoBehaviour {

    public TouchDetect touchDetect;
    public Button pauseButton;
    public float speedUpSeconds = 5f;

    void Start()
    {
        BallMovement.speed = PlayerPrefs.GetFloat("speed");
        StickMovement.speed = BallMovement.speed*2;
        StartCoroutine("SpeedUp");
    }

    IEnumerator SpeedUp()
    {
        for(int i=0; i<100; i++)
        {
            print(BallMovement.speed);
            BallMovement.speed += .02f;
            StickMovement.speed += .04f;
            TouchDetect.stickDelayTime -= .01f;
            Baaaall.delay -= .01f;
            yield return new WaitForSeconds(speedUpSeconds);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseButton.onClick.Invoke();
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Start Menu");
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        touchDetect.setPaused(true);
    }

    public void ResumeGame()
    {
        
        Time.timeScale = 1;
        Invoke("setPaused", .1f);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void setPaused()
    {
        touchDetect.setPaused(false);
    }

}
