using UnityEngine;

public class BalloonPop : MonoBehaviour
{
    public AudioSource audioSource;   
    public AudioClip redSound;
    public AudioClip blueSound;
    public AudioClip YellowSound;
     public AudioClip greensound;
     public AudioClip pinksound;
     public AudioClip blacksound;
     public AudioClip whitesound;
     public AudioClip brownsound;
     public AudioClip purplesound;
    // add other colors

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        PlayColorSound();

        // Make balloon invisible instead of destroy
        sr.enabled = false;

        // Optional: stop movement if using BalloonMove
        BalloonMove move = GetComponent<BalloonMove>();
        if (move != null) move.enabled = false;
    }

    void PlayColorSound()
    {
        string t = tag;

        if (t == "Red") audioSource.PlayOneShot(redSound);
        else if (t == "Blue") audioSource.PlayOneShot(blueSound);
         else if (t == "Yellow") audioSource.PlayOneShot(YellowSound);
         else if (t == "Green") audioSource.PlayOneShot(greensound);
         else if (t == "Pink") audioSource.PlayOneShot(pinksound);
         else if (t == "Black") audioSource.PlayOneShot(blacksound);
         else if (t == "White") audioSource.PlayOneShot(whitesound);
       else if (t == "Brown") audioSource.PlayOneShot(brownsound);
        else if (t == "Purple") audioSource.PlayOneShot(purplesound);
        // add other colors
    }
}
