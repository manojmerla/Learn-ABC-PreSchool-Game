using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AZLetterLearning : MonoBehaviour
{
    public Image appleImage;              // UI Image
    public TextMeshProUGUI letterA;       
    public AudioSource audioSource;       
    public AudioClip aForAppleSound;      

    void Start()
    {
        letterA.gameObject.SetActive(false); 
    }

    private void OnMouseDown()
    {
        Debug.Log("APPLE CLICKED");

        // play sound
        audioSource.PlayOneShot(aForAppleSound);

        // ❌ NO Destroy()
        // ✔ Image OFF
        appleImage.enabled = false;

        // show letter
        letterA.gameObject.SetActive(true);

        // 10 sec → image on
        Invoke(nameof(ShowAppleAgain), 10f);
    }

    void ShowAppleAgain()
    {
        // image visible again
        appleImage.enabled = true;

        // hide text
        letterA.gameObject.SetActive(false);
    }
}
