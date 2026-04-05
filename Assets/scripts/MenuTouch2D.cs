using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Play button (Splash / Home → MainMenu)
    public void Play()
    {
        LoadingScreen.Instance.SwitchToScene("MainMenu");
    }

    // Quiz button
    public void OpenQuiz()
    {
        LoadingScreen.Instance.SwitchToScene("Quiz");
    }

    // Learn button
    public void OpenLearn()
    {
        LoadingScreen.Instance.SwitchToScene("Learn");
    }

    // Colour / Balloon game
    public void Colour()
    {
        LoadingScreen.Instance.SwitchToScene("balloon");
    }
     public void backplay()
    {
        LoadingScreen.Instance.SwitchToScene("Play");
    }
    // Exit button (optional)
    public void ExitGame()
    {
        Application.Quit();
    }
}
