using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ABCLetterSpawnManager : MonoBehaviour
{
    [Header("Letters")]
    public Button[] allLetters;
    public RectTransform[] spawnPoints;

    [Header("UI")]
    public TMP_Text feedbackText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] letterSounds;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip wowSound;
    public AudioClip superSound;

    [Header("Celebration Images")]
    public GameObject wowImage;
    public GameObject superImage;

    private string currentLetter;
    private List<Button> activeButtons = new List<Button>();

    private int correctCount = 0;
    private bool playWowNext = true;
    private bool isBusy = false;

    void Start()
    {
        wowImage.SetActive(false);
        superImage.SetActive(false);
        GenerateNewRound();
    }

    void GenerateNewRound()
    {
        isBusy = false;
        StopAllCoroutines();

        foreach (Button b in allLetters)
            b.gameObject.SetActive(false);

        activeButtons.Clear();

        List<int> chosen = new List<int>();
        while (chosen.Count < 4)
        {
            int r = Random.Range(0, allLetters.Length);
            if (!chosen.Contains(r))
                chosen.Add(r);
        }

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Button btn = allLetters[chosen[i]];
            btn.gameObject.SetActive(true);

            btn.GetComponent<RectTransform>().anchoredPosition =
                spawnPoints[i].anchoredPosition;

            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => OnLetterClicked(btn));

            activeButtons.Add(btn);
        }

        Button target = activeButtons[Random.Range(0, activeButtons.Count)];
        currentLetter = target.GetComponentInChildren<TMP_Text>().text;

        feedbackText.text = "Find the Letter " + currentLetter + "!";
        PlayFindLetterAudio(currentLetter);
    }

    void OnLetterClicked(Button clicked)
    {
        if (isBusy) return;

        string picked = clicked.GetComponentInChildren<TMP_Text>().text;

        if (picked == currentLetter)
        {
            isBusy = true;
            correctCount++;

            feedbackText.text = "✅ Correct! " + currentLetter;

            if (audioSource && correctSound)
                audioSource.PlayOneShot(correctSound);

            if (correctCount % 5 == 0)
                StartCoroutine(CelebrationThenNextRound());
            else
                StartCoroutine(NextRoundDelay(1.2f));
        }
        else
        {
            feedbackText.text = "❌ Try Again!";

            if (audioSource && wrongSound)
                audioSource.PlayOneShot(wrongSound);

            StopAllCoroutines();
            StartCoroutine(ShowFindLetterAgain());
        }
    }

    IEnumerator CelebrationThenNextRound()
    {
        yield return new WaitForSeconds(0.5f);

        if (playWowNext)
        {
            wowImage.SetActive(true);
            audioSource.PlayOneShot(wowSound);
            yield return new WaitForSeconds(2f);
            wowImage.SetActive(false);
        }
        else
        {
            superImage.SetActive(true);
            audioSource.PlayOneShot(superSound);
            yield return new WaitForSeconds(2f);
            superImage.SetActive(false);
        }

        playWowNext = !playWowNext;
        GenerateNewRound();
    }

    IEnumerator NextRoundDelay(float t)
    {
        yield return new WaitForSeconds(t);
        GenerateNewRound();
    }

    IEnumerator ShowFindLetterAgain()
    {
        yield return new WaitForSeconds(2f);
        feedbackText.text = "Find the Letter " + currentLetter + "!";
    }

    void PlayFindLetterAudio(string letter)
    {
        if (audioSource == null || letterSounds.Length < 26) return;

        int index = letter[0] - 'A';
        if (letterSounds[index] != null)
        {
            audioSource.clip = letterSounds[index];
            audioSource.Play();
        }
    }
}
