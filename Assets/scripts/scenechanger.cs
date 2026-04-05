using UnityEngine;
using UnityEngine.SceneManagement;
public class scenechanger : MonoBehaviour
{
    public void scenechange()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void changetoplay()
    {
        SceneManager.LoadScene("Play");
    }
}
