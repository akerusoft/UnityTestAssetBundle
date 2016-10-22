using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour
{
    public void OnPressedButtonLoad()
    {
        StopWatch.Start();
        SceneManager.LoadScene("SceneB");
    }
}
