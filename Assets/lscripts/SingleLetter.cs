using UnityEngine;

public class SingleLetter : MonoBehaviour
{
    private LetterBatchManager manager;

    public void Setup(LetterBatchManager m)
    {
        manager = m;
    }

    private void OnMouseDown()
    {
        manager.AddPoint();
    }
}
