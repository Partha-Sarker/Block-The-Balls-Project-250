using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PracticeGameManager : MonoBehaviour
{
    public TouchDetect touchDetect;
    public Button pauseButton;

    void Start()
    {
        BallMovement.speed = .9f;
        StickMovement.speed = 1.8f;
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
