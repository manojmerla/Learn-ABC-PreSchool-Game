using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InternetCheck : MonoBehaviour
{
    [Header("UI")]
    public GameObject noInternetPanel;

    [Header("Scenes")]
    public string mainSceneName = "mainmenu";
    public string noInternetSceneName = "NoInternet";

    bool isOnline = true;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (noInternetPanel != null)
            noInternetPanel.SetActive(false);

        StartCoroutine(CheckInternetLoop());
    }

    IEnumerator CheckInternetLoop()
    {
        while (true)
        {
            yield return StartCoroutine(CheckConnection());
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator CheckConnection()
    {
        WWW www = new WWW("https://www.google.com");
        yield return www;

        if (www.error != null)
        {
            if (isOnline)
            {
                isOnline = false;

                if (noInternetPanel != null)
                    noInternetPanel.SetActive(true);

                if (SceneManager.GetActiveScene().name != noInternetSceneName)
                    SceneManager.LoadScene(noInternetSceneName);
            }
        }
        else
        {
            if (!isOnline)
            {
                isOnline = true;

                if (noInternetPanel != null)
                    noInternetPanel.SetActive(false);

                if (SceneManager.GetActiveScene().name != mainSceneName)
                    SceneManager.LoadScene(mainSceneName);
            }
        }
    }
}
