using UnityEngine;

public class SceneAdTrigger : MonoBehaviour
{
    void Start()
    {
        if (UnityAdsManager.Instance != null)
        {
            UnityAdsManager.Instance.OnLearningLevelChanged();
        }
    }
}