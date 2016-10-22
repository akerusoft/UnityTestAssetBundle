using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBack : MonoBehaviour
{
    public void OnPressedButtonBack()
    {
        SceneManager.LoadScene("SceneA");
    }
}
