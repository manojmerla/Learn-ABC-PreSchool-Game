using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {
        // Scene load ayyaka banner refresh
        if(UnityAdsManager.Instance != null)
        {
            UnityAdsManager.Instance.OnMainMenuOpened();
        }
    }
}