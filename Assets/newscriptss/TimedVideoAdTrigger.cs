using UnityEngine;
using System.Collections;

public class TimedVideoAdTrigger : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(VideoAfter20Min());
    }

    IEnumerator VideoAfter20Min()
    {
        yield return new WaitForSecondsRealtime(1200f); // 20 minutes

        if (UnityAdsManager.Instance != null)
        {
            UnityAdsManager.Instance.OnLearningLevelChanged();
        }
    }
}