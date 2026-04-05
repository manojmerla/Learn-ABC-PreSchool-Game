using UnityEngine;
using UnityEngine.UI;

public class PauseResumeWithMusic : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public AudioSource bgMusic;

    void Start()
    {
        Time.timeScale = 1f;
        bgMusic.Play();

        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        bgMusic.Pause();

        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        bgMusic.UnPause();

        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }
}
