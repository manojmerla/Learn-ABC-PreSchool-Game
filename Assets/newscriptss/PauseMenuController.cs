using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    // Call this from pause button
    public void OnPauseOpen()
    {
        if (UnityAdsManager.Instance != null)
        {
            UnityAdsManager.Instance.OnPauseOpened(); // Banner refresh
        }
        Debug.Log("Pause button pressed - Banner refreshed");
    }
}