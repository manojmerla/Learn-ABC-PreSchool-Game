using UnityEngine;
using TMPro;

public class LetterBatchManager : MonoBehaviour
{
    public GameObject letterPrefab;     // letter button prefab
    public Transform spawnArea;         // canvas lo letters spawn ayye place
    public TextMeshProUGUI pointsText;  // points text

    int index = 0;
    int score = 0;

    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    void Start()
    {
        LoadNext4();
        UpdatePoints();
    }

    public void LoadNext4()
    {
        foreach (Transform c in spawnArea)
            Destroy(c.gameObject);

        for (int i = 0; i < 4; i++)
        {
            if (index >= alphabet.Length) return;

            GameObject btn = Instantiate(letterPrefab, spawnArea);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = alphabet[index].ToString();
            btn.GetComponent<SingleLetter>().Setup(this);

            index++;
        }
    }

    public void AddPoint()
    {
        score++;
        UpdatePoints();
        LoadNext4();
    }

    void UpdatePoints()
    {
        pointsText.text = "Points: " + score;
    }
}
