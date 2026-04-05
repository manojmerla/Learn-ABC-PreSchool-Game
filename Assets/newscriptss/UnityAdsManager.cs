using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class UnityAdsManager : MonoBehaviour,
    IUnityAdsInitializationListener,
    IUnityAdsLoadListener,
    IUnityAdsShowListener
{
#if UNITY_ANDROID
    public string gameId = "5998678";
    public string interstitialId = "Interstitial_Android";
    public string bannerId = "Banner_Android";
#endif

    public static UnityAdsManager Instance;

    // ===== VIDEO CONTROL =====
    float lastVideoTime = -9999f;
    bool videoRequested = false;
    const float VIDEO_COOLDOWN = 900f; // 15 min cooldown

    // ===== BANNER CONTROL =====
    int bannerCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Advertisement.Initialize(gameId, false, this); // ✅ Test mode OFF
    }

    // ================= INIT CALLBACK =================
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Initialized");

        // Banner after 30 sec on game start
        StartCoroutine(ShowBannerAfter30Sec());
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Ads Init Failed: " + message);
    }

    // ================= VIDEO ADS =================

    public void OnLearningLevelChanged()
    {
        if (Time.realtimeSinceStartup - lastVideoTime < VIDEO_COOLDOWN)
            return;

        if (!videoRequested)
            StartCoroutine(ShowVideoAfter30Sec());
    }

    IEnumerator ShowVideoAfter30Sec()
    {
        videoRequested = true;
        yield return new WaitForSecondsRealtime(30f);

        if (Advertisement.isInitialized)
        {
            Debug.Log("Loading Video Ad...");
            Advertisement.Load(interstitialId, this);
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId == interstitialId)
        {
            Debug.Log("Showing Video Ad");
            Advertisement.Show(interstitialId, this);
            lastVideoTime = Time.realtimeSinceStartup;
            videoRequested = false;
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Video Load Failed: " + message);
        videoRequested = false;
    }

    // ================= BANNER ADS =================

    IEnumerator ShowBannerAfter30Sec()
    {
        yield return new WaitForSecondsRealtime(30f);
        ShowBanner();
    }

    void ShowBanner()
    {
        if (!Advertisement.isInitialized) return;

        bannerCount++;
        Debug.Log("Showing Banner #" + bannerCount);

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

        Advertisement.Banner.Load(bannerId, new BannerLoadOptions
        {
            loadCallback = () =>
            {
                Advertisement.Banner.Show(bannerId);
            }
        });
    }

    void RefreshBanner()
    {
        Advertisement.Banner.Hide(false);
        ShowBanner();
    }

    public void OnMainMenuOpened()
    {
        Debug.Log("Main Menu Opened - Refresh Banner");
        RefreshBanner();
    }

    public void OnPauseOpened()
    {
        Debug.Log("Pause Opened - Refresh Banner");
        RefreshBanner();
    }

    // ================= SHOW CALLBACKS =================
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) { }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }
    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }
}
