using UnityEngine;
using UnityEngine.Advertisements;

public class BannerTop : MonoBehaviour
{
    void Start()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show("Banner_Android");
    }
}
