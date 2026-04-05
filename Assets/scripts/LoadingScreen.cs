using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Instance;

    [Header("UI")]
    public GameObject loadingScreenObject;
    public Slider progressBar;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        loadingScreenObject.SetActive(false);
    }

    public void SwitchToScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        loadingScreenObject.SetActive(true);
        progressBar.value = 0f;

        yield return new WaitForSeconds(0.5f);

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        while (op.progress < 0.9f)
        {
            progressBar.value = op.progress / 0.9f;
            yield return null;
        }

        progressBar.value = 1f;
        yield return new WaitForSeconds(0.3f);

        op.allowSceneActivation = true;

        yield return new WaitForSeconds(0.1f);
        loadingScreenObject.SetActive(false);
    }
}
